using Cadastro.Parceiros.Domain.Interfaces.Services;
using Cadastro.Parceiros.Domain.Requests;
using Cadastro.Parceiros.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Parceiros.API.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("ObterClientePorCpf/{cpf}")]
        [ProducesResponseType(typeof(ObterClientePorCpfResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterClientePorCdBolsa(string cpf)
        {
            var cliente = await _clienteService.ObterClientePorCpf(cpf);
            return Ok(cliente);
        }

        [HttpGet("CadastrarCliente")]
        [ProducesResponseType(typeof(ObterClientePorCpfResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterClientePorCdBolsa(CadastrarClienteRequest request)
        {
            await _clienteService.CadastrarCliente(request);
            return Ok();
        }
    }
}
