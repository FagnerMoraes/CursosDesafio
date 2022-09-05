using CursosDesafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosDesafio.Domain.Interfaces.Repositories
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> ObterTodosAsync();
        Task<Curso> ObterPorIdAsync(Guid id);
        Task<bool> AdicionarAsync(Curso curso);
        Task<bool> AtualizarAsync(Curso curso);
        Task<bool> RemoverAsync(Curso curso);
    }
}
