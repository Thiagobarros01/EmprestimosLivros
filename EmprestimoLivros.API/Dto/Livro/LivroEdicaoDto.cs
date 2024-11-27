using EmprestimoLivros.API.Models;
using System.Text.Json.Serialization;

namespace EmprestimoLivros.API.Dto.Livro {
    public class LivroEdicaoDto {
        public int Id { get; set; }
        public string Titulo { get; set; }
        [JsonIgnore]
        public AutorModel Autor { get; set; }
    }
}
