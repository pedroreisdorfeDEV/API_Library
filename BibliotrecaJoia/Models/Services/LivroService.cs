using System;
using System.Collections.Generic;
using BibliotrecaJoia.Models.Contracts.services;
using System.Threading.Tasks; 
using BibliotrecaJoia.Models.ViewModels;
using BibliotrecaJoia.Models.Contracts.Repositories;

namespace BibliotrecaJoia.Models.Services
{                                       
                                         
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;   

        public LivroService(ILivroRepository livroRepository) 
        { 
            _livroRepository = livroRepository;
        }

        public void Atualizar(LivroViewModel livro)
        {
            try
            {
                _livroRepository.Atualizar(livro); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cadastrar(LivroViewModel livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(string id)
        {
            try
            {
                _livroRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroViewModel> Listar()
        {
            try
            {
                return _livroRepository.Listar(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public LivroViewModel PesquisarPorId(string id)
        {
            try
            {
                return _livroRepository.PesquisarPorId(id); 
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
