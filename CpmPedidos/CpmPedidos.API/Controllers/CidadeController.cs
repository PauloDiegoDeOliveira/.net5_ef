﻿using CpmPedido.Interface;
using CpmPedidos.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : AppBaseController
    {
        public CidadeController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        // 1 controller
        [HttpGet]
        public dynamic Get()
        {
            return GetService<ICidadeRepository>().Get();
        }

        [HttpPost]
        public int Criar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>().Criar(model);
        }

        [HttpPut]
        public int Alterar(CidadeDTO model)
        {
            return GetService<ICidadeRepository>().Alterar(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Excluir(int id)
        {
            //Teste
            //var consulta = GetService<ICidadeRepository>().Excluir(id);

            //return consulta == false ? NotFound(new { mensagem = titulo + " Inválido ou inexistente.", status = 2 }) : (IActionResult)new OkObjectResult(GetService<ICidadeRepository>().Excluir(id));

            return GetService<ICidadeRepository>().Excluir(id);
        }

        // Procurar com paginação de dados 
        [HttpGet]
        [Route("search/{text}/{pagina?}")]
        public dynamic GetSearch(string text, int pagina = 1, [FromQuery] string ordem = "")
        {
            return GetService<ICidadeRepository>().Search(text, pagina, ordem);
        }

        // Ordem crescente ou decrescente
        [HttpGet]
        [Route("asc-desc")]
        public dynamic Get([FromQuery] string ordem = "")
        {
            return GetService<ICidadeRepository>().Get(ordem);
        }
    }
}