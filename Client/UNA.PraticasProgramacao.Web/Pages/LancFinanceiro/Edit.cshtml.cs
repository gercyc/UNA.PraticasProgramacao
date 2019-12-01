using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages.LancFinanceiro
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EditModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public LancamentoFinanceiro LancamentoFinanceiro { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = _userManager.GetUserId(User);
            LancamentoFinanceiro = await _context.LancamentoFinanceiro
                .Include(l => l.CentroCusto)
                .Include(l => l.ContaBancaria).FirstOrDefaultAsync(m => m.IdLancamentoFinanceiro == id);

            if (LancamentoFinanceiro == null)
            {
                return NotFound();
            }
            ViewData["IdCentroCusto"] = new SelectList(_context.CentroCusto.Where(c => c.UserId == userId), "IdCentroCusto", "NomeCentroCusto");
            ViewData["IdContaBancaria"] = new SelectList(_context.ContaBancaria.Where(c => c.UserId == userId), "IdContaBancaria", "NomeConta");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            LancamentoFinanceiro.ValorLancamento = Convert.ToDecimal(LancamentoFinanceiro.ValorLancamentoStr);
            _context.Attach(LancamentoFinanceiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LancamentoFinanceiroExists(LancamentoFinanceiro.IdLancamentoFinanceiro))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LancamentoFinanceiroExists(int id)
        {
            return _context.LancamentoFinanceiro.Any(e => e.IdLancamentoFinanceiro == id);
        }
    }
}
