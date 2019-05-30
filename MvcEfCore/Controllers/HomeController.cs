using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcEfCore.Models;

namespace MvcEfCore.Controllers
{
    public class HomeController : Controller
    {
		private readonly IHostingEnvironment he;

		public HomeController(IHostingEnvironment e)
		{
			he = e;
		}



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
		public IActionResult ShowDetails()
		{

			return View();
		}


		public IActionResult Privacy(String fullName, IFormFile pic)
        {
			ViewData["fname"] = fullName;
			if (pic != null)
			{
				var fileName = Path.Combine(he.WebRootPath, Path.GetFileName(pic.FileName));
				pic.CopyTo(new FileStream(fileName, FileMode.Create));
				ViewData["fileLocation"] = "/" + Path.GetFileName(pic.FileName);
			}

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
