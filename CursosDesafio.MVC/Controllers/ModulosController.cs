using CursosDesafio.Domain.Entities;
using CursosDesafio.Domain.Interfaces.Repositories;
using CursosDesafio.Domain.Interfaces.Services;
using CursosDesafio.Domain.Services;
using CursosDesafio.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CursosDesafio.MVC.Controllers
{
    public class ModulosController : Controller
    {
        private readonly IModuloRepository _moduloRepository;
        private readonly IModuloService _moduloService;
        private readonly ICursoRepository _cursoRepository;

        public ModulosController(IModuloRepository moduloRepository, IModuloService moduloService, ICursoRepository cursoRepository)
        {
            _moduloRepository = moduloRepository;
            _moduloService = moduloService;
            _cursoRepository = cursoRepository;
        }

        public async Task<IActionResult> ListaModulos(Curso curso)
        {
            var modulos = await _moduloRepository.ObterTodosDoCursoAsync(curso);
            return PartialView(modulos);
        }

        public async Task<IActionResult> Create(Curso curso)
        {
            ViewBag.CursoId = curso.Id;
            ViewBag.CursoNome = curso.Titulo;
            ViewBag.Tag = curso.Tag;

            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateConfirmacao(Modulo modulo)
        {

            if (ModelState.IsValid)
            {
                modulo.Id = Guid.NewGuid();
                modulo.CursoId = ViewBag.CursoId;
                var sucesso = await _moduloService.CriarModuloAsync(modulo);
                if (sucesso)
                    return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulo = await _moduloRepository.ObterPorIdAsync(id.Value);

            if (modulo == null)
            {
                return NotFound();
            }

            return View(modulo);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulo = await _moduloRepository.ObterPorIdAsync(id.Value);
            if (modulo == null)
            {
                return NotFound();
            }

            return View(modulo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Modulo modulo)
        {
            if (id != modulo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var sucesso = await _moduloService.AtualizarModuloAsync(modulo);
                if (sucesso)
                    return RedirectToAction(nameof(Index));
            }
            return View(modulo);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modulo = await _moduloRepository.ObterPorIdAsync(id.Value);

            if (modulo == null)
            {
                return NotFound();
            }

            return View(modulo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var modulo = await _moduloRepository.ObterPorIdAsync(id);
            var sucesso = await _moduloService.RemoverModuloAsync(modulo);

            if (sucesso)
                return RedirectToAction(nameof(Index));


            return View(id);
        }

    }
}
