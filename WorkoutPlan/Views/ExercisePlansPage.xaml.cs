using WorkoutPlan.ViewModels;

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

    //reload plans when the page appears, so it has the latest data after creating a new plan
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ExercisePlansViewModel vm)
        {
            vm.LoadPlansCommand.Execute(null);
        }
    }
}