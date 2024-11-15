using System.Text.Json.Serialization;

namespace EmprestimoLivros.API.Models {
    public class LivroModel {

        public int Id { get; set; }
        public string Titulo { get; set; }
        [JsonIgnore]
        public AutorModel Autor { get; set; }

    }
}
