﻿using EmprestimoLivros.API.Models;
using System.Text.Json.Serialization;

namespace EmprestimoLivros.API.Dto.Livro {
    public class LivroCriacaoDto {

        public string Titulo { get; set; }
        [JsonIgnore]
        public AutorModel Autor { get; set; }

    }
}