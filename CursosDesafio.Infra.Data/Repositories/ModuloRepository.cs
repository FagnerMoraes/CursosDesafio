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
    public class ModuloRepository : IModuloRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ModuloRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

    //    public async Task<IEnumerable<Modulo> ObterPorIdAsync(Guid id)
    //    {
    //        var modulos = await _applicationDbContext.Modulos.Where(x => x.Curso.Id == id).AsNoTracking().ToListAsync();

    //        return modulos;

    //        return await _applicationDbContext.Modulos
    //            .Include(p => p.Aulas)
    //           .AsNoTracking()
    //           .FirstOrDefaultAsync(p => p.Id == id);
    //}

    public async Task<IEnumerable<Modulo>> ObterTodosDoCursoAsync(Curso curso)
        {
            return await _applicationDbContext.Modulos
                .Where(p => p.Curso.Id == curso.Id)
                .Include(p => p.Curso)
                .Include(p => p.Aulas)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> AdicionarAsync(Modulo modulo)
        {
            _applicationDbContext.Add(modulo);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AtualizarAsync(Modulo modulo)
        {
            _applicationDbContext.Update(modulo);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
        
        public async Task<bool> RemoverAsync(Modulo modulo)
        {
            _applicationDbContext.Remove(modulo);
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public async Task<Modulo> ObterPorIdAsync(Guid id)
        {
            return await _applicationDbContext.Modulos
                .Include(p => p.Aulas)
               .AsNoTracking()
               .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
