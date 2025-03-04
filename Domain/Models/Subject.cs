namespace Domain.Models;

public class Subject : BaseModel
{
    public string Name { get; set; }
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}