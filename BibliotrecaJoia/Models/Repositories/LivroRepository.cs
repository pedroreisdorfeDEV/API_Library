using BibliotrecaJoia.Models.Contracts.Repositories;
using BibliotrecaJoia.Models.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;


namespace BibliotrecaJoia.Models.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        public void Atualizar(LivroViewModel livro)
        {
            var objPesquisa = PesquisarPorId(livro.Id);
            ContextDataFake.Livros.Remove(objPesquisa);  

            objPesquisa.Nome = livro.Nome; 
            objPesquisa.Editora = livro.Editora;
            objPesquisa.Autor = livro.Autor;

            Cadastrar(objPesquisa);
        }

        public void Cadastrar(LivroViewModel livro)
        {
            ContextDataFake.Livros.Add(livro);  
        }

        public void Excluir(string id)
        {
            var objPesquisa = PesquisarPorId(id);
            ContextDataFake.Livros.Remove(objPesquisa);
        }

        public List<LivroViewModel> Listar()
        {
            var livros = ContextDataFake.Livros; 
            return livros.OrderBy(p => p.Nome).ToList(); 
        }

        public LivroViewModel PesquisarPorId(string id)
        {
            var livro = ContextDataFake.Livros.FirstOrDefault(p => p.Id == id);
            return livro;
        }
    }
}
