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
    public class CursoRepository : ICursoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CursoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<Curso>> ObterTodosAsync()
        {
            return await _applicationDbContext.Cursos
                .Include(p => p.Modulos)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Curso> ObterPorIdAsync(Guid id)
        {
            return await _applicationDbContext.Cursos
                .Include(p => p.Modulos)
               .AsNoTracking()
               .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> AdicionarAsync(Curso curso)
        {
            _applicationDbContext.Add(curso);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AtualizarAsync(Curso curso)
        {
            _applicationDbContext.Update(curso);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
       

        public async Task<bool> RemoverAsync(Curso curso)
        {
            _applicationDbContext.Remove(curso);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

    }
}
