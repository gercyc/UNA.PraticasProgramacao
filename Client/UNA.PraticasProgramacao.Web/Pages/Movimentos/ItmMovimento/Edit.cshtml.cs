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

namespace UNA.PraticasProgramacao.Web.Pages.Movimentos.ItmMovimento
{
    public class EditModel : PageModel
    {
        private readonly UNA.PraticasProgramacao.Web.Data.ApplicationDbContext _context;

        public EditModel(UNA.PraticasProgramacao.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ItemMovimento ItemMovimento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemMovimento = await _context.ItemMovimento
                .Include(i => i.Movimento)
                .Include(i => i.Produtos).FirstOrDefaultAsync(m => m.IdItemMovimento == id);

            if (ItemMovimento == null)
            {
                return NotFound();
            }
           ViewData["IdMovimento"] = new SelectList(_context.Movimento, "IdMovimento", "IdMovimento");
           ViewData["IdProduto"] = new SelectList(_context.Produtos, "IdProduto", "IdProduto");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ItemMovimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemMovimentoExists(ItemMovimento.IdItemMovimento))
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

        private bool ItemMovimentoExists(int id)
        {
            return _context.ItemMovimento.Any(e => e.IdItemMovimento == id);
        }
    }
}
