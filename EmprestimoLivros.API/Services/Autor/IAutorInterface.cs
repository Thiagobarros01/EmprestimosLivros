using EmprestimoLivros.API.Models;

namespace EmprestimoLivros.API.Services.Autor {
    public interface IAutorInterface {

        Task<ResponseModel<List<AutorModel>>> ListarAutores();

        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);

        Task<ResponseModel<AutorModel>> BuscarAutorPorLivro(int idLivro);
    }
}
