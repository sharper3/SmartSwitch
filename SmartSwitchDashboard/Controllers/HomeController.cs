using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSwitchDashboard.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSwitchDashboard.Controllers
{
    public class HomeController : Controller
    {
        ISmartSwitchRepository Repository;
        public HomeController(ISmartSwitchRepository repo)
        {
            Repository = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(Repository.GetAll());
        }
        public IActionResult Partial(string id)
        {
            return PartialView(Repository.Find(id));
        }

        public async Task<IActionResult> ToggleRelayOne(string id)
        {
            var item = Repository.Find(id);
            if (item == null)
            {
                return BadRequest();
            }
            else
            {
                await item.ToggleRelayOne();
            }
            return View("Index", Repository.GetAll());
            //return Ok();
        }

        public async Task<IActionResult> ToggleRelayTwo(string id)
        {
            var item = Repository.Find(id);
            if (item == null)
            {
                return BadRequest();
            }
            else
            {
                await item.ToggleRelayTwo();
            }
            return View("Index", Repository.GetAll());
        }

 
    }
}
