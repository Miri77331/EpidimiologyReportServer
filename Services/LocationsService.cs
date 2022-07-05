using EpidimiologyReportServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EpidimiologyReportServer.Services
{
    public class LocationsService
    {
        public async Task<List<Patient>> readPatientsFromJsonAsync()
        {
            using (StreamReader reader = System.IO.File.OpenText("./Patients.txt"))
            {
                List<Patient> allPatients = new List<Patient>();
                string currentPatient;
                while ((currentPatient = await reader.ReadLineAsync()) != null)
                {
                    Patient _patient = JsonSerializer.Deserialize<Patient>(currentPatient);
                    allPatients.Add(_patient);
                }
                return allPatients;
            }

        }
        public async Task<List<Report>> GetAllReports()
        {
            List<Patient> allPatients = await readPatientsFromJsonAsync();
            List<Report> reports = new List<Report>();

            allPatients.ForEach(patient => {
                patient.Reports.ForEach(report => {
                    reports.Add(report);
                }); ;
            });
;
            return reports;
        }
     
        public async Task<List<Report>> GetReportsByCity(string city)
        {
            List<Patient> allPatients = await readPatientsFromJsonAsync();
            List<Report> reports = new List<Report>();

            allPatients.ForEach(patient => {
                patient.Reports.ForEach(report => {
                    if(report.City.Equals(city))
                        reports.Add(report);
                }); ;
            });
            ;
            return reports;
        }
    }
}
