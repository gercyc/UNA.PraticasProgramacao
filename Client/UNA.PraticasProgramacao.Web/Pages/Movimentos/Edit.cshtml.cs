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

namespace UNA.PraticasProgramacao.Web.Pages.Movimentos
{
    public class EditModel : PageModel
    {
        private readonly UNA.PraticasProgramacao.Web.Data.ApplicationDbContext _context;

        public EditModel(UNA.PraticasProgramacao.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movimento Movimento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movimento = await _context.Movimento
                .Include(m => m.FormaPagamento)
                .Include(m => m.Parceiro)
                .Include(m => m.TipoMovimento).FirstOrDefaultAsync(m => m.IdMovimento == id);

            if (Movimento == null)
            {
                return NotFound();
            }
           ViewData["IdFormaPagamento"] = new SelectList(_context.FormaPagamento, "IdFormaPagamento", "IdFormaPagamento");
           ViewData["IdParceiro"] = new SelectList(_context.Parceiro, "IdParceiro", "IdParceiro");
           ViewData["IdTipoMovimento"] = new SelectList(_context.TipoMovimento, "IdTipoMovimento", "IdTipoMovimento");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Movimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimentoExists(Movimento.IdMovimento))
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

        private bool MovimentoExists(int id)
        {
            return _context.Movimento.Any(e => e.IdMovimento == id);
        }
    }
}
