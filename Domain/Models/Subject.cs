namespace Domain.Models;

public class Subject : BaseModel
{
    public string Name { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}