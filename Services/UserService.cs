using EpidimiologyReportServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EpidimiologyReportServer.Services
{
    public class UserService
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

        public async Task<List<Report>> GetPatientReports(int patintId)
        {
            List<Patient> allPatients = await readPatientsFromJsonAsync();
            Patient _patient = allPatients.Find(p => p.Id == patintId);
            if (_patient == null)
                return null;
            return _patient.Reports;
        }
        public async Task<Report> PostReport(int patintId, Report report)
        {
            List<Patient> allPatients = await readPatientsFromJsonAsync();
            int patientIndex = allPatients.FindIndex(p => p.Id == patintId);
            if (patientIndex == -1)
            {
                Patient newPatient = new Patient() { Id = patintId, Reports = new List<Report>() { report } };
                string userJson = JsonSerializer.Serialize(newPatient);
                await System.IO.File.AppendAllTextAsync("./Patients.txt", userJson + Environment.NewLine);
            }
            else
            {

                allPatients[patientIndex].Reports.Add(report);
                System.IO.File.Delete("./Patients.txt");
                for (int i = 0; i < allPatients.Count; i++)
                {
                    string userJson = JsonSerializer.Serialize(allPatients[i]);
                    await System.IO.File.AppendAllTextAsync("./Patients.txt", userJson + Environment.NewLine);
                }


            }


            return report;

        }

        public async Task DeleteReport(int patientId, Report report)
        {
            List<Patient> allPatients = await readPatientsFromJsonAsync();
            int patientIndex = allPatients.FindIndex(p => p.Id == patientId);
            if (patientIndex != -1)
            {
                //allPatients[patientIndex].Reports.FindIndex(r => r.Equals(report));
                allPatients[patientIndex].Reports.Remove(report);
            }
            System.IO.File.Delete("./Patients.txt");
            for (int i = 0; i < allPatients.Count; i++)
            {
                string userJson = JsonSerializer.Serialize(allPatients[i]);
                await System.IO.File.AppendAllTextAsync("./Patients.txt", userJson + Environment.NewLine);
            }


        }
    }
}
