using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITSolution.Framework.Core.CustomUserAPI.Data;
using ITSolution.Framework.Server.Core.BaseClasses.Repository;
using ApiMenu.Data;
using Microsoft.AspNetCore.Mvc;

namespace ITSolution.Framework.Servers.Core.FirstAPI.BaseAPIs
{
    /// <summary>
    /// Customize or create new APIs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly DBAccessContext _context;
        public MenuController()
        {
            _context = new DBAccessContext(new ITSDbContextOptions());
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<ItsMenu> Get()
        {
            return _context.MenuRep.GetAll();
        }


        //TODO:
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ItsMenu> Get(int id)
        {
            return _context.MenuRep.FirstOrDefault(id);
        }

        //TODO:
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        //TODO:
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        //TODO:
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
