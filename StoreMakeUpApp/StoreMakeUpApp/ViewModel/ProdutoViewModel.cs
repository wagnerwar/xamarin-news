using System;
using System.Collections.Generic;
using System.Text;
using StoreMakeUpApp.Model;
using Xamarin.Forms;
using StoreMakeUpApp.Service;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StoreMakeUpApp.ViewModel
{
    public class ProdutoViewModel : BaseViewModel
    {
        private ProdutoService _service { get; set; }
        public ICommand CarregarProdutosCommand { get; set; }
        public IList<Produto> Produtos { get; set; }
        public bool Loading { get; set; }
        public ProdutoViewModel()
        {
            _service = new ProdutoService();
            CarregarProdutosCommand = new Command(async () => await CarregarProdutos());
            Loading = true;
            //CarregarProdutosCommand.Execute("teste");
        }
        private async Task CarregarProdutos()
        {
            try
            {
                Loading = true;
                Produtos = await _service.RecuperarProdutosAsync();
                Loading = false;
                OnPropertyChanged();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
