using CursosDesafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosDesafio.Domain.Interfaces.Repositories
{
    public interface IAulaRepository
    {
        Task<IEnumerable<Aula>> ObterTodosAsync();
        Task<Aula> ObterPorIdAsync(Guid id);
        Task<bool> AdicionarAsync(Aula aula);
        Task<bool> AtualizarAsync(Aula aula);
        Task<bool> RemoverAsync(Aula aula);
    }
}
