using API_listaTelefone.Models;
using API_listaTelefone.Service.PessoaService;
using API_listaTelefone.Service.TelefoneService;
using Microsoft.AspNetCore.Mvc;

namespace API_listaTelefone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonesController : ControllerBase
    {
        private ITelefoneService _telefoneService;
        public TelefonesController(ITelefoneService telefoneService)
        {
            _telefoneService = telefoneService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Telefone>>>> CreateTelefone(Telefone novaTelefone)
        {
            return Ok(await _telefoneService.CreateTelefone(novaTelefone));

        }

        [HttpGet]
        public async Task<ActionResult<List<Telefone>>> Get()
        {
            return Ok(_telefoneService.GetTelefone());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Telefone>>> GetTelefoneById(int id)
        {
            ServiceResponse<Telefone> serviceResponse = await _telefoneService.GetTelefoneById(id);

            return Ok(serviceResponse);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Telefone>>>> UpdatePessoa(Telefone editadoTelefone)
        {
            ServiceResponse<List<Telefone>> serviceResponse = await _telefoneService.UpdateTelefone(editadoTelefone);

            return Ok(serviceResponse);
        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<Telefone>>>> DeleteTelefone(int id)
        {
            ServiceResponse<List<Telefone>> serviceResponse = await _telefoneService.DeleteTelefone(id);

            return Ok(serviceResponse);

        }
    }
}
