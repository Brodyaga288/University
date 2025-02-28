namespace Domain.Models;

public class Student : BaseModel
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Description { get; set; }
    public string PhotoUrl { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
}