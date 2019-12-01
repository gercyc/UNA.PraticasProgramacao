/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: Classe responsavel por conectar a pagina Create ao backend da aplicacao. 
    No metodo OnGet a pagina é renderizada, no metodo OnPostAsync é o que ocorre quando o usuário clica em Salvar
*/
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
