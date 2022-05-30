using System;
using System.Collections.Generic;
using System.Text;
using StoreMakeUpApp.Model;
using Xamarin.Forms;
using StoreMakeUpApp.Service;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using StoreMakeUpApp.Interfaces;

namespace StoreMakeUpApp.ViewModel
{
    public class DetalheViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private ProdutoService _service { get; set; }
        public DetalheViewModel(int id)
        {
            _navigationService = App._navigationService;
        }
    }
}
