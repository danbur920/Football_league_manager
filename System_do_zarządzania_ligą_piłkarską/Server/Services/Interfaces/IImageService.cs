using System_do_zarządzania_ligą_piłkarską.Server.Controllers;
using System_do_zarządzania_ligą_piłkarską.Shared.DTOs.Images;
using System_do_zarządzania_ligą_piłkarską.Shared.Enums;

namespace System_do_zarządzania_ligą_piłkarską.Server.Services.Interfaces
{
    public interface IImageService
    {
        Task UploadPhoto(NewImageDTO newImage);
    }
}
