namespace WebApi.Api.V1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using WebApi.Core.Services;

    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDummyService service;

        public ValuesController(IDummyService service)
        {
            this.service = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<TestParam> Get()
        {
            return new TestParam { Id = 3, Name = "Seb" };
            //            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<long> Get(int id)
        {
            return this.service.SomeAction();
        }

        public class TestParam
        {
            public int Id { get; set; }

            [JsonProperty(PropertyName = "SomePropNameFromJson")]
            public string Name { get; set; }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] TestParam value)
        {
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
