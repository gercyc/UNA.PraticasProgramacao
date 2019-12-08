using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Core.Entidades.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        SignInManager<IdentityUser> _signInManager;
        UserManager<IdentityUser> _userManager;
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IList<LancamentoFinanceiro> Lancamentos { get; set; }

        public string ReceberProx30Dias { get; set; }
        public string PagarProx30Dias { get; set; }
        public string PercentPagarReceber { get; set; }
        public string QtdPagar { get; set; }
        public string QtdReceber { get; set; }
        List<LineChartData> ChartDataList = new List<LineChartData>();

        public IActionResult OnGetAsync()
        {

            if (!_signInManager.IsSignedIn(User))
                return RedirectToPage("Landing");
            //recupera o usuario logado
            var userId = _userManager.GetUserId(User);

            //pega a soma dos lancamentos a receber entre nos proximos 30 dias
            ReceberProx30Dias = _context.LancamentoFinanceiro.Where(l => l.TipoLancamento == EnumTipoLancamento.Receber
            && l.DataVencimento >= DateTime.Now
            && l.DataVencimento <= DateTime.Now.AddDays(30)
            && !l.DataPagamento.HasValue
            && l.UserId == userId).Sum(l => l.ValorLancamento).ToString("N2");
            //pega a soma dos lancamentos a pagar nos proximos 30 dias
            PagarProx30Dias = (_context.LancamentoFinanceiro.Where(l => l.TipoLancamento == EnumTipoLancamento.Pagar
            && l.DataVencimento >= DateTime.Now
            && l.DataVencimento <= DateTime.Now.AddDays(30)
            && !l.DataPagamento.HasValue
            && l.UserId == userId).Sum(l => l.ValorLancamento) * -1).ToString("N2");

            //qtd dos lancamentos a pagar que nao estao pagos
            int pagar = _context.LancamentoFinanceiro.Where(l => l.TipoLancamento == EnumTipoLancamento.Pagar
            && !l.DataPagamento.HasValue
            && l.UserId == userId).Count();

            //qtd dos lancamentos a receber que nao estao pagos
            int receber = _context.LancamentoFinanceiro.Where(l => l.TipoLancamento == EnumTipoLancamento.Receber
            && !l.DataPagamento.HasValue
            && l.UserId == userId).Count();
            //define as propriedades que serao utilizados na renderizacao do html
            QtdPagar = pagar.ToString();
            QtdReceber = receber.ToString();
            //renderiza a pagina
            return Page();
        }

        /// <summary>
        /// recupera os dados do grafico de linhas. Soma todos os lançamentos cadastrados (credito-debito) agrupando por vencimento (MM/YYYY)
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LineChartData> GetChartData()
        {
            var lancamentos = _context.LancamentoFinanceiro.AsEnumerable().OrderBy(f => f.DataVencimento);
            var id = _userManager.GetUserId(User);
            var q = from d in lancamentos
                    group d by new { Data = d.DataVencimento.Month.ToString().PadLeft(2, '0') + "/" + d.DataVencimento.Year }
                    into grp
                    select new LineChartData { Periodo = grp.Key.Data, Valor = grp.Sum(g => g.TipoLancamento == Core.Entidades.Entidades.EnumTipoLancamento.Pagar ? g.ValorLancamento * -1 : g.ValorLancamento) };

            return q.AsEnumerable();
        }

        /// <summary>
        /// recupera os dados do grafico de pizza. Soma todos os lançamentos cadastrados (credito-debito) agrupando por centro de custo
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PieChartData> GetPieChartData()
        {
            var lancamentos = _context.LancamentoFinanceiro.Include(l => l.CentroCusto).AsEnumerable().OrderBy(f => f.DataVencimento);

            var q = from d in lancamentos
                    group d by new { Centro = d.CentroCusto.NomeCentroCusto }
                    into grp
                    select new PieChartData { Centro = grp.Key.Centro, Valor = grp.Sum(g => g.TipoLancamento == Core.Entidades.Entidades.EnumTipoLancamento.Pagar ? g.ValorLancamento * -1 : g.ValorLancamento) };

            return q.AsEnumerable();
        }


    }
    //classe que representa os dados do grafico de linhas
    public class LineChartData
    {
        public LineChartData()
        {

        }
        public string Periodo { get; set; }
        public decimal Valor { get; set; }
    }

    //classe que representa os dados do grafico de pizza
    public class PieChartData
    {
        public PieChartData()
        {

        }
        public string Centro { get; set; }
        public decimal Valor { get; set; }
    }
}
