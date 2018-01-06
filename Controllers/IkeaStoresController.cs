using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MobileEngineeringServer.Controllers
{
    [Route("api/ikea/stores")]
    public class IkeaStoresController : Controller
    {
        private readonly IkeaStoreService _ikeaStoreService;

        public IkeaStoresController(IkeaStoreService ikeaStoreService)
        {
            _ikeaStoreService = ikeaStoreService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStore([FromRoute]int id)
        {
            try
            {
                var stores = await _ikeaStoreService.Get(id);

                return Json(stores);
            }
            catch
            {
                return BadRequest($"Store with id {id} could not be read!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            try
            {
                var stores = await _ikeaStoreService.GetAll();

                return Json(stores);
            }
            catch
            {
                return BadRequest("Stores could not be read!");
            }
        }
    }
}
