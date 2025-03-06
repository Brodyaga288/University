using System.Text.Json.Serialization;

namespace Infrastructure.DTO;

public class SubjectDTO
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid TeacherId { get; set; }
}