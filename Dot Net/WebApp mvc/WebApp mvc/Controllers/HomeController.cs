using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_mvc.Moddels;
using WebApp_mvc.ViewModels;
using System.IO;

namespace WebApp_mvc.Controllers
{
    public class HomeController : Controller
    {

        // bach te9der tekhdem b IEmployeeRepository khasak dir liha
        // registretion f StartUp class
        private readonly IEmployeeRepository _iEmployeeRepository;
        public HomeController(IEmployeeRepository iEmployeeRepository)
        {
            _iEmployeeRepository = iEmployeeRepository;
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
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _iEmployeeRepository.GetEmployee(id??1)
                //  Null-Coalescing Operator : if id is null than return 1
                ,
                PageTitle = "Emloyee Details"
            };
            return View(homeDetailsViewModel);
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
        public IActionResult Create(Employee employee)
        {
            // yla kolchi validation dazt mezyan
            if (ModelState.IsValid)
            {
                Employee newEmployee = _iEmployeeRepository.Add(employee);
                // haka kadir i3adat tawjih l action method Details li kayna l fog 
                // bach tchof details dyal had new employee
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            
            return View();
        }
        public IActionResult Delete(int id)
        {
            //if(_iEmployeeRepository.Delete(id))
            //{
            //    return View("index");
            //}
            return View("index");
        }
    }
}
