using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using StoreMakeUpApp.ViewModel;
namespace StoreMakeUpApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new ProdutoViewModel();
            //Assinando mensagens
            // Assinando mensagem
            MessagingCenter.Subscribe<MainPage>(this, "MensagemErro", (sender) =>
            {
                DisplayAlert("Erro no processamento", "Lascou-se", "OK");
            });
            MessagingCenter.Subscribe<MainPage, int>(this, "Detalhe", (sender, args) =>
            {
                Navigation.PushAsync(new DetalheUsuario(args));
            });
        }
    }
}
