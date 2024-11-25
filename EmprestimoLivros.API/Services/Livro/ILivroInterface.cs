using EmprestimoLivros.API.Models;

namespace EmprestimoLivros.API.Services.Livro {
    public interface ILivroInterface {

        public Task<ResponseModel<List<LivroModel>>> ListarLivro();

        public Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);


    }
}
