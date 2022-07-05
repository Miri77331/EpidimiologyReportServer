using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidimiologyReportServer.Models
{
    public class Report
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
     
    }
}
