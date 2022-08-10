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
    public partial class PostagemUsuarioPage : ContentPage
    {
        public PostagemUsuarioPage(PostagemUsuario postagem)
        {
            InitializeComponent();
            this.BindingContext = new PostagemViewModel(postagem, Navigation);
        }
    }
}