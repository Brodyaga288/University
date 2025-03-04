using System.Text.Json.Serialization;

namespace Infrastructure.DTO;

public class GroupDTO
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CourseId { get; set; }
    public Guid TeacherId { get; set; }
}