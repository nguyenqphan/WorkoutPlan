using WorkoutPlan.Views;

namespace WorkoutPlan;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register route for Create Plan page
        Routing.RegisterRoute("CreateExercisePlan", typeof(CreateExercisePlanPage));

        // Later you can register additional routes like:
        // Routing.RegisterRoute(nameof(PlanDetailsPage), typeof(PlanDetailsPage));
    }
}
