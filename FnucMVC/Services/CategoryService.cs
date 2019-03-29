using FnucMVC.Controllers;
using FnucMVC.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FnucMVC.Services
{
    public class CategoryService
    {
        string _baseUri;
        public CategoryService(IUriServices uriServices)
        {
            _baseUri = uriServices.ApiURL;
        }

        public async Task<List<CategoryViewModel>> GetCategories()
        {
            using (var client = new HttpClient())
            {
                var content = await client.GetStringAsync(_baseUri + "category");
                return JsonConvert.DeserializeObject<List<CategoryViewModel>>(content);
            }
        }
    }
}