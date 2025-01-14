using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Özellik İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Özellik Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7032/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("CreateFeature")]
        [HttpGet]
        public IActionResult CreateFeature()
        {
            ViewBag.v0 = "Özellik İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Yeni Özellik girişi";
            return View();
        }

        [Route("CreateFeature")]
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7032/api/Features", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveFeature/{id}")]
        public async Task<IActionResult> RemoveFeature(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7032/api/Features?featureId=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateFeature/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBag.v0 = "Özellik İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özellikler";
            ViewBag.v3 = "Özellik güncelleme";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7032/api/Features/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(result);
            }
            return View();
        }

        [Route("UpdateFeature/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7032/api/Features/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Feature", new { area = "Admin" });

            }
            return View();
        }
    }
}
