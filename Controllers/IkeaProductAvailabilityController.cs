using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using MobileEngineeringServer.XML.Availability;
using Newtonsoft.Json;

namespace MobileEngineeringServer.Controllers
{
    [Route("api/ikea/stores/{storeId}/products/{productNumber}/availability")]
    public class IkeaProductAvailabilityController : Controller
    {
        private readonly IkeaStoreService _ikeaStoreService;

        const string AvailabilityUrl = "http://www.ikea.com/de/de/iows/catalog/availability/{0}";

        public IkeaProductAvailabilityController(IkeaStoreService ikeaStoreService)
        {
            _ikeaStoreService = ikeaStoreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailability([FromRoute]string storeId, [FromRoute]string productNumber)
        {
            var client = new HttpClient();

            string apiResult = null;

            try
            {
                apiResult = await client.GetStringAsync(string.Format(AvailabilityUrl, productNumber));
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                return BadRequest("IKEA-API call failed.");
            }

            if (string.IsNullOrWhiteSpace(apiResult))
            {
                return BadRequest("IKEA-API call failed.");
            }

            var xmlSerializer = new XmlSerializer(typeof(Ikearest));

            xmlSerializer.UnknownAttribute += (s, e) =>
            {
                Console.Error.WriteLine("Warning: Deserializing "
                                    + e.ObjectBeingDeserialized
                                    + ": Unknown attribute "
                                    + e.Attr.Name);
            };
            xmlSerializer.UnknownElement += (s, e) =>
            {
                Console.Error.WriteLine("Warning: Deserializing "
                           + e.ObjectBeingDeserialized
                           + ": Unknown element "
                           + e.Element.Name);
            };
            xmlSerializer.UnknownNode += (s, e) =>
            {
                Console.Error.WriteLine("Warning: Deserializing "
                                   + e.ObjectBeingDeserialized
                                   + ": Unknown node "
                                   + e.Name);
            };

            Ikearest ikeaRest = null;
            try
            {
                var deserializeResult = xmlSerializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(apiResult)));
                ikeaRest = (Ikearest)deserializeResult;

                var ikeaStore = ikeaRest.Availability.LocalStore.FirstOrDefault(x => x.BuCode == storeId);
                if (ikeaStore == null)
                {
                    return BadRequest("Product not sold in store");
                }

                var ikeaStock = new IkeaStock
                {
                    StoreId = ikeaStore.BuCode,
                    InStockProbabilityCode = ikeaStore.Stock.InStockProbabilityCode,
                    IsInStoreRange = String.Equals(ikeaStore.Stock.IsInStoreRange, Boolean.TrueString, StringComparison.InvariantCultureIgnoreCase),
                    IsMultiProduct = String.Equals(ikeaStore.Stock.IsMultiProduct, Boolean.TrueString, StringComparison.InvariantCultureIgnoreCase),
                    IsSoldInStore = String.Equals(ikeaStore.Stock.IsSoldInStore, Boolean.TrueString, StringComparison.InvariantCultureIgnoreCase),
                    PartNumber = ikeaStore.Stock.PartNumber
                };

                if (int.TryParse(ikeaStore.Stock.AvailableStock, out var availableStock))
                {
                    ikeaStock.AvailableStock = availableStock;
                }
                else
                {
                    ikeaStock.AvailableStock = -1;
                }

                foreach (var item in ikeaStore.Stock.FindItList.FindIt)
                {
                    var stockProduct = new IkeaStockProduct
                    {
                        PartNumber = item.PartNumber,
                        Box = item.Box,
                        Shelf = item.Shelf,
                        Type = item.Type
                    };
                    if (int.TryParse(item.Quantity, out var quantity))
                    {
                        stockProduct.Quantity = quantity;
                    }
                    else
                    {
                        stockProduct.Quantity = -1;
                    }
                    ikeaStock.Products.Add(stockProduct);
                }
                
                return Json(ikeaStock);
            }
            catch
            {
                return BadRequest("API-Result cannot be deserialized.");
            }
        }
    }
}
