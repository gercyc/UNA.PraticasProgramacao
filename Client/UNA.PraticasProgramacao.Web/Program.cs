/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Pr�ticas de Programa��o
    Professor: Luiz Eduardo Carneiro
    Per�odo: 2� semestre/2019
    Autores: Gercy Campos
    Informa��es: Classe de inicializa��o do host
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace UNA.PraticasProgramacao.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
