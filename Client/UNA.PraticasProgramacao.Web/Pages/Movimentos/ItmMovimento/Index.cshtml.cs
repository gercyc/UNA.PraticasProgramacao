using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages.Movimentos.ItmMovimento
{
    public class IndexModel : PageModel
    {
        private readonly UNA.PraticasProgramacao.Web.Data.ApplicationDbContext _context;

        public IndexModel(UNA.PraticasProgramacao.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ItemMovimento> ItemMovimento { get;set; }

        public async Task OnGetAsync()
        {
            ItemMovimento = await _context.ItemMovimento
                .Include(i => i.Movimento)
                .Include(i => i.Produtos).ToListAsync();
        }
    }
}
