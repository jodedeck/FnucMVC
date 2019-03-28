using FnucMVC.Controllers;
using FnucMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace FnucMVC.Services
{
    public class ProductService
    {
        string _baseUri;
        HttpClient client = new HttpClient();
        public ProductService()
        {

        }
        public ProductService(IUriServices uriServices)
        {
            _baseUri = uriServices.ApiURL;
        }
        //public async Task<ProductViewModel> GetProducts()
        //{


        //    var request = await client.GetAsync(_baseUri[0] + "product");

        //    var products = await request.Content.

        //    return products;
        //}

        public  async Task<List<ProductViewModel>> GetProducts()
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(_baseUri + "product");
                return JsonConvert.DeserializeObject<List<ProductViewModel>>(content);
            }
        }



    }
}