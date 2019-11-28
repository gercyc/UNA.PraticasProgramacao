using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.BaseApis
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Menu
        [HttpGet]
        public IEnumerable<ItsMenu> Get()
        {
            var menus = _context.Menu.Where(m => m.Status).AsEnumerable();
            return menus;
        }
    }
}
