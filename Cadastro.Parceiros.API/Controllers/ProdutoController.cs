using Cadastro.Parceiros.Domain.Interfaces.Services;
using Cadastro.Parceiros.Domain.Requests;
using Cadastro.Parceiros.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Parceiros.API.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }


        [HttpGet("CadastrarProduto")]
        public async Task<IActionResult> CadastrarProduto(CadastrarProdutoRequest request)
        {
            await _produtoService.CadastrarProdutoAsync(request);
            return Ok();
        }

        [HttpGet("ObterProdutoPorId")]
        public async Task<IActionResult> ObterProdutoPorIdAsync(int id)
        {
            var result = await _produtoService.ObterProdutoPorIdAsync(id);
            return Ok(result);
        }
    }
}
