namespace WorkoutApp.Models;

public class WorkoutPlan
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;

    // Repeat Days (e.g., [Mon, Wed, Fri])
    public List<DayOfWeek> RepeatDays { get; set; } = new();

    // List of Exercises in this plan
    public List<Exercise> Exercises { get; set; } = new();

    // Date when the plan was created
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
