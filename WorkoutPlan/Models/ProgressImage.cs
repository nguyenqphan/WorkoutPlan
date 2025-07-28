namespace WorkoutApp.Models;

public class ProgressImage
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ImagePath { get; set; } = string.Empty;
    public DateTime TakenOn { get; set; } = DateTime.UtcNow;
}
