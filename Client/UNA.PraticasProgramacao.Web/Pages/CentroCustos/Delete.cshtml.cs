﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UNA.PraticasProgramacao.Core.Entidades;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Pages.CentroCustos
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CentroCusto CentroCusto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CentroCusto = await _context.CentroCusto.FirstOrDefaultAsync(m => m.IdCentroCusto == id);

            if (CentroCusto == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (HasChild(id))
                return Partial("_HasRelations");

            if (id == null)
                return NotFound();

            CentroCusto = await _context.CentroCusto.FindAsync(id);

            if (CentroCusto != null)
            {
                _context.CentroCusto.Remove(CentroCusto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        private bool HasChild(int? id)
        {
            return _context.LancamentoFinanceiro.Where(l => l.IdCentroCusto == id).FirstOrDefault() != null;
        }
    }
}
