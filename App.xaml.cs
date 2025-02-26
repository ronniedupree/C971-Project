using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;
using RonaldDuPreeJr_C971.Models;
using RonaldDuPreeJr_C971.Services;

namespace RonaldDuPreeJr_C971
{
    public partial class App : Application
    {
        private readonly MauiAppBuilder _appBuilder;

        public App()
        {
            _appBuilder = MauiApp.CreateBuilder();
            ConfigureServices(_appBuilder.Services);
            InitializeComponent();

            // set up the database
            var db = new Database();
            db.Initialize();

            // create main page using database
            var mainPage = new MainPage(db);
            MainPage = new NavigationPage(mainPage);

            LocalNotificationCenter.Current.NotificationActionTapped += OnNotificationActionTapped;
        }

        protected override void OnStart()
        {
            base.OnStart();
            // call Notifications when the application starts
            DataHelper.Notifications();
        }

        private static void OnNotificationActionTapped(NotificationActionEventArgs e)
        {
            if (e.IsDismissed)
            {
                return;
            }
            if (e.IsTapped) { }
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Database>();
        }
    }
}