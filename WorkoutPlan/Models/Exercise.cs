namespace WorkoutApp.Models;

/// <summary>
/// Represents an individual exercise in a workout plan.
/// </summary>
public class Exercise
{
    /// <summary>
    /// Unique identifier for the exercise.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Name of the exercise (e.g., "Push-ups", "Squats").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Number of sets to perform for the exercise.
    /// </summary>
    public int Sets { get; set; }

    /// <summary>
    /// Number of repetitions per set.
    /// </summary>
    public int Repetitions { get; set; }

    /// <summary>
    /// Rest time in seconds between each set.
    /// </summary>
    public int RestTimeSeconds { get; set; }

    /// <summary>
    /// Duration in seconds for time-based exercises (e.g., Plank).
    /// Leave null for rep-based exercises.
    /// </summary>
    public int? DurationSeconds { get; set; }

    /// <summary>
    /// Additional notes or instructions (e.g., "Use dumbbells").
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Order of this exercise in the workout plan.
    /// Useful for sorting/display purposes.
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Targeted muscle group (e.g., "Chest", "Legs").
    /// Useful for filtering or recommendations.
    /// </summary>
    public string? TargetMuscleGroup { get; set; }

    /// <summary>
    /// Equipment needed to perform the exercise (e.g., "None", "Dumbbells").
    /// </summary>
    public string? EquipmentNeeded { get; set; }

    /// <summary>
    /// A media reference (e.g., image or video URL or local path) for instructional purposes.
    /// </summary>
    public string? MediaReference { get; set; }

    /// <summary>
    /// Flag to indicate if this is a favorite exercise for the user.
    /// </summary>
    public bool IsFavorite { get; set; } = false;

    /// <summary>
    /// Optional color tag for UI categorization or styling.
    /// </summary>
    public string? ColorTag { get; set; }

    /// <summary>
    /// Optional icon name or file path to visually represent the exercise.
    /// </summary>
    public string? Icon { get; set; }
}
