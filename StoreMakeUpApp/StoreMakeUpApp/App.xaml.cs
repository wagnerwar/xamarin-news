using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StoreMakeUpApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            /*var imagem = new Image
            {
                Source = "logo.png",
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Fill
            };*/
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
