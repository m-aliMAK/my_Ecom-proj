using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ImageService : IImageService
    {
        private readonly string _imagePath = "wwwroot/images"; // Image folder path

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file");

            var imageName = Path.GetFileName(file.FileName);
            var fullPath = Path.Combine(_imagePath, imageName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return imageName; // You can return the relative URL if needed
        }

        public Task<string> GetImageUrlAsync(string imageName)
        {
            var imageUrl = Path.Combine("/images", imageName);
            return Task.FromResult(imageUrl);
        }

        public Task DeleteImageAsync(string imageName)
        {
            var fullPath = Path.Combine(_imagePath, imageName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            return Task.CompletedTask;
        }
    }
}
