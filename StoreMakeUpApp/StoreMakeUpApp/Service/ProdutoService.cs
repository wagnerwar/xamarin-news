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
        private String urlServico = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=covergirl&product_type=lipstick";
        //private String urlServico = "https://jsonplaceholder.typicode.com/users/";
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
                string response = @"[
                    {'id':114,'brand':'covergirl','name':'CoverGirl Outlast Longwear Lipstick','price':'10.99'}, 
                    {'id':115,'brand':'covergirl','name':'CoverGirl Power','price':'11.99'},
                    {'id':116,'brand':'covergirl','name':'CoverGirl Power 2','price':'12.80'}
                ]";
                //retorno = JsonConvert.DeserializeObject<List<Produto>>(response);
                //String response = await client.GetStringAsync(uri);      
                retorno = JsonConvert.DeserializeObject<List<Produto>>(response);
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
    }
}
