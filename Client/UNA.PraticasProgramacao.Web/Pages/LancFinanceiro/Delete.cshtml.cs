using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages.LancFinanceiro
{
    public class DeleteModel : PageModel
    {
        private readonly UNA.PraticasProgramacao.Web.Data.ApplicationDbContext _context;

        public DeleteModel(UNA.PraticasProgramacao.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LancamentoFinanceiro LancamentoFinanceiro { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LancamentoFinanceiro = await _context.LancamentoFinanceiro
                .Include(l => l.CentroCusto)
                .Include(l => l.ContaBancaria).FirstOrDefaultAsync(m => m.IdLancamentoFinanceiro == id);

            if (LancamentoFinanceiro == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LancamentoFinanceiro = await _context.LancamentoFinanceiro.FindAsync(id);

            if (LancamentoFinanceiro != null)
            {
                _context.LancamentoFinanceiro.Remove(LancamentoFinanceiro);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
