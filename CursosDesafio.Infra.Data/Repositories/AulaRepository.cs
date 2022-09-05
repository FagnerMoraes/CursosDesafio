using CursosDesafio.Domain.Entities;
using CursosDesafio.Domain.Interfaces.Repositories;
using CursosDesafio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosDesafio.Infra.Data.Repositories
{
    public class AulaRepository : IAulaRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AulaRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Aula>> ObterTodosAsync()
        {
            return await _applicationDbContext.Aulas
                 .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Aula> ObterPorIdAsync(Guid id)
        {
            return await _applicationDbContext.Aulas
               .AsNoTracking()
               .FirstOrDefaultAsync(p => p.Id == id);
        }
             

        public async Task<bool> AdicionarAsync(Aula aula)
        {
            _applicationDbContext.Add(aula);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AtualizarAsync(Aula aula)
        {
            _applicationDbContext.Update(aula);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        

        public async Task<bool> RemoverAsync(Aula aula)
        {
            _applicationDbContext.Remove(aula);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
    }
}
