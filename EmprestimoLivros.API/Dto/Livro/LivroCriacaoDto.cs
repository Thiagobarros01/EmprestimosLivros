using EmprestimoLivros.API.Dto.Vinculo;
using EmprestimoLivros.API.Models;
using System.Text.Json.Serialization;

namespace EmprestimoLivros.API.Dto.Livro {
    public class LivroCriacaoDto {

        public string Titulo { get; set; }
        
        public AutorVinculoDto Autor { get; set; }

    }
}
