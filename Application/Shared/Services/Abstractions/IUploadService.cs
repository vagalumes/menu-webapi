using Microsoft.AspNetCore.Http;

namespace Application.Shared.Services.Abstractions
{
    public interface IUploadService
    {
        Task<IEnumerable<FileInfo>> UploadFiles(string imagePath, IEnumerable<IFormFile> files,
            CancellationToken cancellationToken);
    }
}
