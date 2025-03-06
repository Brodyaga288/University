using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Infrastructure.DTO;

public class StudentRequestDTO
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Description { get; set; }
    public IFormFile Photo { get; set; }
    public Guid GroupId { get; set; }
}