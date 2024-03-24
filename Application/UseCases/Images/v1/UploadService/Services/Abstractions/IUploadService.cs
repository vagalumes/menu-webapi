using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Images.v1.UploadService.Services.Abstractions
{
    public interface IUploadService
    {
        Task<IEnumerable<FileInfo>> UploadFiles(string imagePath, IEnumerable<IFormFile> files,
            CancellationToken cancellationToken);
    }
}
