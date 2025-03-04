namespace Application.Service.Interface;

public interface IImageService
{
    public Task<string> ChangingImage(string imagePath);
}