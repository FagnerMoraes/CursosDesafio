using CursosDesafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosDesafio.Domain.Interfaces.Repositories
{
    public interface IModuloRepository
    {
        Task<IEnumerable<Modulo>> ObterTodosDoCursoAsync(Curso curso);

        Task<Modulo> ObterPorIdAsync(Guid id);
        Task<bool> AdicionarAsync(Modulo modulo);
        Task<bool> AtualizarAsync(Modulo modulo);
        Task<bool> RemoverAsync(Modulo modulo);
    }
}
