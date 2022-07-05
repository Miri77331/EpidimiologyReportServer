using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidimiologyReportServer.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public List<Report> Reports { get; set; }
    }
}
