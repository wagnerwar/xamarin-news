using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using StoreMakeUpApp.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.ObjectModel;
namespace StoreMakeUpApp.Service
{
    public class UsuarioService
    {
        //private String urlServico = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=covergirl&product_type=lipstick";
        private String urlServico = "https://jsonplaceholder.typicode.com/users/";
        private String acaoPesquisarUsuario = "https://jsonplaceholder.typicode.com/users/?username={0}";
        private String acaoPostagensUsuario = "https://jsonplaceholder.typicode.com/posts/?userId={0}";
        private String acaoComentariosPostagem = "https://jsonplaceholder.typicode.com/comments?postId={0}";
        private String acaoAlbunsUsuarioPostagem = "https://jsonplaceholder.typicode.com/albums?userId={0}";
        private String acaoFotosAlbum = "https://jsonplaceholder.typicode.com/albums/{0}/photos";
        private String acaoGravarComentarioPostagem = "https://jsonplaceholder.typicode.com/comments/";
        HttpClient client;
        public UsuarioService()
        {
            client = new HttpClient();
        }
        public async Task<List<Usuario>> RecuperarUsuariosAsync()
        {
            Uri uri = new Uri(string.Format(urlServico, string.Empty));
            List<Usuario> retorno = new List<Usuario>();
            try
            {               
                string response = await client.GetStringAsync(uri);      
                retorno = JsonConvert.DeserializeObject<List<Usuario>>(response);
                return retorno;
            }
            catch(JsonException jsException)
            {
                throw new Exception(jsException.Message);
            }
            catch(Exception ex)
            {
                String erro = ex.Message;
                throw ex;
            }            
        }
        public async Task<Usuario> CarregarUsuarioAsync(int id)
        {
            Uri uri = new Uri(string.Format(urlServico, string.Empty));
            Usuario retorno = new Usuario();
            try
            {
                string response = await client.GetStringAsync(String.Format(uri + "{0}", id ));
                retorno = JsonConvert.DeserializeObject<Usuario>(response);
                return retorno;
            }
            catch (JsonException jsException)
            {
                throw new Exception(jsException.Message);
            }
            catch (Exception ex)
            {
                String erro = ex.Message;
                throw ex;
            }
        }
        public async Task<List<Usuario>> PesquisarUsuarioAsync(String nome)
        {
            Uri uri = new Uri(string.Format(acaoPesquisarUsuario, nome));
            List<Usuario> retorno = new List<Usuario>();
            try
            {
                string response = await client.GetStringAsync(uri);
                retorno = JsonConvert.DeserializeObject<List<Usuario>>(response);
                return retorno;
            }
            catch (JsonException jsException)
            {
                throw new Exception(jsException.Message);
            }
            catch (Exception ex)
            {
                String erro = ex.Message;
                throw ex;
            }
        }
        public async Task<List<PostagemUsuario>> PesquisarPostagensUsuarioAsync(int id)
        {
            Uri uri = new Uri(string.Format(acaoPostagensUsuario, id));
            List<PostagemUsuario> retorno = new List<PostagemUsuario>();
            try
            {
                string response = await client.GetStringAsync(uri);
                retorno = JsonConvert.DeserializeObject<List<PostagemUsuario>>(response);
                return retorno;
            }
            catch (JsonException jsException)
            {
                throw new Exception(jsException.Message);
            }
            catch (Exception ex)
            {
                String erro = ex.Message;
                throw ex;
            }
        }
        public async Task<List<AlbumUsuario>> BuscarAlbunsUsuarioAsync(int id)
        {
            Uri uri = new Uri(string.Format(acaoAlbunsUsuarioPostagem, id));
            List<AlbumUsuario> retorno = new List<AlbumUsuario>();
            try
            {
                string response = await client.GetStringAsync(uri);
                retorno = JsonConvert.DeserializeObject<List<AlbumUsuario>>(response);
                return retorno;
            }
            catch (JsonException jsException)
            {
                throw new Exception(jsException.Message);
            }
            catch (Exception ex)
            {
                String erro = ex.Message;
                throw ex;
            }
        }
        public async Task<List<ComentarioPostagem>> BuscarComentariosPostagemAsync(int id)
        {
            Uri uri = new Uri(string.Format(acaoComentariosPostagem, id));
            List<ComentarioPostagem> retorno = new List<ComentarioPostagem>();
            try
            {
                string response = await client.GetStringAsync(uri);
                retorno = JsonConvert.DeserializeObject<List<ComentarioPostagem>>(response);
                return retorno;
            }
            catch (JsonException jsException)
            {
                throw new Exception(jsException.Message);
            }
            catch (Exception ex)
            {
                String erro = ex.Message;
                throw ex;
            }
        }
        public async Task<List<FotoAlbum>> BuscarFotosAlbumAsync(int id)
        {
            Uri uri = new Uri(string.Format(acaoFotosAlbum, id));
            List<FotoAlbum> retorno = new List<FotoAlbum>();
            try
            {
                string response = await client.GetStringAsync(uri);
                retorno = JsonConvert.DeserializeObject<List<FotoAlbum>>(response);
                return retorno;
            }
            catch (JsonException jsException)
            {
                throw new Exception(jsException.Message);
            }
            catch (Exception ex)
            {
                String erro = ex.Message;
                throw ex;
            }
        }
        public async Task<ComentarioPostagem> EnviarComentarioPostagemAsync(ComentarioPostagem comentario)
        {
            String uri = string.Format(acaoGravarComentarioPostagem);
            ComentarioPostagem retorno = null;
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(comentario), Encoding.UTF8, "application/json"); 
                var response = await client.PostAsync(uri, content);
                if(response.IsSuccessStatusCode)
                {
                    String ret = await response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<ComentarioPostagem>(ret);                    
                }
                else
                {
                    throw new Exception("Erro na resposta do serviço");
                }
                return retorno;
            }catch(HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (JsonException jsException)
            {
                throw new Exception(jsException.Message);
            }
            catch (Exception ex)
            {
                String erro = ex.Message;
                throw ex;
            }
        }
    }
}
