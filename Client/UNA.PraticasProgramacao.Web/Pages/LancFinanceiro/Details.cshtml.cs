﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages.LancFinanceiro
{
    public class DetailsModel : PageModel
    {
        private readonly UNA.PraticasProgramacao.Web.Data.ApplicationDbContext _context;

        public DetailsModel(UNA.PraticasProgramacao.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public LancamentoFinanceiro LancamentoFinanceiro { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LancamentoFinanceiro = await _context.LancamentoFinanceiro
                .Include(l => l.CentroCusto)
                .Include(l => l.ContaBancaria)
                .Include(l => l.Parceiro).FirstOrDefaultAsync(m => m.IdLancamentoFinanceiro == id);

            if (LancamentoFinanceiro == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
