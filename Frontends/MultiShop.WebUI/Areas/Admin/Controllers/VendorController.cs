using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.VendorDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Vendor")]
    public class VendorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VendorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Satıcı Marka İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Satıcı Markalar";
            ViewBag.v3 = "Satıcı Marka Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7032/api/Vendors");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultVendorDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("CreateVendor")]
        [HttpGet]
        public IActionResult CreateVendor()
        {
            ViewBag.v0 = "Satıcı Marka İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Satıcı Markalar";
            ViewBag.v3 = "Yeni Satıcı Marka Girişi";
            return View();
        }

        [Route("CreateVendor")]
        [HttpPost]
        public async Task<IActionResult> CreateVendor(CreateVendorDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7032/api/Vendors", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }
            return View();
        }

        [Route("RemoveVendor/{id}")]
        public async Task<IActionResult> RemoveVendor(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7032/api/Vendors?vendorId=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateVendor/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateVendor(string id)
        {
            ViewBag.v0 = "Satıcı Marka İşlemleri";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Satıcı Markalar";
            ViewBag.v3 = "Satıcı Marka Güncelleme";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7032/api/Vendors/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UpdateVendorDto>(jsonData);
                return View(result);
            }
            return View();
        }

        [Route("UpdateVendor/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateVendor(UpdateVendorDto dto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7032/api/Vendors/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Vendor", new { area = "Admin" });

            }
            return View();
        }
    }
}
