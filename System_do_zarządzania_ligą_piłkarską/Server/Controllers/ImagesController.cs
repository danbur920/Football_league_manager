using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;


namespace System_do_zarządzania_ligą_piłkarską.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto([FromForm] NewImageDTO newImage)
        {
            if (newImage.File == null || newImage.File.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            await _imageService.UploadPhoto(newImage);
            return Ok("Photo uploaded successfully.");
        }
    }


    //public static string GetDisplayName(EventType eventType)
    //{
    //    return eventType switch
    //    {
    //        EventType.Goal => "Gol",
    //        EventType.OwnGoal => "Gol samobójczy",
    //        EventType.YellowCard => "Żółta kartka",
    //        EventType.RedCard => "Czerwona kartka",
    //        EventType.Penalty => "Rzut karny - gol",
    //        EventType.MissedPenalty => "Rzut karny - nietrafiony",
    //        EventType.Substitution => "Zmiana",
    //        _ => eventType.ToString()
    //    };
    //}
}
