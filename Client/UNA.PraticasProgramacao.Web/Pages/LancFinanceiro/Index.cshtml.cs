/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: Classe responsavel por conectar a pagina Index ao backend da aplicacao. 
    No metodo OnGetAsync a pagina é renderizada e é carregada a lista de objetos do banco de dados
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages.LancFinanceiro
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<LancamentoFinanceiro> LancamentosFinanceiros { get; set; }
        [BindProperty]
        public Transferencia TransferenciaObj { get; set; }


        public IList<int> MaxLancamentos { get { return new int[] { 20, 100, 200, 600 }; } }

        [BindProperty]
        public int SelCount { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["IdContaBancariaOrigem"] = new SelectList(_context.ContaBancaria.Where(c => c.UserId == User.Claims.FirstOrDefault().Value), "IdContaBancaria", "NomeConta");
            ViewData["IdContaBancariaDestino"] = new SelectList(_context.ContaBancaria.Where(c => c.UserId == User.Claims.FirstOrDefault().Value), "IdContaBancaria", "NomeConta");


            ViewData["Qtd"] = new SelectList(MaxLancamentos);
            SelCount = SelCount == 0 ? 20 : SelCount;
            await FillList(SelCount);

            return Page();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (TransferenciaObj.ContaDestino > 0)
               await OnPostCriarTransferencia();

            return await OnGetAsync();
        }

        /// <summary>
        /// Este metodo realiza a transferencia entre contas, utiliza o objeto BindProperty 'TransferenciaObj' que é preenchido no form do Modal
        /// </summary>
        /// <returns></returns>
        private async Task OnPostCriarTransferencia()
        {
            var tOrigem = new LancamentoFinanceiro()
            {
                DataCriacao = DateTime.Now,
                IdContaBancaria = TransferenciaObj.ContaOrigem,
                DataPagamento = TransferenciaObj.Data,
                DataVencimento = TransferenciaObj.Data,
                NumeroLancamento = new Random().Next().ToString(),
                TipoLancamento = Core.Entidades.Entidades.EnumTipoLancamento.Pagar,
                UserId = User.Claims.FirstOrDefault().Value,
                ValorLancamento = TransferenciaObj.Valor,
                HistoricoLancamento = "Transferencia entre contas"
            };

            var tDestino = new LancamentoFinanceiro()
            {
                DataCriacao = DateTime.Now,
                IdContaBancaria = TransferenciaObj.ContaDestino,
                DataPagamento = TransferenciaObj.Data,
                DataVencimento = TransferenciaObj.Data,
                NumeroLancamento = new Random().Next().ToString(),
                TipoLancamento = Core.Entidades.Entidades.EnumTipoLancamento.Receber,
                UserId = User.Claims.FirstOrDefault().Value,
                ValorLancamento = TransferenciaObj.Valor,
                HistoricoLancamento = "Transferencia entre contas"
            };

            _context.Add(tOrigem);
            _context.Add(tDestino);
            await _context.SaveChangesAsync();
        }

        private async Task FillList(int? max)
        {
            SelCount = max.HasValue ? max.Value : 100;

            var lancs = from l in _context.LancamentoFinanceiro.Include(l => l.CentroCusto)
                            .Include(l => l.ContaBancaria)
                            .Include(l => l.Usuario)
                            .Where(l => l.UserId == User.Claims.FirstOrDefault().Value).Take(SelCount)
                            .OrderByDescending(l => l.DataVencimento)
                        select new LancamentoFinanceiro()
                        {
                            CentroCusto = l.CentroCusto,
                            ContaBancaria = l.ContaBancaria,
                            DataCriacao = l.DataCriacao,
                            DataPagamento = l.DataPagamento,
                            DataVencimento = l.DataVencimento,
                            HistoricoLancamento = l.HistoricoLancamento,
                            IdCentroCusto = l.IdCentroCusto,
                            IdContaBancaria = l.IdContaBancaria,
                            IdLancamentoFinanceiro = l.IdLancamentoFinanceiro,
                            NumeroLancamento = l.NumeroLancamento,
                            TipoLancamento = l.TipoLancamento,
                            UserId = l.UserId,
                            Usuario = l.Usuario,
                            ValorLancamento = l.TipoLancamento == Core.Entidades.Entidades.EnumTipoLancamento.Pagar ? l.ValorLancamento * -1 : l.ValorLancamento,
                            ValorLancamentoStr = l.ValorLancamentoStr
                        };

            LancamentosFinanceiros = await lancs.ToListAsync();

        }

    }
    public class Transferencia
    {
        public int ContaOrigem { get; set; }
        public int ContaDestino { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

    }
}
