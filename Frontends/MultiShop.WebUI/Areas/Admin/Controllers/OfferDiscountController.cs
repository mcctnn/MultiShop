using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OfferDiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "İndirimi teklifi İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirimi teklifiler";
            ViewBag.v3 = "İndirimi teklifi Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7032/api/OfferDiscounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("CreateOfferDiscount")]
        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.v0 = "İndirimi teklifi İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirimi teklifiler";
            ViewBag.v3 = "Yeni İndirimi teklifi Girişi";
            return View();
        }

        [Route("CreateOfferDiscount")]
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7032/api/OfferDiscounts", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveOfferDiscount/{id}")]
        public async Task<IActionResult> RemoveOfferDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7032/api/OfferDiscounts?OfferDiscountId=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.v0 = "İndirimi teklifi İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "İndirimi teklifiler";
            ViewBag.v3 = "İndirimi teklifi Güncelleme";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7032/api/OfferDiscounts/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData);
                return View(result);
            }
            return View();
        }

        [Route("UpdateOfferDiscount/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto dto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7032/api/OfferDiscounts/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });

            }
            return View();
        }
    }
}
