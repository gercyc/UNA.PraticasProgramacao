/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: Classe responsavel por conectar a pagina Delete ao backend da aplicacao. 
    No metodo OnGetAsync a pagina é renderizada de acordo com o parametro recebido, no metodo OnPostAsync é o que ocorre quando o usuário clica em Deletar
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
            //se possui registros filhos, direciona para a pagina de informacoes de que há relacionamentos
            if (HasChild(id))
                return Partial("_HasRelations");

            //se o id é nulo, retorna erro de nao encontrado
            if (id == null)
                return NotFound();

            //localiza a conta a ser deletada
            ContaBancaria = await _context.ContaBancaria.FindAsync(id);

            //encontrou a conta?
            if (ContaBancaria != null)
            {
                //remove a conta
                _context.ContaBancaria.Remove(ContaBancaria);
                //persiste a deleção no bd
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        //verifica se a conta a ser excluida possui lancamentos relacionados
        private bool HasChild(int? id)
        {
            return _context.LancamentoFinanceiro.Where(l => l.IdContaBancaria == id).FirstOrDefault() != null;
        }
    }
}
