using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Özel indirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel indirim";
            ViewBag.v3 = "Özel indirim Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7032/api/SpecialOffers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("CreateSpecialOffer")]
        [HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.v0 = "Özel indirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel indirim";
            ViewBag.v3 = "Özel indirim girişi";
            return View();
        }

        [Route("CreateSpecialOffer")]
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7032/api/SpecialOffers", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveSpecialOffer/{id}")]
        public async Task<IActionResult> RemoveSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7032/api/SpecialOffers?SpecialOfferId=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.v0 = "Özel indirim İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel indirim";
            ViewBag.v3 = "Özel indirim güncelleme";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7032/api/SpecialOffers/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
                return View(result);
            }
            return View();
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto dto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7032/api/SpecialOffers/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });

            }
            return View();
        }
    }
}
