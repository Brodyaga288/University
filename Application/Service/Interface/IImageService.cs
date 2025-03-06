using Microsoft.AspNetCore.Http;

namespace Application.Service.Interface;

public interface IImageService
{
    public Task<string> ChangingImage( IFormFile file);
}