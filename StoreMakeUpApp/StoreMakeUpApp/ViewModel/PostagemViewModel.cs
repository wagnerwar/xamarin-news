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
        private PostagemUsuario postagem;

        public PostagemUsuario Postagem
        {
            get { return postagem; }
            set
            {
                postagem = value;
            }
        }
        public PostagemViewModel(PostagemUsuario postagem, INavigation navigation)
        {
            _navigation = navigation;
            _service = new UsuarioService();
            this.Postagem = postagem;
        }
    }
}
