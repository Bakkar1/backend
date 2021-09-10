using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_mvc.Moddels;

namespace WebApp_mvc.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee Employee { get; set; }
        public string PageTitle { get; set; }
    }
}
