using CursosDesafio.Domain.Entities;
using CursosDesafio.Domain.Interfaces.Repositories;
using CursosDesafio.Domain.Interfaces.Services;
using CursosDesafio.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CursosDesafio.MVC.Controllers
{
    public class CursosController : Controller
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly ICursoService _cursoService;
        private readonly IModuloRepository _moduloRepository;
        private readonly IModuloService _moduloService;

        public CursosController(ICursoRepository cursoRepository, ICursoService cursoService, IModuloRepository moduloRepository, IModuloService moduloService)
        {
            _cursoRepository = cursoRepository;
            _cursoService = cursoService;
            _moduloRepository = moduloRepository;
            _moduloService = moduloService;
        }

        //private readonly IAulaRepository _aulaRepository;
        //private readonly IAulaService _aulaService;



        public async Task<IActionResult> Index()
        {
            var cursos = await _cursoRepository.ObterTodosAsync();
            
            return View(cursos);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                curso.Id = Guid.NewGuid();
                var sucesso = await _cursoService.CriarCursoAsync(curso);
                if (sucesso)
                    return RedirectToAction("Create","Modulos", curso);
            }
            return Create();
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            

            if (id == null)
            {
                return NotFound();
            }

            var curso = await _cursoRepository.ObterPorIdAsync(id.Value);



            if (curso == null)
            {
                return NotFound();
            }

            ViewData["Modulos"] = await _moduloRepository.ObterTodosDoCursoAsync(curso);

            return View(curso);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _cursoRepository.ObterPorIdAsync(id.Value);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sucesso = await _cursoService.AtualizarCursoAsync(curso);
                if (sucesso)
                    return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _cursoRepository.ObterPorIdAsync(id.Value);

            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var curso = await _cursoRepository.ObterPorIdAsync(id);
            var sucesso = await _cursoService.RemoverCursoAsync(curso);

            if (sucesso)
                return RedirectToAction(nameof(Index));


            return View(id  );
        }
    }
}
