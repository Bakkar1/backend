using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_mvc.Moddels;
using WebApp_mvc.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace WebApp_mvc.Controllers
{
    public class HomeController : Controller
    {

        // bach te9der tekhdem b IEmployeeRepository khasak dir liha
        // registretion f StartUp class
        private readonly IEmployeeRepository _iEmployeeRepository;

        public IWebHostEnvironment hostingEnvironment { get; }

        public HomeController(IEmployeeRepository iEmployeeRepository,
                                IWebHostEnvironment hostingEnvironment)
        {
            _iEmployeeRepository = iEmployeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }
        public ViewResult Index()
        {
            var model = _iEmployeeRepository.GetAllEmployee();
            return View(model);
        }
        public JsonResult GetDetails()
        {
            Employee employee = _iEmployeeRepository.GetEmployee(1);
            return Json(employee);
        }
        //best way to sent data with strongly typed
        public ViewResult DetailsStrongly()
        {
            Employee employee = _iEmployeeRepository.GetEmployee(2);
            ViewBag.PageTitle = "Emloyee Details";
            return View(employee);
        }

        //viewmodel katkhdem biha fach ykon 3and model wmafihech kolchi data li bghit tsifatha
        //attribute route : [Route("Details/{id?}")]
        public IActionResult Details(int? id)
        {
            //HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            //{
            //    Employee = _iEmployeeRepository.GetEmployee(id ?? 1)
            //      Null - Coalescing Operator : if id is null than return 1
            //    ,
            //    PageTitle = "Emloyee Details"
            //};

            //return View(_iEmployeeRepository.GetEmployee(id ?? 1));


            Employee model = _iEmployeeRepository.GetEmployee(id ?? 1);

            if (model == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id);
            }
            
            return View(model);
            
        }
        public ViewResult DetailsDT()
        {
            Employee employee = _iEmployeeRepository.GetEmployee(1);
            // transfer data using viewdata
            // ViewData hiya Dictionary
            ViewData["Employee"] = employee;
            ViewData["PageTitle"] = "Emloyee Details";
            
            return View();
        }
        public ViewResult DetailsBag()
        {
            Employee employee = _iEmployeeRepository.GetEmployee(2);
            ViewBag.Employee = employee;
            ViewBag.PageTitle = "Emloyee Details";

            return View();
        }
        public ViewResult Update(string param)
        {
            Employee employee = _iEmployeeRepository.GetEmployee(1);
            string path = "~/MyViews/Update/Header.cshtml";
            //string path = "../../MyViews/Update/Header";
            return View(path, employee);
        }
        public string Test(string number)
        {
            if (int.TryParse(number, out int num))
            {
                return $"the result is : {num * 2}";
            }
            return "not a number";
        }
        //public ViewResult Details()
        //{
        //    Employee employee = _iEmployeeRepository.GetEmployee(1);

        //    ViewData["Emloyee"] = employee;
        //    //by default hiya ghat9alb 3la had l path Views/Home/Details
        //    return View(employee);
        //    // yla bghit t7dad chi l view
        //    //return View("viewName or path", model);
        //}

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            // yla kolchi validation dazt mezyan
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if(model.Photo != null)
                {
                    // hostingEnvironment.WebRootPath katraja3 lik absolute path dyal wwwroot folder
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // haka kandiro wa7d l uniqe name l hadak l file 
                    // maykonch 3nadna nafs lfile bjoj smiyat
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    //upload de image file to the server (images folder)
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee newEmployee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName,
                };
                _iEmployeeRepository.Add(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            _iEmployeeRepository.Delete(id);
            return RedirectToAction("Index");
        }


        #region upload multiple files
        [HttpGet]
        public ViewResult CreateMultiple()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMultiple(EmployeeCreateMultipleFiles model)
        {
            
            if (ModelState.IsValid)
            {
                // akhir tswira ghandiro lih upload hiya li ghatkon dyal hadak employee
                // 7it 3nadna ghir table wa7d w uniqueFileName kola mara kandiro lih override f loop
                string uniqueFileName = ProcessUploadedFile(model);
                Employee newEmployee = new Employee()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName,
                };
                _iEmployeeRepository.Add(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
        }
        #endregion

        [HttpGet]
        public ViewResult Edit (int id)
        {
            Employee employee = _iEmployeeRepository.GetEmployee(id);
            EmployeeEditViewModel emplEditViewModel = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(emplEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _iEmployeeRepository.GetEmployee(model.Id);

                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                employee.PhotoPath = model.ExistingPhotoPath;
                if(model.Photos != null)
                {
                    if(model.ExistingPhotoPath != null)
                    {
                        //delete existing photo
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }
                _iEmployeeRepository.Update(employee);
                return RedirectToAction("Index");
            }
            return View();
        }

        private string ProcessUploadedFile(EmployeeCreateMultipleFiles model)
        {
            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (IFormFile photo in model.Photos)
                {
                    // hostingEnvironment.WebRootPath katraja3 lik absolute path dyal wwwroot folder
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    // haka kandiro wa7d l uniqe name l hadak l file 
                    // maykonch 3nadna nafs lfile bjoj smiyat
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    //upload de image file to the server (images folder)
                    //photo.CopyTo(new FileStream(filePath, FileMode.Create)); not juist file stream not closed
                    using(FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fs);
                    }
                }
            }
            return uniqueFileName;
        }
    }
}
