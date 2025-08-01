namespace WorkoutPlan;

public partial class App : Application
{
    public static IServiceProvider Services { get; private set; }
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    public static void InitServices(IServiceProvider serviceProvider)
    {
        Services = serviceProvider;
    }
}
