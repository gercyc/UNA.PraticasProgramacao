/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: classe de representacao dos saldos bancarios
*/

namespace UNA.PraticasProgramacao.Web.Pages.Shared
{
    public class SaldoContas
    {
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public decimal Saldo { get; set; }

        public SaldoContas()
        {
        }
    }
}
