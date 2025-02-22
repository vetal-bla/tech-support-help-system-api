﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using TechSupportHelpSystem.Models;
using TechSupportHelpSystem.Services;

namespace TechSupportHelpSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ClinicsController : ControllerBase
    {
        IClinicService ClinicService;

        public ClinicsController()
        {
            ClinicService = new ClinicService();
        }

        // GET: <ClinicsController>
        [HttpGet("{id_Client}")]
        public List<Clinic> Get(int id_Client)
        {
            return ClinicService.GetClinics(id_Client);
        }

        [HttpGet("{id_Client}/{id_Clinic}")]
        public Clinic Get(int id_Client, int id_Clinic)
        {
            return ClinicService.GetClinic(id_Client, id_Clinic);
        }

        // POST <ClinicsController>
        [HttpPost("{id_Client}")]
        public HttpResponseMessage Post(int id_Client, [FromBody] Clinic clinic)
        {
            Claim currentUserClaims = User.FindFirst(ClaimTypes.Name);
            return ClinicService.CreateClinic(id_Client, clinic, currentUserClaims);
        }

        // PUT <ClinicsController>/5
        [HttpPut("{id_Client}")]
        public HttpResponseMessage Put(int id_Client, [FromBody] Clinic clinic)
        {
            Claim currentUserClaims = User.FindFirst(ClaimTypes.Name);
            return ClinicService.UpdateClinic(id_Client, clinic, currentUserClaims);
        }

        // DELETE <ClinicsController>/5
        [HttpDelete("{id_Client}/{id_Clinic}")]
        public HttpResponseMessage Delete(int id_Client, int id_Clinic)
        {
            Claim currentUserClaims = User.FindFirst(ClaimTypes.Name);
            return ClinicService.DeleteClinic(id_Client, id_Clinic, currentUserClaims);
        }

        // GET: ClinicsController/id_Client/id_Clinic/id_Modality
        [HttpGet("{id_Client}/{id_Clinic}/{id_Modality}")]
        public HttpResponseMessage Get(int id_Client, int id_Clinic, int? id_Modality)
        {
            Claim currentUserClaims = User.FindFirst(ClaimTypes.Name);
            return ClinicService.EditClinicProcedures(id_Client, id_Clinic, id_Modality, currentUserClaims);
        }

        // GET: ClinicsController/id_Client/id_Clinic/id_Modality
        [HttpDelete("{id_Client}/{id_Clinic}/{id_Modality}")]
        public HttpResponseMessage Delete(int id_Client, int id_Clinic, int? id_Modality)
        {
            Claim currentUserClaims = User.FindFirst(ClaimTypes.Name);
            return ClinicService.DeleteClinicProcedures(id_Client, id_Clinic, id_Modality, currentUserClaims);
        }
    }
}
