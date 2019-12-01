/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: Classe responsavel por conectar a pagina Details ao backend da aplicacao. 
    No metodo OnGetAsync a pagina é renderizada de acordo com o parametro recebido
*/
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
    public class DetailsModel : PageModel
    {
        private readonly UNA.PraticasProgramacao.Web.Data.ApplicationDbContext _context;

        public DetailsModel(UNA.PraticasProgramacao.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
