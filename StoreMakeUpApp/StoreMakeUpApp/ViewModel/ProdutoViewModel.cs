using System;
using System.Collections.Generic;
using System.Text;
using StoreMakeUpApp.Model;
using Xamarin.Forms;
using StoreMakeUpApp.Service;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace StoreMakeUpApp.ViewModel
{
    public class ProdutoViewModel : BaseViewModel
    {
        private ProdutoService _service { get; set; }
        public ICommand CarregarProdutosCommand { get; set; }        
        private ObservableCollection<Produto> items;
        public ObservableCollection<Produto> Items
        {
            get { return items; }
            set
            {
                items = value;
            }
        }
        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return this._isLoading;
            }
            set
            {
                this._isLoading = value;
                OnPropertyChanged();
            }
        }
        public ProdutoViewModel()
        {
            _service = new ProdutoService();
            CarregarProdutosCommand = new Command(async () => await CarregarProdutos());
            IsLoading = false;
            Items = new ObservableCollection<Produto>();
        }
        private async Task CarregarProdutos()
        {
            try
            {
                IsLoading = true;
                Items.Clear();
                await Task.Delay(3000);
                var produtos =  await _service.RecuperarProdutosAsync();
                if(produtos != null)
                {
                    foreach(var p in produtos)
                    {
                        Items.Add(p);
                    }
                }                
                IsLoading = false;
            }
            catch (Exception ex)
            {
                ExibirMensagemErro();
            }
        }
        private void ExibirMensagemErro()
        {
            IsLoading = false;
            MessagingCenter.Send<MainPage>(new MainPage(), "MensagemErro");
        }
        
    }
}
