using EmprestimoLivros.API.Data;
using EmprestimoLivros.API.Dto;
using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace EmprestimoLivros.API.Services.Autor {
    public class AutorService : IAutorInterface {

        private readonly AppDbContext _context;

        public AutorService(AppDbContext context) {
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor) {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == idAutor);
                if (autor == null) {
                    resposta.Mensagem = "Autor não encontrado!";
                    return resposta;
                }
                resposta.Mensagem = "Autor encontrado com sucesso!";
                resposta.Dados = autor;
                return resposta;

            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorLivro(int idLivro) {

            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(l => l.Id == idLivro);
                if (livro == null) {
                    resposta.Mensagem = "Usuário não encontrado!";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Usuário encontrado com sucesso!";
                return resposta;

            }

            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto) {
            ResponseModel<List<AutorModel>> request = new ResponseModel<List<AutorModel>>();

            try {

                var autor = new AutorModel() {
                    Name = autorCriacaoDto.Name,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                request.Dados = await _context.Autores.ToListAsync();
                request.Mensagem = "Autor Criado com Sucesso";

                return request;



            }
            catch (Exception ex) {
                request.Mensagem = ex.Message;
                request.Status = false;
                return request;

            }


        }

        public async Task<ResponseModel<AutorModel>> DeletarAutor(int idAutor) {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try {
                var autor = await _context.Autores.FirstOrDefaultAsync(x => x.Id == idAutor);

                if (autor == null) {
                    resposta.Mensagem = "Autor Não encontrado!";
                    return resposta;
                }

                 _context.Autores.Remove(autor); 
                 await _context.SaveChangesAsync();

                resposta.Mensagem = "Autor Excluido com sucesso!";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex) {
                
                resposta.Mensagem =ex.Message;    
                resposta.Status = false;
                return resposta;
            
            }
            
           


        }

        public async Task<ResponseModel<AutorModel>> EditarAutor(AutorEdicaoDto autorDtoUpdate) {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try {
                var autor = await _context.Autores.Include(l => l.Livros).FirstOrDefaultAsync(a => a.Id == autorDtoUpdate.Id);
                
                if (autor == null) 

                {
                    
                    resposta.Mensagem = "Autor não encontrado!";
                    return resposta;
                }


                autor.Name = autorDtoUpdate.Name;
                autor.Sobrenome = autorDtoUpdate.Sobrenome;

                _context.Autores.Update(autor);

                await _context.SaveChangesAsync();

                resposta.Dados = autor;
                resposta.Mensagem = "Atualizado com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch(Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
                
            }

        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores() {

            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try {

                var autores = await _context.Autores.ToListAsync();
                resposta.Dados = autores;
                resposta.Mensagem = "Todos os autores foram coletados!";
                return resposta;

            }
            catch (Exception e) {

                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

      
    }
}
