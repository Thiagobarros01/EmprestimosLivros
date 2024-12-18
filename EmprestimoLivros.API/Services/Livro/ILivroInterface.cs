﻿using EmprestimoLivros.API.Models;
using EmprestimoLivros.API.Dto.Livro;

namespace EmprestimoLivros.API.Services.Livro {
    public interface ILivroInterface {

        public Task<ResponseModel<List<LivroModel>>> ListarLivro();

        public Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);

        public Task<ResponseModel<LivroModel>> BuscarLivroPorAutorId(int AutorId);

        public Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto);

        public Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto);

        public Task<ResponseModel<LivroModel>> ExcluirLivro(int idLivro);
    }
}
