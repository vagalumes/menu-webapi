using Application.Shared.Services.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Shared.Services;

public class ImagesService(IHostingEnvironment hostingEnvironment) : IImagesService
{
    private const string ImagesFolder = "images";

    public async Task<IEnumerable<FileInfo>> UploadFiles(string imagePath, IEnumerable<IFormFile> files, CancellationToken cancellationToken)
    {
        var newFilesInfo = new List<FileInfo>();
        var imagesPath = Path.Combine(hostingEnvironment.WebRootPath, ImagesFolder, imagePath);

        if (!Directory.Exists(imagesPath))
            _ = Directory.CreateDirectory(imagesPath);

        foreach (var file in files)
        {
            var fileInfo = await SaveFile(imagePath, file, imagesPath, cancellationToken);
            newFilesInfo.Add(fileInfo);
        }

        return newFilesInfo;
    }

    public async Task<FileInfo> UploadFile(string imagePath, IFormFile file, CancellationToken cancellationToken)
    {
        var imagesPath = Path.Combine(hostingEnvironment.WebRootPath, ImagesFolder, imagePath);

        if (!Directory.Exists(imagesPath))
            _ = Directory.CreateDirectory(imagesPath);

        return await SaveFile(imagePath, file, imagesPath, cancellationToken);
    }

    public void DeleteFiles(string path, string fileName)
    {
        var fullPath = Path.Combine(hostingEnvironment.WebRootPath, ImagesFolder, path, fileName);

        if (File.Exists(fullPath))
            File.Delete(fullPath);
    }

    private static async Task<FileInfo> SaveFile(string imagePath, IFormFile file, string imagesPath, CancellationToken cancellationToken)
    {
        var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
        var newFilePath = Path.Combine(imagesPath, newFileName);
        var fullPath = Path.Combine(ImagesFolder, imagePath, newFileName);

        await file.CopyToAsync(new FileStream(newFilePath, FileMode.CreateNew), cancellationToken);

        return new FileInfo(fullPath);
    }
}