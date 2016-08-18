using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using RestApi.Models;
using RestApi.Interfaces;
using RestApi.Helper;

namespace RestApi.Controllers
{
    public class PatientsController : ApiController
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public PatientsController() : this(new PatientRepository())
        {
        }
        [HttpGet]
        public Patient Get(int patientId)
        {
            return _patientRepository.GetPatient(patientId);
        }
    }
}