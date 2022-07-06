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
    public class LocationsController : ControllerBase
    {
        private LocationsService locationsService = new LocationsService();

        // GET: api/<LocationsController>
        [HttpGet]
        public async Task<ActionResult<List<Report>>> Get()
        {
            var res = await locationsService.GetAllReports();
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        // GET api/<LocationsController>/5
        [HttpGet("city")]
        public async Task<ActionResult<List<Report>>> Get([FromQuery] string city)
        {
            var res = await locationsService.GetReportsByCity(city);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        
    }
}
