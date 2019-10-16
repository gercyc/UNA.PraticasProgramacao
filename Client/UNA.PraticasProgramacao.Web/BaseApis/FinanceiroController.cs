using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<LineChartData> GetChartData()
        {
            var lancamentos = _context.LancamentoFinanceiro.AsEnumerable().OrderBy(f => f.DataVencimento);

            var q = from d in lancamentos
                    group d by new { Data = d.DataVencimento.Month.ToString().PadLeft(2, '0') + "/" + d.DataVencimento.Year }
                    into grp
                    select new LineChartData { Periodo = grp.Key.Data, Valor = grp.Sum(g => g.TipoLancamento == Core.Entidades.Entidades.EnumTipoLancamento.Pagar ? g.ValorLancamento.Value * -1 : g.ValorLancamento.Value) };

            return q.AsEnumerable();
        }

        [HttpGet("PieChartData")]
        public IEnumerable<PieChartData> GetPieChartData()
        {
            var lancamentos = _context.LancamentoFinanceiro.Include(l => l.CentroCusto).AsEnumerable().OrderBy(f => f.DataVencimento);

            var q = from d in lancamentos
                    group d by new { Centro = d.CentroCusto.NomeCentroCusto }
                    into grp
                    select new PieChartData { Centro = grp.Key.Centro, Valor = grp.Sum(g => g.TipoLancamento == Core.Entidades.Entidades.EnumTipoLancamento.Pagar ? g.ValorLancamento.Value * -1 : g.ValorLancamento.Value) };

            return q.AsEnumerable();
        }


    }
    public class LineChartData
    {
        public LineChartData()
        {

        }
        public string Periodo { get; set; }
        public decimal Valor { get; set; }
    }
    public class PieChartData
    {
        public PieChartData()
        {

        }
        public string Centro { get; set; }
        public decimal Valor { get; set; }
    }
}
