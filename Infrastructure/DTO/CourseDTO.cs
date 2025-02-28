using System.Text.Json.Serialization;

namespace Infrastructure.DTO;

public class CourseDTO
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}