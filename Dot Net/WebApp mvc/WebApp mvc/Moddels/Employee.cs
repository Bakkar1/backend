using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApp_mvc.Moddels
{
    public class Employee
    {
        //model validation kadirha (maxlength.... )b Required 9bal l propertie
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "please select a department")]
        public Dept? Department { get; set; }
        public string PhotoPath { get; set; }
    }
}
