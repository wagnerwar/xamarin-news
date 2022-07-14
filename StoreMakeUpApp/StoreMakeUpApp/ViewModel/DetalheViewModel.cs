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
        private INavigation _navigation { get; set; }
        private UsuarioService _service { get; set; }
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
        public  DetalheViewModel(int id, INavigation navigation)
        {
            _navigation = navigation;
            _service = new UsuarioService();
            IsLoading = true;
            var t = Task.Run(() => this.CarregarUsuario(id));
            t.Wait();
        }
        private async Task CarregarUsuario(int id)
        {
            try
            {
                Usuario dados = await _service.CarregarUsuarioAsync(id);
                Usuario = dados;
                IsLoading = false;
            }
            catch (Exception ex)
            {
                ExibirMensagemErro();
                IsLoading = false;
            }
        }
    }
}
