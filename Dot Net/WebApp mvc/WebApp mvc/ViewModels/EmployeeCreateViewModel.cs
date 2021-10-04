using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp_mvc.Moddels;
using Microsoft.AspNetCore.Http;

namespace WebApp_mvc.ViewModels
{
    public class EmployeeCreateViewModel
    {
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "please select a department")]
        public Dept? Department { get; set; }
        public IFormFile Photo{ get; set; }
    }
}
