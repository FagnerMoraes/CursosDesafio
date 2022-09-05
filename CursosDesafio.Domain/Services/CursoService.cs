using CursosDesafio.Domain.Entities;
using CursosDesafio.Domain.Interfaces.Repositories;
using CursosDesafio.Domain.Interfaces.Services;

namespace CursosDesafio.Domain.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<bool> AtualizarCursoAsync(Curso curso)
        {
            if (await _cursoRepository.ObterPorIdAsync(curso.Id) != null)
                return await _cursoRepository.AtualizarAsync(curso);

            return false;
        }

        public async Task<bool> CriarCursoAsync(Curso curso)
        {
            if (await _cursoRepository.ObterPorIdAsync(curso.Id) == null)
                return await _cursoRepository.AdicionarAsync(curso);

            return false;
        }

        public async Task<bool> RemoverCursoAsync(Curso curso)
        {
            if (await _cursoRepository.ObterPorIdAsync(curso.Id) != null)
                return await _cursoRepository.RemoverAsync(curso);

            return false;
        }
    }
}
