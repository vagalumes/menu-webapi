﻿using Application.Shared.Services.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Shared.Services
{
    public class UploadService(IHostingEnvironment hostingEnvironment) : IUploadService
    {
        public async Task<IEnumerable<FileInfo>> UploadFiles(string imagePath, IEnumerable<IFormFile> files, CancellationToken cancellationToken)
        {
            var newFilesName = new List<FileInfo>();
            var imagesPath = Path.Combine(hostingEnvironment.WebRootPath, "images", imagePath);

            foreach (var file in files)
            {
                if (!Directory.Exists(imagesPath))
                    _ = Directory.CreateDirectory(imagesPath);

                var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var newFilePath = Path.Combine(imagesPath, newFileName);
                var teste = Path.Combine("images", imagePath, newFileName);
                await file.CopyToAsync(new FileStream(newFilePath, FileMode.CreateNew), cancellationToken);
                newFilesName.Add(new FileInfo(teste));
            }

            return newFilesName;
        }
    }
}