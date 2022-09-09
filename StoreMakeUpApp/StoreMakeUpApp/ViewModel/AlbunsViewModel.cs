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
    public class AlbunsViewModel : BaseViewModel
    {
        public ICommand CarregarFotosCommand { get; set; }
        private Usuario usuario;
        public Usuario Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
            }
        }
        private INavigation _navigation { get; set; }
        private UsuarioService _service { get; set; }
        private ObservableCollection<AlbumUsuario> items;
        public ObservableCollection<AlbumUsuario> Items
        {
            get { return items; }
            set
            {
                items = value;
            }
        }
        public AlbunsViewModel(int id, INavigation navigation)
        {
            _navigation = navigation;
            _service = new UsuarioService();
            IsLoading = true;
            Items = new ObservableCollection<AlbumUsuario>();
            var t = Task.Run(() => this.CarregarAlbuns(id));
            CarregarFotosCommand = new Command<AlbumUsuario>(async (album) => await CarregarFotos(album));
            t.Wait();
        }
        private async Task CarregarAlbuns(int id)
        {
            try
            {
                Usuario = await _service.CarregarUsuarioAsync(id);
                List<AlbumUsuario> dados = await _service.BuscarAlbunsUsuarioAsync(id);
                foreach (var d in dados)
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
        private async Task CarregarFotos(AlbumUsuario album)
        {
            try
            {
                await _navigation.PushAsync(new FotosAlbumPage(album), true);
            }
            catch (Exception ex)
            {
                ExibirMensagemErro();
            }
        }
    }
}
