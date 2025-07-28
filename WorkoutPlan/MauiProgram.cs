using Microsoft.Extensions.Logging;
using WorkoutPlan;
using WorkoutPlan.Services;

namespace WorkoutPlan
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IExercisePlanService, ExercisePlanService>();
      
            var app = builder.Build();
            App.InitServices(app.Services);
            return app;
        }
    }
}
