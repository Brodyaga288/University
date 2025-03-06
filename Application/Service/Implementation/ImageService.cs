using Application.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Service.Implementation;

public class ImageService : IImageService
{
    private readonly HttpClient _httpClient;

    public ImageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<string> ChangingImage(IFormFile file)
    {
        try
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            var savePath = $"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent}\\src\\Images";
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);
            
            var filePath = Path.Combine(savePath, fileName);
            
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            
            var savedUrl = $"{savePath}\\{fileName}";
            return savedUrl;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при сохранении изображения: {ex.Message}");
        }
    }
}