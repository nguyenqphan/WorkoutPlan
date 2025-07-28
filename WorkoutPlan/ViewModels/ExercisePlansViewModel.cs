using System.Collections.ObjectModel;
using System.Windows.Input;
using WorkoutPlan.Models;
using WorkoutPlan.Services;

namespace WorkoutPlan.ViewModels;

/// <summary>
/// ViewModel for listing and managing Exercise Plans.
/// </summary>
public class ExercisePlansViewModel : BaseViewModel
{
    private readonly IExercisePlanService _service;

    /// <summary>
    /// Collection of exercise plans displayed in the UI.
    /// </summary>
    public ObservableCollection<ExercisePlan> Plans { get; } = new();

    /// <summary>
    /// Command to navigate to the Create Plan page.
    /// </summary>
    public ICommand CreateNewCommand { get; }

    /// <summary>
    /// Command to load plans from the data source.
    /// </summary>
    public ICommand LoadPlansCommand { get; }

    public ExercisePlansViewModel()
    {
        // Resolve the in-memory service using static service provider
        _service = App.Services.GetService<IExercisePlanService>()
            ?? throw new Exception("ExercisePlanService not registered");

        // Bind the button to a method that will eventually navigate to a form
        CreateNewCommand = new Command(OnCreateNew);

        // Command to load plans asynchronously on page load
        LoadPlansCommand = new Command(async () => await LoadPlansAsync());

        // Load data on initialization
        LoadPlansCommand.Execute(null);
    }

    /// <summary>
    /// Load exercise plans from the in-memory service.
    /// </summary>
    private async Task LoadPlansAsync()
    {
        var plans = await _service.GetAllAsync();

        Plans.Clear();
        foreach (var plan in plans)
        {
            Plans.Add(plan);
        }
    }

    /// <summary>
    /// Triggered when user taps "New Plan" button.
    /// Will later navigate to the create plan page.
    /// </summary>
    private async void OnCreateNew()
    {
        await Shell.Current.GoToAsync("CreateExercisePlan");
    }
}
