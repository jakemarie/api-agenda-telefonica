﻿using API_listaTelefone.DataContext;
using API_listaTelefone.Models;
using API_listaTelefone.Service.PessoaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_listaTelefone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> Get() 
        {
            return Ok(_pessoaService.GetPessoa());
        }


    }
}
