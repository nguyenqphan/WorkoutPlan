namespace WorkoutApp.Models;

public class Exercise
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public int Repetitions { get; set; }
    public int RestTimeSeconds { get; set; }  // Time to rest between sets
    public string? Notes { get; set; }

    // Optional: Order in the plan (for sorting)
    public int Order { get; set; }
}
