using Application.Service.Interface;
using Microsoft.AspNetCore.Hosting;

namespace Application.Service.Implementation;

public class ImageService : IImageService
{
    private readonly HttpClient _httpClient;

    public ImageService(HttpClient httpClient, IWebHostEnvironment env)
    {
        _httpClient = httpClient;
    }
    public async Task<string> ChangingImage(string imageUrl)
    {
        try
        {
            var response = await _httpClient.GetAsync(imageUrl);
            if (!response.IsSuccessStatusCode)
                throw new Exception("Не удалось загрузить изображение");

            await using var imageStream = await response.Content.ReadAsStreamAsync();
            
            var fileExtension = Path.GetExtension(imageUrl).ToLower();
            var fileName = $"{Guid.NewGuid()}{fileExtension}";

            var savePath = $"{Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.Parent}\\src\\Images";
            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);
            
            var filePath = Path.Combine(savePath, fileName);
            
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await imageStream.CopyToAsync(fileStream);
            
            var savedUrl = $"{savePath}\\{fileName}";
            return savedUrl;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка при сохранении изображения: {ex.Message}");
        }
    }
}