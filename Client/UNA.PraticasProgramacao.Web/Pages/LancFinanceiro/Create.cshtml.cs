using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(UNA.PraticasProgramacao.Web.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            var userId = _userManager.GetUserId(User);
            ViewData["IdCentroCusto"] = new SelectList(_context.CentroCusto.Where(c => c.UserId == userId), "IdCentroCusto", "NomeCentroCusto");
            ViewData["IdContaBancaria"] = new SelectList(_context.ContaBancaria.Where(c => c.UserId == userId), "IdContaBancaria", "NomeConta");
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

            LancamentoFinanceiro.ValorLancamento = Convert.ToDecimal(LancamentoFinanceiro.ValorLancamentoStr);
            LancamentoFinanceiro.NumeroLancamento = new Random().Next().ToString();
            LancamentoFinanceiro.DataCriacao = DateTime.Now;
            LancamentoFinanceiro.UserId = _userManager.GetUserId(User);
            _context.LancamentoFinanceiro.Add(LancamentoFinanceiro);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
