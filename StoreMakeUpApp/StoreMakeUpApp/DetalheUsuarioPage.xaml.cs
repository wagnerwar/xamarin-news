using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StoreMakeUpApp.ViewModel;
namespace StoreMakeUpApp
{
    public partial class DetalheUsuarioPage : ContentPage
    {
        public DetalheUsuarioPage(int id)
        {
            InitializeComponent();
            this.BindingContext = new DetalheViewModel(id, Navigation);
        }
    }
}