using EpidimiologyReportServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidimiologyReportServer.Services
{
    public class UserService
    {

        public async Task<ActionResult<List<Report>>> GetPatientReports(int patintId) {
            return null;
        }
        public async Task<ActionResult<Report>> PostReport(int patintId, Report report)
        {
            return null;
        }
    }
}
