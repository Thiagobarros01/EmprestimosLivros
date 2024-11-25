using EmprestimoLivros.API.Data;
using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.API.Services.Livro {
    public class LivroService : ILivroInterface {

        private readonly AppDbContext _context;

        public LivroService(AppDbContext context) {
           _context = context;
        }

        public Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro) {

            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivro() {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try {

                var livro = await _context.Livros.ToListAsync();
                resposta.Dados = livro;
                resposta.Mensagem = "Livros encontrados!";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex) { 
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }
    }
}
