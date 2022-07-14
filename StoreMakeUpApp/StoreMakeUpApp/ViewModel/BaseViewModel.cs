using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StoreMakeUpApp.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        protected void ExibirMensagemErro()
        {
            IsLoading = false;
            MessagingCenter.Send<MainPage>(new MainPage(), "MensagemErro");
        }
    }
}
