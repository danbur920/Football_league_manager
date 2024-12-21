using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System_do_zarządzania_ligą_piłkarską.Server.Controllers;
using System_do_zarządzania_ligą_piłkarską.Server.Models;
using System_do_zarządzania_ligą_piłkarską.Server.Repositories.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task UploadPhoto(NewImageDTO newImage)
        {
            if (newImage != null)
            {
                string imageTypeFolder = "";
                string imageName = "";
                int? imageEntityId = 0;

                if (newImage.Type == ImageType.Footballer)
                {
                    imageTypeFolder = "footballers";
                    imageEntityId = newImage.FootballerId;
                }
                else if (newImage.Type == ImageType.Team)
                {
                    imageTypeFolder = "teams";
                    imageEntityId = newImage.TeamId;
                }
                else if (newImage.Type == ImageType.League)
                {
                    imageTypeFolder = "leagues";
                    imageEntityId = newImage.LeagueId;
                }
                else if (newImage.Type == ImageType.Referee)
                {
                    imageTypeFolder = "referees";
                    imageEntityId = newImage.RefereeId;
                }

                imageName = $"{imageTypeFolder.Substring(0, imageTypeFolder.Length - 1)}-{imageEntityId}";
                var relativePath = Path.Combine("images", imageTypeFolder, $"{imageName}.jpg");

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);
                var directoryPath = Path.GetDirectoryName(uploadsFolder);
                if (directoryPath != null)
                {
                    Directory.CreateDirectory(directoryPath); 
                }

                if (File.Exists(uploadsFolder))
                {
                    File.Delete(uploadsFolder);
                }

                using (var stream = new FileStream(uploadsFolder, FileMode.Create))
                {
                    await newImage.File.CopyToAsync(stream);
                }

                // Zapis ścieżki względnej w bazie
                var imageEntity = new Image
                {
                    Path = relativePath.Replace("\\", "/"), 
                    FootballerId = newImage.FootballerId,
                    TeamId = newImage.TeamId,
                    RefereeId = newImage.RefereeId,
                    LeagueId = newImage.LeagueId
                };

                await _imageRepository.AddPhoto(imageEntity);
            }
        }


    }
}
