using CommentApp.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecallController : ControllerBase
    {
        // GET: api/<RecallController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RecallController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecallController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecallController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecallController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
