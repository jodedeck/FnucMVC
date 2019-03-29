using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FnucMVC.ViewModel
{
    public class CategoryViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parentCategoryId { get; set; }
        //public List<Category> subCategories { get; set; }
    }
}