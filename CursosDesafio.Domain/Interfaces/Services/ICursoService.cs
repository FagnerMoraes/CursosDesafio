using CursosDesafio.Domain.Entities;

namespace CursosDesafio.Domain.Interfaces.Services
{
    public interface ICursoService
    {
        Task<bool> CriarCursoAsync(Curso curso);
        Task<bool> AtualizarCursoAsync(Curso curso);
        Task<bool> RemoverCursoAsync(Curso curso);

    }
}
