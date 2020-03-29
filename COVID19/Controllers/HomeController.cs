using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using COVID19.Models;

namespace COVID19.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private COVID19Context context;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.context = new COVID19Context();
        }

        public IActionResult Index()
        {
            List<vInfectionMaster> vInfections = new List<vInfectionMaster>();
            try
            {
                vInfections = context.vInfectionMaster.ToList();
            }
            catch (Exception ex)
            {

            }
            return View(vInfections);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
