namespace Application.UseCases.Images.v1.CreateUsersImageUseCase.Abstractions
{
    public interface IOutputPort
    {
        void UserNotFound();
        void ImageSaved();
    }
}
