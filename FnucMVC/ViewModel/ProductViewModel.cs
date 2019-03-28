using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FnucMVC.ViewModel
{
   
        public class ProductViewModel
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int categoryId { get; set; }
            public string category { get; set; }
            public double price { get; set; }
            public DateTime publicationDate { get; set; }
        }

    
}