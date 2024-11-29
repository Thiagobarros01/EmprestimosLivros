using EmprestimoLivros.API.Dto.Autor;
using EmprestimoLivros.API.Models;

namespace EmprestimoLivros.API.Services.Autor
{
    public interface IAutorInterface {

        Task<ResponseModel<List<AutorModel>>> ListarAutores();

        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);

        Task<ResponseModel<AutorModel>> BuscarAutorPorLivro(int idLivro);

        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);

        Task<ResponseModel<AutorModel>> DeletarAutor(int idAutor);

        Task<ResponseModel<AutorModel>> EditarAutor(AutorEdicaoDto editarAutorDto);
    }
}
