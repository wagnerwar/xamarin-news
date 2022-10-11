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
    public class PostagemViewModel : BaseViewModel
    {
        private INavigation _navigation { get; set; }
        private UsuarioService _service { get; set; }
        public ICommand IncluirComentariosCommand { get; set; }
        public ICommand ExibirComentariosCommand { get; set; }
        public ICommand FecharPostagemCommand { get; set; }
        private PostagemUsuario postagem;
        public PostagemUsuario Postagem
        {
            get { return postagem; }
            set
            {
                postagem = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<ComentarioPostagem> comentarios;
        public ObservableCollection<ComentarioPostagem> Comentarios
        {
            get { return comentarios; }
            set
            {
                comentarios = value;
                OnPropertyChanged();
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
        private bool incluirComentarios;
        public bool IsIncluirComentarios
        {
            get { return incluirComentarios; }
            set
            {
                incluirComentarios = value;
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
            IsIncluirComentarios = false;
            ExibirComentariosCommand = new Command(async () => await EventoExibirComentarios());
            FecharPostagemCommand = new Command(async () => await FecharPostagem());
            IncluirComentariosCommand = new Command(async () => await EventoIncluirComentarios());
        }
        private async Task EventoIncluirComentarios()
        {
            try
            {
                IsIncluirComentarios = true;
                IsExibirComentarios = false;
            }
            catch (Exception ex)
            {
                ExibirMensagemErro();
            }
        }
        private async Task EventoExibirComentarios()
        {
            try
            {
                IsLoading = true;
                IsExibirComentarios = false;
                var lista = await _service.BuscarComentariosPostagemAsync(postagem.Id);
                Comentarios.Clear();
                foreach(var item in lista)
                {
                    Comentarios.Add(item);
                }
                IsLoading = false;
                IsExibirComentarios = true;
                IsIncluirComentarios = false;
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
