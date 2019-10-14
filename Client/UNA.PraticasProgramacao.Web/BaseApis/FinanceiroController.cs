using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.BaseApis
{
    [Route("/api/[controller]")]
    [ApiController]
    public class FinanceiroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FinanceiroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Menu
        [HttpGet]
        public IEnumerable<LancamentoFinanceiro> Get()
        {
            var menus = _context.LancamentoFinanceiro.AsEnumerable();
            return menus;
        }
        [HttpGet("ChartData")]
        public IEnumerable<ChartData> GetChartData()
        {
            var menus = _context.LancamentoFinanceiro.AsEnumerable();

            var q = from d in menus
                    group d by new { Data = d.DataVencimento.Month.ToString().PadLeft(2, '0') + "/" + d.DataVencimento.Year }
                    into grp
                    select new ChartData { Periodo = grp.Key.Data, Valor = grp.Sum(g => g.TipoLancamento == Core.Entidades.Entidades.EnumTipoLancamento.Pagar ? g.ValorLancamento.Value * -1 : g.ValorLancamento.Value) };

            return q.AsEnumerable();
        }

        public class ChartData
        {
            public ChartData()
            {

            }
            public string Periodo { get; set; }
            public decimal Valor { get; set; }
        }
    }
}
