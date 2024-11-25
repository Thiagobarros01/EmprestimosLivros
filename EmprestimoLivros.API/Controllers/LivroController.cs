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

    }
}
