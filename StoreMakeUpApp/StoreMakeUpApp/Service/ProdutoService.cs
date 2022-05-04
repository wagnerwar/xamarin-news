using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using StoreMakeUpApp.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;
namespace StoreMakeUpApp.Service
{
    public class ProdutoService
    {
        private String urlServico = "http://makeup-api.herokuapp.com/api/v1/products.json?brand=maybelline";
        HttpClient client;
        public ProdutoService()
        {
            client = new HttpClient();
        }
        public async Task<List<Produto>> RecuperarProdutosAsync()
        {
              Uri uri = new Uri(string.Format(urlServico, string.Empty));
            List<Produto> retorno = new List<Produto>();
            try
            {
                 Thread.Sleep(10000);
                await teste();
                /*HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    retorno = JsonConvert.DeserializeObject<List<Produto>>(content);
                }
                else
                {
                    throw new Exception("Erro na requsição");
                }*/
                return retorno;
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }
        private Task<bool> teste()
        {
           var t =  Task.Run(() => this.retornoBooleano() );
            t.Start();
            return Task.FromResult(t.Result);
        }
        private bool retornoBooleano()
        {
            return true;
        }
    }
}
