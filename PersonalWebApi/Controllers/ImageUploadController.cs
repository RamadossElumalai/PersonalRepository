using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace PersonalWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageUploadController : ControllerBase
    {
        private readonly ImageUploadService _imageUploadService;

        public ImageUploadController(ImageUploadService imageUploadService)
        {
            _imageUploadService = imageUploadService;
        }

        [HttpGet]
        public List<string> GetImages()
        {
            List<string> imageData = new List<string>();

            foreach(var item in _imageUploadService.GetAllImages())
            {
                imageData.Add(Convert.ToBase64String(item.ContentImage));
            }

            return imageData;
        }

        [HttpPost]
        public ImageUpload AddImage(IFormFile formfile)
        {
            var image = new ImageUpload {
                ContentImage = ConvertToBytes(formfile),
                UploadDateTime = DateTime.Now
            };

            var uploadedImage  = _imageUploadService.Create(image);

            return uploadedImage;
        }

        [NonAction]
        private static byte[] ConvertToBytes(IFormFile image)
        {
            byte[] CoverImageBytes = null;
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }
    }
}
