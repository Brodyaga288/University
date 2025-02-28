namespace Domain.Models;

public class Group : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public ICollection<Student> Students { get; set; }
}