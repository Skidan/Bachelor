using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Qualify.Controllers
{
    public class ToolsController : Controller
    {
        // вывод списка инструментов
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTool() 
        {
            return View();
        }

        public IActionResult RemoveTool()
        {
            return View();
        }
    }
}
