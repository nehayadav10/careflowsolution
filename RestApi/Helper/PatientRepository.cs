using RestApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestApi.Models;
using System.Web.Http;
using System.Net;

namespace RestApi.Helper
{
    public class PatientRepository : IPatientRepository
    {
        public Patient GetPatient(int patientId)
        {

            var patientContext = new PatientContext();

            var patientsAndEpisodes =
                from p in patientContext.Patients
                join e in patientContext.Episodes on p.PatientId equals e.PatientId
                where p.PatientId == patientId
                select new { p, e };

            if (patientsAndEpisodes.Any())
            {
                var first = patientsAndEpisodes.First().p;
                first.Episodes = patientsAndEpisodes.Select(x => x.e).ToArray();
                return first;
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);

        }
    }
}