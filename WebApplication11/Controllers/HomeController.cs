using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       // [Route("Gevalue")]
        [HttpGet]
        public string Gevalue()
        {
            string sHtml = "";
            HttpWebRequest request;
            HttpWebResponse response = null;
            Stream stream = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create("https://webapplication1120210726180552.azurewebsites.net/Styles/MOC/MOCPrint.css");
                response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream, System.Text.Encoding.Default);
                sHtml = sr.ReadToEnd();
                if (stream != null) stream.Close();
                if (response != null) response.Close();
                return sHtml;
            }
            catch (Exception ee)
            {
                return ee.Message;
            }
        }
    }
}
