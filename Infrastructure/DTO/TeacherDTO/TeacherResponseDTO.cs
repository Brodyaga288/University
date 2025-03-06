using System.Text.Json.Serialization;

namespace Infrastructure.DTO;

public class TeacherResponseDTO
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string AcademicDegree { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
}