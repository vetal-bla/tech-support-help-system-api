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
    public class CashController : ControllerBase
    {
        ICashService CashService;

        public CashController()
        {
            CashService = new CashService();
        }

        // GET: <CashController>
        [HttpGet("{id_Client}")]
        public List<CashSchedule> Get(int id_Client)
        {
            return CashService.GetCashSchedules(id_Client);
        }

        // POST <CashController>
        [HttpPost("{id_Client}")]
        public HttpResponseMessage Post(int id_Client, [FromBody] CashSchedule cashSchedule)
        {
            Claim currentUserClaims = User.FindFirst(ClaimTypes.Name);
            return CashService.AddCashSchedule(id_Client, cashSchedule, currentUserClaims);
        }

        // PUT <CashController>/5
        [HttpPut("{id_Client}")]
        public HttpResponseMessage Put(int id_Client, [FromBody] CashSchedule cashSchedule)
        {
            Claim currentUserClaims = User.FindFirst(ClaimTypes.Name);
            return CashService.EditCashSchedule(id_Client, cashSchedule, currentUserClaims);
        }

        // DELETE CashController>/5
        [HttpDelete("{id_Client}/{id_CashSchedule}")]
        public HttpResponseMessage Delete(int id_Client, int id_CashSchedule)
        {
            Claim currentUserClaims = User.FindFirst(ClaimTypes.Name);
            return CashService.DeleteCashSchedule(id_Client, id_CashSchedule, currentUserClaims);
        }
    }
}
