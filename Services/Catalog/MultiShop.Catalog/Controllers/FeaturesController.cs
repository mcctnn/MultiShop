using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeatures()
        {
            var result = await _featureService.GetAllFeaturesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFeature(string id)
        {
            var result = await _featureService.GetByIdFeatureAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return Ok("Şirket avantajı  eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(string FeatureId)
        {
            await _featureService.DeleteFeatureAsync(FeatureId);
            return Ok("Şirket avantajı  silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Şirket avantajı  güncellendi");
        }
    }
}
