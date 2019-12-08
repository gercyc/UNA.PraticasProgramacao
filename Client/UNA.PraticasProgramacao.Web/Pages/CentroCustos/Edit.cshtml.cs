/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: Classe responsavel por conectar a pagina Edit ao backend da aplicacao. 
    No metodo OnGetAsync a pagina é renderizada de acordo com o parametro recebido, no metodo OnPostAsync é o que ocorre quando o usuário clica em Salvar
*/

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

namespace UNA.PraticasProgramacao.Web.Pages.CentroCustos
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        //injeta as dependencias
        public EditModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        [BindProperty]
        public CentroCusto CentroCusto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //se nao achou, retorna a erro de nao encontrado
            if (id == null)
            {
                return NotFound();
            }
            //recupero o centro do banco de dados
            CentroCusto = await _context.CentroCusto.FirstOrDefaultAsync(m => m.IdCentroCusto == id);

            //se nao achou o centro, retorna erro de nao encontrado
            if (CentroCusto == null)
            {
                return NotFound();
            }

            //se tudo deu bom, retorna a pagina renderizada
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //valida o model (entidade), se for invalida retorna a pagina que estava antes de fazer o POST
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //muda o estado da entidade para "Modificado"
            _context.Attach(CentroCusto).State = EntityState.Modified;

            try
            {
                //persiste os dados no banco
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //se deu algum erro, verifica a existencia do centro e retorna erro de nao encontrado
                if (!CentroCustoExists(CentroCusto.IdCentroCusto))
                {
                    return NotFound();
                }
                //senao dispara uma exception
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //verifica a existencia do centro de custo pelo ID
        private bool CentroCustoExists(int id)
        {
            return _context.CentroCusto.Any(e => e.IdCentroCusto == id);
        }
    }
}
