/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: API para listagem de menu
*/

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
    public class MenuController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo reponsavel por retornar um JSON com a lista de menus cadastrados no banco. Table: ITS_MENU
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ItsMenu> Get()
        {
            var menus = _context.Menu.Where(m => m.Status).AsEnumerable();
            return menus;
        }
    }
}
