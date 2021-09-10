using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_mvc.Controllers
{
    //[Route("About")]
    public class AboutController : Controller
    {
        //attribute routing bin 9awsin kat7adad lmasar || wkhask dir f startup app.UseMvc()
        //[Route("")]
        //[Route("About")]
        //[Route("Index")]
        public JsonResult Index()
        {
            return Json(new{ Id = 2, name = "mari"});
        }
    }
}
