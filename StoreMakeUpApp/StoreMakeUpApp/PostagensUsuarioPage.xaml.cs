using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StoreMakeUpApp.ViewModel;
using StoreMakeUpApp.Model;
namespace StoreMakeUpApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostagensUsuarioPage : ContentPage
    {
        public PostagensUsuarioPage(int id)
        {
            InitializeComponent();
            this.BindingContext = new PostagensViewModel(id, Navigation);
        }
        private async void OpenPickerCommand(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var detalhes = e.Item as PostagemUsuario;
                await Navigation.PushAsync(new PostagemUsuarioPage(detalhes));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}