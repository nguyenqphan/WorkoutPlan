using CommunityToolkit.Mvvm.Messaging.Messages;
using WorkoutPlan.Models;

namespace WorkoutPlan.Messages;

public class ExerciseAddedMessage : ValueChangedMessage<Exercise>
{
    public ExerciseAddedMessage(Exercise value) : base(value) { }
}
