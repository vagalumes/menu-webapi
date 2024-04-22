namespace Application.Shared.Services.Abstractions;

public interface IDeleteImagesService
{
    void DeleteFiles(string path, string fileName);
}