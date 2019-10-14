using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UNA.PraticasProgramacao.Core.Entidades.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<UNA.PraticasProgramacao.Core.Entidades.LancamentoFinanceiro> Lancamentos { get; set; }

        public string ReceberProx30Dias { get; set; }
        public string PagarProx30Dias { get; set; }
        public string PercentPagarReceber { get; set; }
        public string QtdPagar { get; set; }
        public string QtdReceber { get; set; }


        public async Task OnGetAsync()
        {

            Lancamentos = await _context.LancamentoFinanceiro.ToListAsync();

            ReceberProx30Dias = Lancamentos.Where(l => l.TipoLancamento == EnumTipoLancamento.Receber
            && l.DataVencimento > DateTime.Now
            && l.DataVencimento < DateTime.Now.AddDays(30)
            && !l.DataPagamento.HasValue).Sum(l => l.ValorLancamento.Value).ToString("N2");

            PagarProx30Dias = (Lancamentos.Where(l => l.TipoLancamento == EnumTipoLancamento.Pagar
            && l.DataVencimento > DateTime.Now
            && l.DataVencimento < DateTime.Now.AddDays(30)
            && !l.DataPagamento.HasValue).Sum(l => l.ValorLancamento.Value) * -1).ToString("N2");

            double pagar = Lancamentos.Where(l => l.TipoLancamento == EnumTipoLancamento.Pagar
            && !l.DataPagamento.HasValue).Count();
            double receber = Lancamentos.Where(l => l.TipoLancamento == EnumTipoLancamento.Receber
            && !l.DataPagamento.HasValue).Count();


            PercentPagarReceber = (receber / pagar * 100).ToString(new CultureInfo("en-US"));

            QtdPagar = ((int)pagar).ToString();
            QtdReceber = ((int)receber).ToString();

        }
    }
}
