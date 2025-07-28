namespace WorkoutApp.Models;

/// <summary>
/// Represents a user's workout plan consisting of multiple exercises.
/// </summary>
public class WorkoutPlan
{
    /// <summary>
    /// Unique identifier for the workout plan.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Name of the workout plan (e.g., "Full Body Routine", "Push Day").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// A brief description of the workout plan.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Days of the week the workout plan should repeat (e.g., Mon, Wed, Fri).
    /// </summary>
    public List<DayOfWeek> RepeatDays { get; set; } = new();

    /// <summary>
    /// List of exercises included in this plan.
    /// </summary>
    public List<Exercise> Exercises { get; set; } = new();

    /// <summary>
    /// Date when the plan was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Flag to indicate if notifications are enabled for this plan.
    /// </summary>
    public bool NotificationsEnabled { get; set; } = false;

    /// <summary>
    /// Optional start time for the workout schedule (used for notifications).
    /// </summary>
    public TimeOnly? StartTime { get; set; }

    /// <summary>
    /// Optional image or icon associated with the plan.
    /// </summary>
    public string? CoverImagePath { get; set; }

    /// <summary>
    /// Total duration (cached or computed) of the entire workout (optional).
    /// </summary>
    public TimeSpan? EstimatedDuration { get; set; }

    /// <summary>
    /// Flag to favorite or highlight this plan.
    /// </summary>
    public bool IsFavorite { get; set; } = false;
}
