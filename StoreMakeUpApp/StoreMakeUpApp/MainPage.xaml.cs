using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using StoreMakeUpApp.ViewModel;
using StoreMakeUpApp.Interfaces;

namespace StoreMakeUpApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new UsuarioViewModel(Navigation);
            //Assinando mensagens
            // Assinando mensagem
            MessagingCenter.Subscribe<MainPage>(this, "MensagemErro", (sender) =>
            {
                DisplayAlert("Erro no processamento", "Lascou-se", "OK");
            });
            /*MessagingCenter.Subscribe<MainPage, int>(this, "Detalhe", async (sender, args) =>
            {
                await Navigation.PushAsync(new DetalheUsuarioPage(args), true);
            });*/
        }
    }
}
