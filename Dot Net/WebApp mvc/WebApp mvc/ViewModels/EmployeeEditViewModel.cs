using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApp_mvc.Moddels;

namespace WebApp_mvc.ViewModels
{
    public class EmployeeEditViewModel : EmployeeCreateMultipleFiles
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}
