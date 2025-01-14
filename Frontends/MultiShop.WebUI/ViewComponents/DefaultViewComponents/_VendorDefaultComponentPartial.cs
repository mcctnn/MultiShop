using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.VendorDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _VendorDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
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
    }
}
