/*
    UNA - Tecnologia em Analise e Desenvolvimento de sistemas
    Disciplina:Práticas de Programação
    Professor: Luiz Eduardo Carneiro
    Período: 2º semestre/2019
    Autores: Gercy Campos
    Informações: Classe responsavel por fazer a exclusao de dados do usuario
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using UNA.PraticasProgramacao.Web.Data;

namespace UNA.PraticasProgramacao.Web.Areas.Identity.Pages.Account.Manage
{
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;
        private readonly ApplicationDbContext _context;

        public DeletePersonalDataModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<DeletePersonalDataModel> logger,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public bool RequirePassword { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível localizar o usuário através do ID:  '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível localizar o usuário através do ID:  '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            if (RequirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(user, Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "Senha incorreta.");
                    return Page();
                }
            }

            //remove os lancamentos do usuario
            var lancs = _context.LancamentoFinanceiro.Where(l => l.UserId == user.Id);
            if (lancs.Count() > 0)
            {
                foreach (var l in lancs)
                {
                    _context.LancamentoFinanceiro.Remove(l);
                }
                await _context.SaveChangesAsync();
            }

            //remove os centros de custo do usuario
            var centros = _context.CentroCusto.Where(l => l.UserId == user.Id);
            if (centros.Count() > 0)
            {
                foreach (var c in centros)
                {
                    _context.CentroCusto.Remove(c);
                }
                await _context.SaveChangesAsync();
            }

            //remove as contas bancarias do usuario
            var contas = _context.ContaBancaria.Where(l => l.UserId == user.Id);
            if (contas.Count() > 0)
            {
                foreach (var c in contas)
                {
                    _context.ContaBancaria.Remove(c);
                }
                await _context.SaveChangesAsync();
            }

            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Erro inesperado ao remover o usuário '{userId}'.");
            }

            await _signInManager.SignOutAsync();

            _logger.LogInformation("O usuário com ID '{UserId}' teve seus dados excluídos do servidor.", userId);

            return Redirect("~/");
        }
    }
}
