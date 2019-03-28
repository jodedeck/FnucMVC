using FnucMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FnucMVC.Models
{
    public class UrlBuilder : IUriServices
    {
        public string[] ApiURL { get => ConfigurationManager.AppSettings.GetValues("baseUri");  }
    }
}