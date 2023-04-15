using Cadastro.Parceiros.Domain.Interfaces.Services;
using Cadastro.Parceiros.Domain.Requests;
using Cadastro.Parceiros.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Parceiros.API.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _CategoriaService;

        public CategoriaController(ICategoriaService CategoriaService)
        {
            _CategoriaService = CategoriaService;
        }


        [HttpGet("CadastrarCategoria")]
        public async Task<IActionResult> CadastrarCategoria(CadastrarCategoriaRequest1 request)
        {
            await _CategoriaService.CadastrarCategoria(request);
            return Ok();
        }
    }
}
