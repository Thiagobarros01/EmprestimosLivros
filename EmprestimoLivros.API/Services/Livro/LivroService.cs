using EmprestimoLivros.API.Data;
using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EmprestimoLivros.API.Services.Livro {
    public class LivroService : ILivroInterface {

        private readonly AppDbContext _context;

        public LivroService(AppDbContext context) {
           _context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro) {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try {

                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(l => l.Id == idLivro);

                if (livro == null) {

                    resposta.Mensagem = "Livro nao encontrado!";
                    return resposta;
                
                }

                resposta.Dados = livro;
                resposta.Status = true;
                resposta.Mensagem = "Livro encontrado";

                return resposta;

            }

            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
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
