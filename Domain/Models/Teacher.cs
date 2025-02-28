namespace Domain.Models;

public class Teacher : BaseModel
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string AcademicDegree { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
    public ICollection<Subject> Subjects { get; set; }
}