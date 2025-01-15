using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SocialMediaDtos;
using MultiShop.Catalog.Services.SocialMediaServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _SocialMediaService;

        public SocialMediasController(ISocialMediaService SocialMediaService)
        {
            _SocialMediaService = SocialMediaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSocialMedias()
        {
            var result = await _SocialMediaService.GetAllSocialMediasAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSocialMedia(string id)
        {
            var result = await _SocialMediaService.GetByIdSocialMediaAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            await _SocialMediaService.CreateSocialMediaAsync(createSocialMediaDto);
            return Ok("Sosyal medya eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSocialMedia(string SocialMediaId)
        {
            await _SocialMediaService.DeleteSocialMediaAsync(SocialMediaId);
            return Ok("Sosyal medya silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            await _SocialMediaService.UpdateSocialMediaAsync(updateSocialMediaDto);
            return Ok("Sosyal medya güncellendi");
        }
    }
}
