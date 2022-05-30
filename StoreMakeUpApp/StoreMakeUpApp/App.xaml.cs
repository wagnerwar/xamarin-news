using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StoreMakeUpApp.Interfaces;
using StoreMakeUpApp.Service;
namespace StoreMakeUpApp
{
    public partial class App : Application
    {
        public static INavigationService _navigationService { get; } = new ViewNavigationService();
        public App()
        {
            InitializeComponent();
            // Implementando navegação
            _navigationService.Configure("MainPage", typeof(MainPage));
            _navigationService.Configure("DetalheUsuarioPage", typeof(DetalheUsuarioPage));
            var mainPage = ((ViewNavigationService)_navigationService).SetRootPage("MainPage");
            MainPage = new MainPage();            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
