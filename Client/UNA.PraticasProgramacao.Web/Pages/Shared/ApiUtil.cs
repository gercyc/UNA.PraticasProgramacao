/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: classe com metodos uteis na aplicação
*/

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Core.Entidades.Entidades;
using UNA.PraticasProgramacao.Web.BaseApis;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages.Shared
{
    public class ApiUtil
    {
        public async static Task<List<ItsMenu>> GetMenusList(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ItsMenu>>(apiResponse);
                }
            }
        }
 
        public static IEnumerable<LineChartData> GetChartData(ApplicationDbContext context, UserManager<IdentityUser> userManager, ClaimsPrincipal user)
        {
            var lancamentos = context.LancamentoFinanceiro.AsEnumerable().OrderBy(f => f.DataVencimento);
            var id = userManager.GetUserId(user);
            var q = from d in lancamentos.Where(l => l.UserId == id)
                    group d by new { Data = d.DataVencimento.Month.ToString().PadLeft(2, '0') + "/" + d.DataVencimento.Year }
                    into grp
                    select new LineChartData { Periodo = grp.Key.Data, Valor = grp.Sum(g => g.TipoLancamento == Core.Entidades.Entidades.EnumTipoLancamento.Pagar ? g.ValorLancamento * -1 : g.ValorLancamento) };

            return q.AsEnumerable();
        }
        public static IEnumerable<PieChartData> GetPieChartData(ApplicationDbContext context, UserManager<IdentityUser> userManager, ClaimsPrincipal user)
        {
            var lancamentos = context.LancamentoFinanceiro.Include(l => l.CentroCusto).AsEnumerable().OrderBy(f => f.DataVencimento);
            var id = userManager.GetUserId(user);
            var q = from d in lancamentos.Where(l => l.UserId == id && l.TipoLancamento == Core.Entidades.Entidades.EnumTipoLancamento.Pagar && l.IdCentroCusto.HasValue)
                    group d by new { Centro = d.CentroCusto.NomeCentroCusto }
                    into grp
                    select new PieChartData { Centro = grp.Key.Centro, Valor = grp.Sum(g => g.TipoLancamento == Core.Entidades.Entidades.EnumTipoLancamento.Pagar ? g.ValorLancamento * -1 : g.ValorLancamento) };

            return q.AsEnumerable();
        }

        public static IEnumerable<SaldoContas> GetSaldoContas(ApplicationDbContext context, UserManager<IdentityUser> userManager, ClaimsPrincipal user)
        {
            var id = userManager.GetUserId(user);

            var lancamentos = context.LancamentoFinanceiro
                .Include(l => l.ContaBancaria)
                .Where(l => l.UserId == id && l.DataPagamento.HasValue)
                .OrderByDescending(f => f.DataPagamento)
                .AsEnumerable();

            var lancs = from d in lancamentos
                        group d by new { d.ContaBancaria.Agencia, d.ContaBancaria.Banco, d.ContaBancaria.NumeroConta }
                        into grp
                        select new SaldoContas
                        {
                            Agencia = grp.Key.Agencia,
                            Banco = grp.Key.Banco,
                            Conta = grp.Key.NumeroConta,
                            Saldo = grp.Sum(d => d.TipoLancamento == EnumTipoLancamento.Pagar ? d.ValorLancamento * -1 : d.ValorLancamento)
                        };

            return lancs.AsEnumerable();
        }
    }
}
