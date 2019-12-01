using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages.ContasBancarias
{
    public class IndexModel : PageModel
    {
        private readonly UNA.PraticasProgramacao.Web.Data.ApplicationDbContext _context;

        public IndexModel(UNA.PraticasProgramacao.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ContaBancaria> ContaBancaria { get;set; }

        public async Task OnGetAsync()
        {
            ContaBancaria = await _context.ContaBancaria.Where(c => c.UserId == User.Claims.FirstOrDefault().Value).ToListAsync();
        }
    }
}
