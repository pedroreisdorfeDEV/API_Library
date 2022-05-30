using BibliotrecaJoia.Models.Contracts.services;
using Microsoft.AspNetCore.Mvc;
using System;
using BibliotrecaJoia.Models.ViewModels;

namespace BibliotrecaJoia.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            try
            {
                var livros = _livroService.Listar();
                return View(livros);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Create()
        {
            return View(); 
        }                   

        [HttpPost] 
        [ValidateAntiForgeryToken] 
        public IActionResult Create([Bind("Nome, Autor, Editora")] LivroViewModel livro)  
        {
            try
            {
                _livroService.Cadastrar(livro);

                return RedirectToAction("List");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        public IActionResult Edit(string? id)
        {
            var livro = _livroService.PesquisarPorId(id);

            if (string.IsNullOrEmpty(id) || livro == null)
            {
                return NotFound();
            }


            return View(livro);
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Nome, Autor, Editora")] LivroViewModel livro)
        {
            if (string.IsNullOrEmpty(livro.Id))
            {
                return NotFound();
            }

            try
            {
                _livroService.Atualizar(livro);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Details(string? id) 
        {
            var livro = _livroService.PesquisarPorId(id);

            if (string.IsNullOrEmpty(id) || livro == null)
            {
                return NotFound();
            }


            return View(livro);
        }

        public IActionResult Delete(string? id)  
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var livro = _livroService.PesquisarPorId(id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        public IActionResult Delete([Bind("Id, Nome, Autor, Editora")] LivroViewModel livro)
        {


            _livroService.Atualizar(livro);
            return RedirectToAction("List");

        }

    }
}
