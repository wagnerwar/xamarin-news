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
        private PostagemUsuario postagem;
        public PostagemUsuario Postagem
        {
            get { return postagem; }
            set
            {
                postagem = value;
            }
        }
        private bool exibirComentarios;
        public bool IsExibirComentarios
        {
            get { return exibirComentarios; }
            set
            {
                exibirComentarios = value;
            }
        }
        public PostagemViewModel(PostagemUsuario postagem, INavigation navigation)
        {
            _navigation = navigation;
            _service = new UsuarioService();
            postagem.Comentarios = new List<ComentarioPostagem>();
            this.Postagem = postagem;
            IsExibirComentarios = false;
            ExibirComentariosCommand = new Command(async () => await EventoExibirComentarios());            
        }
        private async Task EventoExibirComentarios()
        {
            try
            {
                //IsLoading = true;                
                //Postagem.Comentarios = await _service.BuscarComentariosPostagemAsync(postagem.Id);
                //IsLoading = false;
                IsExibirComentarios = true;
            }
            catch (Exception ex)
            {
                ExibirMensagemErro();
            }
        }
    }
}
