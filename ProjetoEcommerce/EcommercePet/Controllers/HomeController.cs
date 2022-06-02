using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommercePet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Contato()
        {
            return View();
        }
        public IActionResult Sobre()
        {
           
            return View();
        }
    }
}
