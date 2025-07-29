using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WorkoutPlan.Messages;
using WorkoutPlan.Models;
using WorkoutPlan.Services;
using WorkoutPlan.Views;

namespace WorkoutPlan.ViewModels;

public class CreateExercisePlanViewModel : BaseViewModel
{
    private readonly IExercisePlanService _service;
    public ObservableCollection<Exercise> Exercises { get; set; } = new();

    public ICommand AddExerciseCommand { get; }
    public ICommand DeleteExerciseCommand { get; }

    public CreateExercisePlanViewModel()
    {
        _service = App.Services.GetService<IExercisePlanService>()
            ?? throw new Exception("ExercisePlanService not available");

        // Initialize repeat days (7 bools for Sun-Sat)
        RepeatDays = new ObservableCollection<bool>(new bool[7]);

        SaveCommand = new Command(async () => await SaveAsync());

        AddExerciseCommand = new Command(OnAddExercise);
        DeleteExerciseCommand = new Command<Exercise>(OnDeleteExercise);

        // Register to receive messages when an exercise is added
        WeakReferenceMessenger.Default.Register<ExerciseAddedMessage>(this, (r, m) =>
        {
            Exercises.Add(m.Value);
        });
    }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TimeSpan StartTime { get; set; } = TimeSpan.FromHours(6); // Default to 6:00 AM
    public bool NotificationsEnabled { get; set; }

    public ObservableCollection<bool> RepeatDays { get; set; }

    public ICommand SaveCommand { get; }

    private async Task SaveAsync()
    {
        var plan = new ExercisePlan
        {
            Name = Name,
            Description = Description,
            StartTime = TimeOnly.FromTimeSpan(StartTime),
            NotificationsEnabled = NotificationsEnabled,
            RepeatDays = RepeatDays
                .Select((isSelected, i) => (isSelected, day: (DayOfWeek)i))
                .Where(x => x.isSelected)
                .Select(x => x.day)
                .ToList()
        };

        await _service.AddAsync(plan);

        await Application.Current.MainPage.DisplayAlert("Success", "Plan saved!", "OK");


        // Optionally navigate back or clear form
    }

    private async void OnAddExercise()
    {
        await Shell.Current.Navigation.PushModalAsync(new AddExercisePage());
    }

    private void OnDeleteExercise(Exercise exercise)
    {
        if (Exercises.Contains(exercise))
            Exercises.Remove(exercise);
    }
}
