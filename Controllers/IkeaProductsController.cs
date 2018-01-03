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
using MobileEngineeringServer.XML;
using Newtonsoft.Json;

namespace MobileEngineeringServer.Controllers
{
    [Route("api/ikea/products")]
    public class IkeaProductsController : Controller
    {
        // https://medium.com/@JoshuaAJung/api-of-the-day-ikea-availability-checks-8678794a9b52

        const string IkeaBaseUrl = "http://www.ikea.com{0}";
        const string GermanProductUrl = "http://www.ikea.com/de/de/catalog/products/{0}?type=xml";

        // GET api/values/5
        [HttpGet("{number}")]
        public async Task<IActionResult> GetByProductNumber(string number)
        {
            var productNumber = number.PadLeft(8, '0');

            var client = new HttpClient();

            var apiResult = await client.GetStringAsync(string.Format(GermanProductUrl, productNumber));
            if(string.IsNullOrWhiteSpace(apiResult)) {
                return BadRequest("IKEA-API call failed.");
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Ikearest));

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
            }
            catch
            {
                return BadRequest("API-Result cannot be deserialized.");
            }

            if (ikeaRest != null)
            {
                var ikeaProduct = ikeaRest.Products.Product.FirstOrDefault();
                if(ikeaProduct == null) {
                    return BadRequest("Product not found.");
                }

                var product = new IkeaProduct();

                product.ParentUrl = string.Format(IkeaBaseUrl, ikeaProduct.URL);
                product.ParentPartNumber = ikeaProduct.PartNumber;
                product.ParentDisplayName = ikeaProduct.Name;
                product.ParentDisplayNameSweden = ikeaProduct.Nameswe;

                var ikeaProductItem = ikeaProduct.Items.Item;
                product.Url = string.Format(IkeaBaseUrl, ikeaProductItem.URL);
                product.PartNumber = ikeaProductItem.PartNumber;
                product.DisplayName = ikeaProductItem.Name;
                product.DisplayNameSweden = ikeaProductItem.Nameswe;
                product.CareInstructions = ikeaProductItem.CareInst;
                product.CustomerBenefit = ikeaProductItem.CustBenefit;
                product.CustomerMaterials = ikeaProductItem.CustMaterials;
                product.Designer = ikeaProductItem.Designer;
                product.Environment = ikeaProductItem.Environment;
                product.Facts = ikeaProductItem.Facts;
                product.GoodToKnow = ikeaProductItem.GoodToKnow;
                product.IsBti = string.Equals(ikeaProductItem.Bti, bool.TrueString, StringComparison.InvariantCultureIgnoreCase);
                product.IsNew = string.Equals(ikeaProductItem.New, bool.TrueString, StringComparison.InvariantCultureIgnoreCase);
                product.Measure = ikeaProductItem.Measure;
                if (int.TryParse(ikeaProductItem.Nopackages, out var numberOfPackages))
                {
                    product.NumberOfPackages = numberOfPackages;
                }
                product.RequireAssembly = string.Equals(ikeaProductItem.ReqAssembly, bool.TrueString, StringComparison.InvariantCultureIgnoreCase);
                product.Type = ikeaProductItem.Type;

                if (decimal.TryParse(ikeaProductItem.Prices.Normal.PriceNormal.Unformatted, out var normalPrice))
                {
                    product.NormalPrice = normalPrice;
                }
                 if (decimal.TryParse(ikeaProductItem.Prices.Second.PriceNormal.Unformatted, out var secondPrice))
                {
                    product.SecondPrice = secondPrice;
                }
                 if (decimal.TryParse(ikeaProductItem.Prices.Familynormal.PriceNormal.Unformatted, out var familyPrice))
                {
                    product.FamilyNormalPrice = familyPrice;
                }

                foreach (var item in ikeaProductItem.SubItems.Article)
                {
                    if (int.TryParse(item.Quantity, out var quantity))
                    {
                        product.SubProducts.Add(new IkeaSubProduct(item.PartNumber, quantity));
                    }
                }

                foreach (var item in ikeaProductItem.Images.Normal.Image)
                {
                    product.SmallImageUrls.Add(item.Text);
                }
                foreach (var item in ikeaProductItem.Images.Zoom.Image)
                {
                    product.LargeImageUrls.Add(item.Text);
                }

                return Ok(JsonConvert.SerializeObject(product));
            }

            return BadRequest();
        }
    }
}
