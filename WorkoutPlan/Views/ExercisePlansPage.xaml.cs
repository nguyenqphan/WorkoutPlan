using WorkoutPlan.ViewModels;

namespace WorkoutPlan.Views
{
    public partial class ExercisePlansPage : ContentPage
    {
        public ExercisePlansPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the page appears (including after returning from another page),
        /// this method ensures that the plans list is reloaded.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Safely cast the BindingContext to your ViewModel
            if (BindingContext is ExercisePlansViewModel vm)
            {
                // Run the command to reload the list of plans
                vm.LoadPlansCommand.Execute(null);
            }
        }

        /// <summary>
        /// Called when navigating away from the page.
        /// Reserved for unsubscribing from events if needed.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // Example: if you used MessagingCenter, you could unsubscribe here
        }
    }
}
