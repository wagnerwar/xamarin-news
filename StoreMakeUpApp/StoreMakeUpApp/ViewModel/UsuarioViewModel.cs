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
    public class UsuarioViewModel : BaseViewModel
    {
        private INavigation _navigation { get; set; }
        private UsuarioService _service { get; set; }
        public ICommand CarregarUsuariosCommand { get; set; }
        public ICommand CarregarUsuarioCommand { get; set; }
        private ObservableCollection<Usuario> items;
        public ObservableCollection<Usuario> Items
        {
            get { return items; }
            set
            {
                items = value;
            }
        }
        
        private Usuario _usuario;
        public Usuario Usuario
        {
            get
            {
                return this._usuario;
            }
            set
            {
                this._usuario = value;
                OnPropertyChanged();
            }
        }
        public UsuarioViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _service = new UsuarioService();
            CarregarUsuariosCommand = new Command(async () => await CarregarUsuarios());
            CarregarUsuarioCommand = new Command<Usuario>( async(usuario) => await CarregarUsuario(usuario) );
            IsLoading = false;
            Items = new ObservableCollection<Usuario>();
        }
        private async Task CarregarUsuarios()
        {
            try
            {
                IsLoading = true;
                Items.Clear();
                var usuarios =  await _service.RecuperarUsuariosAsync();
                if(usuarios != null)
                {
                    foreach(var p in usuarios)
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
        private async Task CarregarUsuario(Usuario usuario)
        {
            try
            {
                // Redirecionar para outra tela
                await NavegacaoDetalheAsync(usuario.id);
            }
            catch (Exception ex)
            {
                ExibirMensagemErro();
            }
        }        
        private async Task NavegacaoDetalheAsync(int id)
        {
            await _navigation.PushAsync(new DetalheUsuarioPage(id), true);
        }
        
    }
}
