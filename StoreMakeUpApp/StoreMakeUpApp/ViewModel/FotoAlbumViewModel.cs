﻿using System;
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
    public class FotoAlbumViewModel : BaseViewModel
    {
        private INavigation _navigation { get; set; }
        private UsuarioService _service { get; set; }
        private ObservableCollection<FotoAlbum> items;
        public ObservableCollection<FotoAlbum> Items
        {
            get { return items; }
            set
            {
                items = value;
            }
        }
        private async Task CarregarFotos(AlbumUsuario album)
        {
            try
            {
                var lista = await _service.BuscarFotosAlbumAsync(album.Id);
                foreach(var i in lista)
                {
                    Items.Add(i);
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                ExibirMensagemErro();
            }
        }
        public FotoAlbumViewModel(AlbumUsuario album, INavigation navigation)
        {
            _navigation = navigation;
            _service = new UsuarioService();
            IsLoading = true;
            Items = new ObservableCollection<FotoAlbum>();
            var t = Task.Run(() => this.CarregarFotos(album));
            t.Wait();
        }
    }
}
