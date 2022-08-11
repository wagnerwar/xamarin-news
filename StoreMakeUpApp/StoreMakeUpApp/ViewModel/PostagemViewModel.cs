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
    public class PostagemViewModel : BaseViewModel
    {
        private INavigation _navigation { get; set; }
        private UsuarioService _service { get; set; }
        public ICommand ExibirComentariosCommand { get; set; }
        public ICommand FecharPostagemCommand { get; set; }
        private PostagemUsuario postagem;
        public PostagemUsuario Postagem
        {
            get { return postagem; }
            set
            {
                postagem = value;
            }
        }
        private ObservableCollection<ComentarioPostagem> comentarios;
        public ObservableCollection<ComentarioPostagem> Comentarios
        {
            get { return comentarios; }
            set
            {
                comentarios = value;
            }
        }
        private bool exibirComentarios;
        public bool IsExibirComentarios
        {
            get { return exibirComentarios; }
            set
            {
                exibirComentarios = value;
                OnPropertyChanged();
            }
        }
        public PostagemViewModel(PostagemUsuario postagem, INavigation navigation)
        {
            _navigation = navigation;
            _service = new UsuarioService();
            this.Comentarios = new ObservableCollection<ComentarioPostagem>();
            this.Postagem = postagem;
            IsExibirComentarios = false;
            ExibirComentariosCommand = new Command(async () => await EventoExibirComentarios());
            FecharPostagemCommand = new Command(async () => await FecharPostagem());
        }
        private async Task EventoExibirComentarios()
        {
            try
            {
                IsLoading = true;                
                var lista = await _service.BuscarComentariosPostagemAsync(postagem.Id);
                Comentarios.Clear();
                foreach(var item in lista)
                {
                    Comentarios.Add(item);
                }
                IsLoading = false;
                IsExibirComentarios = true;
            }
            catch (Exception ex)
            {
                ExibirMensagemErro();
            }
        }
        private async Task FecharPostagem()
        {
            await _navigation.PopModalAsync();
        }
    }
}
