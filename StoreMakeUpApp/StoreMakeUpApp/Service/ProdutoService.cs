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
    public class ProdutoService
    {
        //private String urlServico = "https://makeup-api.herokuapp.com/api/v1/products.json?brand=covergirl&product_type=lipstick";
        private String urlServico = "https://jsonplaceholder.typicode.com/users/";
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
                /*string response = @"[
                    {'id':114,'brand':'covergirl','name':'CoverGirl Outlast Longwear Lipstick','price':'10.99'}, 
                    {'id':115,'brand':'covergirl','name':'CoverGirl Power','price':'11.99'},
                    {'id':116,'brand':'covergirl','name':'CoverGirl Power 2','price':'12.80'}
                ]";*/
                string response = await client.GetStringAsync(uri);      
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
        public async Task<Produto> CarregarProdutoAsync(int id)
        {
            Uri uri = new Uri(string.Format(urlServico, string.Empty));
            Produto retorno = new Produto();
            try
            {
                string response = await client.GetStringAsync(String.Format(uri + "{0}", id ));
                retorno = JsonConvert.DeserializeObject<Produto>(response);
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
    }
}
