using System.Text.Json.Serialization;

namespace Infrastructure.DTO;

public class StudentDTO
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
    public Guid GroupId { get; set; }
}