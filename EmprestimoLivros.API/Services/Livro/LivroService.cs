﻿using EmprestimoLivros.API.Data;
using EmprestimoLivros.API.Dto;
using EmprestimoLivros.API.Dto.Livro;
using EmprestimoLivros.API.Models;
using Microsoft.EntityFrameworkCore;
using EmprestimoLivros.API.Dto.Vinculo;

namespace EmprestimoLivros.API.Services.Livro {
    public class LivroService : ILivroInterface {

        private readonly AppDbContext _context;

        public LivroService(AppDbContext context) {
           _context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorAutorId(int AutorId) {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            
            try {

                var livro = await _context.Livros.Include(l => l.Autor).FirstOrDefaultAsync(l => l.Autor.Id == AutorId);
                if (livro == null) {
                    resposta.Mensagem = "Autor não encontrado!";
                    return resposta;
                }
                resposta.Mensagem = "Dados encontrado com sucesso!";
                resposta.Dados = livro;
                return resposta;
            }
            catch(Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
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


        
        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto) {
           ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try {

                var autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == livroCriacaoDto.Autor.Id);

                if (autor == null) {
                    resposta.Mensagem = "Impossível criar autor, autor não encontrado!";
                    return resposta;
                }

                var livro = new LivroModel() {
                    Titulo = livroCriacaoDto.Titulo,
                    Autor = autor

                };
                _context.Add(livro);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                resposta.Mensagem = "Livro criado com sucesso!";
                resposta.Status = true; 
                return resposta;


            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto) {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try {
                var livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(l => l.Id == livroEdicaoDto.Id);

                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == livroEdicaoDto.Autor.Id);


                if (livro == null) {
                    resposta.Mensagem = "Livro não encontrado!";
                    return resposta;
                    
                }


                if (autor == null) {
                    resposta.Mensagem = "Livro não encontrado!";
                    return resposta;
                }


                
                livro.Titulo = livroEdicaoDto.Titulo;
                livro.Autor = autor;
                
                
                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Status = true;
                resposta.Mensagem = "Livro atualizado com sucesso! ";
                return resposta;
                
                

            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }


        }

        public async Task<ResponseModel<LivroModel>> ExcluirLivro(int idLivro) {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try {
                var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == idLivro);

                if (livro == null) {
                    resposta.Mensagem = "Id Livro não encontrado!";   
                    return resposta;
                }
                
                _context.Remove(livro);
                _context.SaveChanges();
                resposta.Mensagem = "Livro excluído com sucesso!";
                resposta.Dados = livro;
                resposta.Status = false;

                return resposta;


            }
            catch(Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        
        public async Task<ResponseModel<List<LivroModel>>> ListarLivro() {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try {

                var livro = await _context.Livros.Include(a => a.Autor).ToListAsync();
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
