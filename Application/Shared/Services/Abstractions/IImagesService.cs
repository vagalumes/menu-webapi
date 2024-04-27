using Microsoft.AspNetCore.Http;

namespace Application.Shared.Services.Abstractions;

public interface IImagesService
{
    Task<IEnumerable<FileInfo>> UploadFiles(string imagePath, IEnumerable<IFormFile> files, CancellationToken cancellationToken);

    Task<FileInfo> UploadFile(string imagePath, IFormFile file, CancellationToken cancellationToken);

    void DeleteFiles(string path, string fileName);
}