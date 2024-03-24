namespace Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Abstractions
{
    public interface IOutputPort
    {
        void ImagesSaved(IEnumerable<FileInfo> filesInfos);
        void RestaurantNotFound();
    }
}
