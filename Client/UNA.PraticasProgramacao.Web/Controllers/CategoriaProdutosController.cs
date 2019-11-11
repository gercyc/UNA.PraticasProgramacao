using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using UNA.PraticasProgramacao.Web.Data;
using UNA.PraticasProgramacao.Core.Entidades;

namespace UNA.PraticasProgramacao.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoriaProdutosController : Controller
    {
        private ApplicationDbContext _context;

        public CategoriaProdutosController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var categoriaproduto = _context.CategoriaProduto.Select(i => new {
                i.IdCategoria,
                i.CodigoCategoria,
                i.DescricaoCategoria
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "IdCategoria" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(categoriaproduto, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new CategoriaProduto();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.CategoriaProduto.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.IdCategoria);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.CategoriaProduto.FirstOrDefaultAsync(item => item.IdCategoria == key);
            if(model == null)
                return StatusCode(409, "CategoriaProduto not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.CategoriaProduto.FirstOrDefaultAsync(item => item.IdCategoria == key);

            _context.CategoriaProduto.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(CategoriaProduto model, IDictionary values) {
            string ID_CATEGORIA = nameof(CategoriaProduto.IdCategoria);
            string CODIGO_CATEGORIA = nameof(CategoriaProduto.CodigoCategoria);
            string DESCRICAO_CATEGORIA = nameof(CategoriaProduto.DescricaoCategoria);

            if(values.Contains(ID_CATEGORIA)) {
                model.IdCategoria = Convert.ToInt32(values[ID_CATEGORIA]);
            }

            if(values.Contains(CODIGO_CATEGORIA)) {
                model.CodigoCategoria = Convert.ToString(values[CODIGO_CATEGORIA]);
            }

            if(values.Contains(DESCRICAO_CATEGORIA)) {
                model.DescricaoCategoria = Convert.ToString(values[DESCRICAO_CATEGORIA]);
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}