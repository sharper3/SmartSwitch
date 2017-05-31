using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSwitchDashboard.Repositories;
using SmartSwitchDashboard.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSwitchDashboard.Controllers
{
    [Route("api/[controller]")]
    public class SmartSwitchController : Controller
    {
        ISmartSwitchRepository Repository;
        public SmartSwitchController(ISmartSwitchRepository repo)
        {
            Repository = repo;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<SmartSwitch> Get()
        {
            return Repository.GetAll();
        }

        [HttpGet("{id}", Name = "GetSmartSwitch")]
        public IActionResult Get(string id)
        {
            var item = Repository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            
            return new ObjectResult(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SmartSwitch item)
        {
            
            if (item == null)
            {
                return BadRequest("item is null");
            }
            else if (item.Id == null)
            {
                return BadRequest();
            }

            Repository.Add(item);
            return Ok();
        }

    }

    
          

//{
//  "Id": "{{PARTICLE_DEVICE_ID}}",
//  "RelayOneClosed": "{{relayOneClosed}}",
//  "RelayTwoClosed": "{{relayTwoClosed}}"
//}
          

//    {
//  "eventName": "SmartSwitch",
//  "url": "http://codepalousasmartswitch.azurewebsites.net/api/smartswitch",
//  "headers": {
//    "Content-Type": "application/json"
//  },
//  "json": {
//    "Id": "{{PARTICLE_DEVICE_ID}}", 
//    "RelayOneClosed": "{{relayOneClosed}}",
//    "RelayTwoClosed": "{{relayTwoClosed}}"
//  }
//}

}
