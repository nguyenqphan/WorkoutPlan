using WorkoutPlan.Models;

namespace WorkoutPlan.Services;

/// <summary>
/// In-memory implementation of IExercisePlanService with async support.
/// </summary>
public class ExercisePlanService : IExercisePlanService
{
    private readonly List<ExercisePlan> _plans = new();

    public async Task<List<ExercisePlan>> GetAllAsync()
    {
        await Task.Delay(10); // simulate async delay
        return _plans.ToList();
    }

    public async Task<ExercisePlan?> GetByIdAsync(Guid id)
    {
        await Task.Delay(10); // simulate async delay
        return _plans.FirstOrDefault(p => p.Id == id);
    }

    public async Task AddAsync(ExercisePlan plan)
    {
        await Task.Delay(10); // simulate async delay
        _plans.Add(plan);
    }

    public async Task UpdateAsync(ExercisePlan plan)
    {
        await Task.Delay(10); // simulate async delay

        var index = _plans.FindIndex(p => p.Id == plan.Id);
        if (index >= 0)
        {
            _plans[index] = plan;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        await Task.Delay(10); // simulate async delay

        var plan = _plans.FirstOrDefault(p => p.Id == id);
        if (plan != null)
        {
            _plans.Remove(plan);
        }
    }
}
