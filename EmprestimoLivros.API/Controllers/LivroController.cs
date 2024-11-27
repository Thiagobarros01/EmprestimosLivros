using EmprestimoLivros.API.Dto.Livro;
using EmprestimoLivros.API.Models;
using EmprestimoLivros.API.Services.Livro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase {

        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface ilivroInterface) {
            _livroInterface = ilivroInterface;

        }


        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros() {

            var livro = await _livroInterface.ListarLivro();
            return Ok(livro);

        }


        [HttpGet("ListarLivrPorId/{IdLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ListarLivroPorId(int IdLivro) {

            var livro = await _livroInterface.BuscarLivroPorId(IdLivro);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto) {
            var livro = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livro);
        }

        [HttpDelete("DeletarLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> DeletarLivro(int idLivro) {
            var livro = await _livroInterface.ExcluirLivro(idLivro);
            return Ok(livro);
        }

    }
}
