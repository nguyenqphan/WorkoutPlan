namespace WorkoutPlan.Views;

public partial class ExercisePlansPage : ContentPage
{
    public static IServiceProvider Services { get; private set; }
    public ExercisePlansPage()
	{
		InitializeComponent();
	
	}

    public static void InitServices(IServiceProvider serviceProvider)
    {
        Services = serviceProvider;
    }
}