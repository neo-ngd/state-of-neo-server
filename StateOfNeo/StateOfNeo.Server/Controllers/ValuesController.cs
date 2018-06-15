﻿using Microsoft.AspNetCore.Mvc;
using Neo.Core;
using StateOfNeo.Data.Seed;
using StateOfNeo.Server.Infrastructure;
using System.Collections.Generic;

namespace StateOfNeo.Server.Controllers
{
    public class ValuesController : BaseApiController
    {
        private readonly NodeSynchronizer _nodeSynchronizer;

        public ValuesController(NodeSynchronizer nodeSynchronizer)
        {
            _nodeSynchronizer = nodeSynchronizer;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", Blockchain.Default.Height.ToString() };
            //return new string[] { "value1" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post()
        {
            _nodeSynchronizer.Init().ConfigureAwait(false);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
