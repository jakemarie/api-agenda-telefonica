﻿using API_listaTelefone.DataContext;
using API_listaTelefone.Models;
using API_listaTelefone.Service.PessoaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Pessoa>>> GetPessoaById(int id)
        {
            ServiceResponse<Pessoa> serviceResponse = await _pessoaService.GetPessoaById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Pessoa>>>> CreatePessoa(Pessoa novaPessoa) 
        {
            return Ok(await _pessoaService.CreatePessoa(novaPessoa));

        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<Pessoa>>>> DeletePessoa(int id)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = await _pessoaService.DeletePessoa(id);

            return Ok(serviceResponse);
            
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<Pessoa>>>> UpdatePessoa(Pessoa editadoPessoa)
        {
            ServiceResponse<List<Pessoa>> serviceResponse = await _pessoaService.UpdatePessoa(editadoPessoa);

            return Ok(serviceResponse);
        }
    }
}
