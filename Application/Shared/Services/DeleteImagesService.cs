using Application.Shared.Services.Abstractions;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Application.Shared.Services;

public class DeleteImagesService(IHostingEnvironment hostingEnvironment) : IDeleteImagesService
{
    public void DeleteFiles(string path, string fileName)
    {
        var fullPath = Path.Combine(hostingEnvironment.WebRootPath, "images", path, fileName);

        if (File.Exists(fullPath))
            File.Delete(fullPath);
    }
}