﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using TechSupportHelpSystem.Models;
using TechSupportHelpSystem.Services;

namespace TechSupportHelpSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeachingCollectionsController : ControllerBase
    {
        ITeachingCollectionService TeachingCollectionService = new TeachingCollectionService();
        // GET: <TeachingCollectionsController>
        [HttpGet("{id_Client}")]
        public List<TeachingCollection> Get(int id_Client)
        {
            return TeachingCollectionService.GetTeachingCollections(id_Client);
        }

        // POST <TeachingCollectionsController>
        [HttpPost("{id_Client}")]
        public HttpResponseMessage Post(int id_Client, [FromBody] TeachingCollection teachingCollection)
        {
            return TeachingCollectionService.AddTeachingCollection(id_Client, teachingCollection);
        }

        // PUT <TeachingCollectionsController>/5
        [HttpPut("{id_Client}")]
        public HttpResponseMessage Put(int id_Client, [FromBody] TeachingCollection teachingCollection)
        {
            return TeachingCollectionService.EditTeachingCollection(id_Client, teachingCollection);
        }

        // DELETE <TeachingCollectionsController>/5
        [HttpDelete("{id_Client}/{id_TeachingCollection}")]
        public HttpResponseMessage Delete(int id_Client, int id_TeachingCollection)
        {
            return TeachingCollectionService.DeleteTeachingCollection(id_Client, id_TeachingCollection);
        }
    }
}
