using EpidimiologyReportServer.Models;
using EpidimiologyReportServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EpidimiologyReportServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService userService = new UserService();

  
        // GET api/<UserController>/5
        [HttpGet("{patintId}")]
        public async Task<ActionResult<List<Report>>> Get(int patintId)
        {  
            var res=await userService.GetPatientReports(patintId);
            if (res==null)
            {
                return NotFound();
            }
            return res;
              
        }

        // POST api/<UserController>
        [HttpPost("{patintId}")]
        public async Task<ActionResult<Report>> Post(int patintId,[FromBody] Report report)
        {
            return await userService.PostReport(patintId, report);
        }

    }
}
