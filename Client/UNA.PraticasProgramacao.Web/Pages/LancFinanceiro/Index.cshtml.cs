using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages.LancFinanceiro
{
    public class IndexModel : PageModel
    {
        private readonly UNA.PraticasProgramacao.Web.Data.ApplicationDbContext _context;

        public IndexModel(UNA.PraticasProgramacao.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LancamentoFinanceiro> LancamentoFinanceiro { get; set; }


        public IList<int> MaxLancamentos { get { return new int[] { 20, 100, 200, 600 }; } }

        [BindProperty]
        public int SelCount { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["Qtd"] = new SelectList(MaxLancamentos);
            SelCount = SelCount == 0 ? 10 : SelCount;
            await FillList(SelCount);

            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            return await OnGetAsync();
        }
        private async Task FillList(int? max)
        {
            SelCount = max.HasValue ? max.Value : 100;
            LancamentoFinanceiro = await _context.LancamentoFinanceiro
                            .Include(l => l.CentroCusto)
                            .Include(l => l.ContaBancaria)
                            .Include(l => l.Parceiro)
                            .Include(l => l.Usuario)
                            .Where(l => l.UserId == User.Claims.FirstOrDefault().Value).Take(SelCount)
                            .ToListAsync();
        }
    }
}
