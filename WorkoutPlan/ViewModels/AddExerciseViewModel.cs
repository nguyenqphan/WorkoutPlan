using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using WorkoutPlan.Messages;
using WorkoutPlan.Models;

namespace WorkoutPlan.ViewModels;

/// <summary>
/// ViewModel for adding a new Exercise to a workout plan via a modal page.
/// </summary>
public class AddExerciseViewModel : BaseViewModel
{
    // -----------------------------
    // Form-bound properties
    // These bind to the UI input fields in AddExercisePage.xaml
    // -----------------------------

    /// <summary>
    /// Name of the exercise (e.g., "Push-ups").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Number of sets to perform.
    /// Bound as text to Entry; will be parsed to int.
    /// </summary>
    public string Sets { get; set; } = "3";

    /// <summary>
    /// Number of repetitions per set.
    /// </summary>
    public string Repetitions { get; set; } = "10";

    /// <summary>
    /// Rest time between sets in seconds.
    /// </summary>
    public string RestTimeSeconds { get; set; } = "60";

    /// <summary>
    /// Optional notes for the exercise.
    /// </summary>
    public string? Notes { get; set; }

    // -----------------------------
    // Commands bound to the Save and Cancel buttons
    // -----------------------------
    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    /// <summary>
    /// Constructor sets up the commands.
    /// </summary>
    public AddExerciseViewModel()
    {
        SaveCommand = new Command(async () => await SaveAsync());
        CancelCommand = new Command(async () => await CloseAsync());
    }

    /// <summary>
    /// Called when the Save button is tapped.
    /// Validates and sends the new Exercise to the parent view via Messenger.
    /// </summary>
    private async Task SaveAsync()
    {
        // Basic validation: ensure Name is not empty
        if (string.IsNullOrWhiteSpace(Name))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Please enter a name.", "OK");
            return;
        }

        // Build the new Exercise object from the form inputs
        var newExercise = new Exercise
        {
            Name = Name,
            Sets = int.TryParse(Sets, out var sets) ? sets : 3,
            Repetitions = int.TryParse(Repetitions, out var reps) ? reps : 10,
            RestTimeSeconds = int.TryParse(RestTimeSeconds, out var rest) ? rest : 60,
            Notes = Notes
        };

        // Send the exercise to any registered listeners using CommunityToolkit.Mvvm.Messaging
        WeakReferenceMessenger.Default.Send(new ExerciseAddedMessage(newExercise));

        // Close the modal after sending
        await CloseAsync();
    }

    /// <summary>
    /// Called when the Cancel button is tapped.
    /// Dismisses the modal page without doing anything.
    /// </summary>
    private async Task CloseAsync()
    {
        await Shell.Current.Navigation.PopModalAsync();
    }
}
