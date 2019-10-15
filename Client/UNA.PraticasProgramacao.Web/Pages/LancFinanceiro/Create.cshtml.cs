using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages.LancFinanceiro
{
    public class CreateModel : PageModel
    {
        private readonly UNA.PraticasProgramacao.Web.Data.ApplicationDbContext _context;

        public CreateModel(UNA.PraticasProgramacao.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdCentroCusto"] = new SelectList(_context.CentroCusto, "IdCentroCusto", "NomeCentroCusto");
        ViewData["IdContaBancaria"] = new SelectList(_context.ContaBancaria, "IdContaBancaria", "Agencia");
        ViewData["IdParceiro"] = new SelectList(_context.Parceiro, "IdParceiro", "NomeParceiro");
            return Page();
        }

        [BindProperty]
        public LancamentoFinanceiro LancamentoFinanceiro { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LancamentoFinanceiro.Add(LancamentoFinanceiro);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
