using Microsoft.AspNetCore.Http;

namespace Application.Shared.Services.Abstractions;

public interface IImagesService
{
    Task<IEnumerable<FileInfo>> UploadFiles(string imagePath, IEnumerable<IFormFile> files,
        CancellationToken cancellationToken);

    void DeleteFiles(string path, string fileName);
}