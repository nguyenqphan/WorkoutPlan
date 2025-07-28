
using WorkoutPlan.Models;

namespace WorkoutPlan.Services;

/// <summary>
/// Interface for managing ExercisePlan data.
/// </summary>
public interface IExercisePlanService
{
    Task<List<ExercisePlan>> GetAllAsync();
    Task<ExercisePlan?> GetByIdAsync(Guid id);
    Task AddAsync(ExercisePlan plan);
    Task UpdateAsync(ExercisePlan plan);
    Task DeleteAsync(Guid id);
}
