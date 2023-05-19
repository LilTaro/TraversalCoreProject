using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Route("Admin/VisitorAPI")]
    public class VisitorAPIController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorAPIController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:35404/api/Visitor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("AddVisitor")]
        [HttpGet]
        public IActionResult AddVisitor()
        {
            return View();
        }
        [Route("AddVisitor")]
        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/JSON");
            var responseMessage = await client.PostAsync("http://localhost:35404/api/Visitor", content);
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("DeleteVisitor/{id}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:35404/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("UpdateVisitor/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:35404/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("UpdateVisitor/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/JSON");
            var responseMessage = await client.PutAsync("http://localhost:35404/api/Visitor", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
