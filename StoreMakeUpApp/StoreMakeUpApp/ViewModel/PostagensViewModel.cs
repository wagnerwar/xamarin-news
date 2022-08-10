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
    public class PostagensViewModel : BaseViewModel
    {
        public ICommand CarregarDetalheCommand { get; set; }
        private INavigation _navigation { get; set; }
        private UsuarioService _service { get; set; }
        private ObservableCollection<PostagemUsuario> items;
        public ObservableCollection<PostagemUsuario> Items
        {
            get { return items; }
            set
            {
                items = value;
            }
        }
        private Usuario usuario;
        public Usuario Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
            }
        }
        public PostagensViewModel(int id, INavigation navigation)
        {
            _navigation = navigation;
            _service = new UsuarioService();
            IsLoading = true;
            Items = new ObservableCollection<PostagemUsuario>();
            CarregarDetalheCommand = new Command<PostagemUsuario>(async (postagem) => await CarregarDetalhe(postagem));
            var t = Task.Run(() => this.CarregarPostagens(id));
            t.Wait();
        }
        private async Task CarregarPostagens(int id)
        {
            try
            {
                Usuario = await _service.CarregarUsuarioAsync(id);
                List<PostagemUsuario> dados = await _service.PesquisarPostagensUsuarioAsync(id);
                foreach(var d in dados)
                {
                    Items.Add(d);
                }                
                IsLoading = false;
            }
            catch (Exception ex)
            {
                ExibirMensagemErro();
                IsLoading = false;
            }
        }
        private async Task CarregarDetalhe(PostagemUsuario postagem)
        {
            try
            {
                await _navigation.PushModalAsync(new PostagemUsuarioPage(postagem), true);
            }
            catch (Exception ex)
            {
                ExibirMensagemErro();
            }
        }
    }
}
