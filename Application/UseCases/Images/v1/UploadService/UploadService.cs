using Application.UseCases.Images.v1.UploadService.Services.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Images.v1.UploadService
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
                await file.CopyToAsync(new FileStream(newFilePath, FileMode.CreateNew), cancellationToken);
                newFilesName.Add(new FileInfo(newFileName));
            }

            return newFilesName;
        }
    }
}
