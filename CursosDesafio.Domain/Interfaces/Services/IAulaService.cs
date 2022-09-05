using CursosDesafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosDesafio.Domain.Interfaces.Services
{
    public interface IAulaService
    {
        Task<bool> CriarAulaAsync(Aula aula);
        Task<bool> AtualizarAulaAsync(Aula aula);
        Task<bool> RemoverAulaAsync(Aula aula);
    }
}
