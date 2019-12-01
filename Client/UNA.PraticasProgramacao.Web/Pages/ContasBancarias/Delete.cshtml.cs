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
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContaBancaria ContaBancaria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
                return NotFound();

            ContaBancaria = await _context.ContaBancaria.FirstOrDefaultAsync(m => m.IdContaBancaria == id);

            if (ContaBancaria == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (HasChild(id))
                return Partial("_HasRelations");

            if (id == null)
                return NotFound();

            ContaBancaria = await _context.ContaBancaria.FindAsync(id);

            if (ContaBancaria != null)
            {
                _context.ContaBancaria.Remove(ContaBancaria);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
        private bool HasChild(int? id)
        {
            return _context.LancamentoFinanceiro.Where(l => l.IdContaBancaria == id).FirstOrDefault() != null;
        }
    }
}
