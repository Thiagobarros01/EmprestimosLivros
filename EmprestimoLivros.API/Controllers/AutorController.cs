﻿using EmprestimoLivros.API.Models;
using EmprestimoLivros.API.Services.Autor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase {

        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface) {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores() {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
       public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor) {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }


        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro) {
            var autor = await _autorInterface.BuscarAutorPorLivro(idLivro);
            return Ok(autor);
        }
    
    }



}
