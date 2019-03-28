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
using System.Web.Mvc;

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

        public ProductViewModel CreateProductViewModel(FormCollection collection)
        {

            var ReturnValue = new ProductViewModel();
            ReturnValue.category = collection.GetValue("category").AttemptedValue;
            ReturnValue.name = collection.GetValue("name").AttemptedValue;
            ReturnValue.description = collection.GetValue("description").AttemptedValue;
            ReturnValue.categoryId = Convert.ToInt32(collection.GetValue("categoryId").AttemptedValue);
            ReturnValue.price = Convert.ToDouble(collection.GetValue("price").AttemptedValue);
            ReturnValue.publicationDate = DateTime.Now;
            ReturnValue.id = 0;

            return ReturnValue;
        }

        public async Task<HttpResponseMessage> PostProduct(ProductViewModel productViewModel)
        {
            //using (var client = new HttpClient())
            //{
            //    var content = await client.PostAsync(_baseUri + "product", new StringContent(new JavaScriptSerializer().Serialize(productViewModel), Encoding.UTF8, "application/json"));
            //}
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(_baseUri + "product/postProduct");
                var json = new JavaScriptSerializer().Serialize(productViewModel);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                return await client.SendAsync(request);

                //var content = await client.PostAsync((_baseUri + "product");
                //return JsonConvert.DeserializeObject<List<ProductViewModel>>(content);
            }

           
        }
    }
}