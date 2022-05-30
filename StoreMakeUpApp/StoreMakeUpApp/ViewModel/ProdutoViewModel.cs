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
    public class ProdutoViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private ProdutoService _service { get; set; }
        public ICommand CarregarProdutosCommand { get; set; }
        public ICommand CarregarProdutoCommand { get; set; }
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
        private Produto _produto;
        public Produto Produto
        {
            get
            {
                return this._produto;
            }
            set
            {
                this._produto = value;
                OnPropertyChanged();
            }
        }
        public ProdutoViewModel()
        {
            _navigationService = App._navigationService;
            _service = new ProdutoService();
            CarregarProdutosCommand = new Command(async () => await CarregarProdutos());
            CarregarProdutoCommand = new Command<Produto>( async(produto) => await CarregarProduto(produto) );
            IsLoading = false;
            Items = new ObservableCollection<Produto>();
        }
        private async Task CarregarProdutos()
        {
            try
            {
                IsLoading = true;
                Items.Clear();
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
        private async Task CarregarProduto(Produto produto)
        {
            try
            {
                // Redirecionar para outra tela
                await NavegacaoDetalheAsync(produto.id);
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

        private async Task NavegacaoDetalheAsync(int id)
        {
            await _navigationService.NavigateAsync("DetalheUsuarioPage", id, true);
        }
        
    }
}
