using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using asp_net_mvc_core_link_generation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace asp_net_mvc_core_link_generation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHtmlHelper _htmlHelper;

        public HomeController(ILogger<HomeController> logger, IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new LinksModel();
            model.Links = new List<Link>() {
                new Link { 
                    Text = "Simple link to a 'Home' controller 'Index' action", 
                    URL = Url.Action("Index", "Home")
                },
                new Link { 
                    Text = "A link with parameters to 'Home' controller 'Details' action", 
                    URL = Url.Action("Details", "Home", new { name = "John Doe", id = 100500})
                },
                new Link { 
                    Text = "Safely generated link with parameters to 'Home' controller 'Details' action", 
                    URL = Url.Action(nameof(HomeController.Details), Utils.GetControllerName<HomeController>(), new { name = "John Doe", id = 100500})
                }
            };
            return View(model);
        }

        public IActionResult Details(int id, string name) {
            return View(new DetailsModel() { Id = id, Name = name});
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
    }
}
