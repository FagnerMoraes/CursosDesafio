using CursosDesafio.Domain.Entities;
using CursosDesafio.Domain.Interfaces.Repositories;
using CursosDesafio.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursosDesafio.Domain.Services
{
    public class AulaService : IAulaService
    {
        private readonly IAulaRepository _aulaRepository;

        public AulaService(IAulaRepository aulaRepository)
        {
            _aulaRepository = aulaRepository;
        }

        public async Task<bool> AtualizarAulaAsync(Aula aula)
        {
            if (await _aulaRepository.ObterPorIdAsync(aula.Id) != null)
                return await _aulaRepository.AtualizarAsync(aula);

            return false;
        }

        public async Task<bool> CriarAulaAsync(Aula aula)
        {
            if (await _aulaRepository.ObterPorIdAsync(aula.Id) == null)
                return await _aulaRepository.AdicionarAsync(aula);

            return false;
        }

        public async     Task<bool> RemoverAulaAsync(Aula aula)
        {
            if (await _aulaRepository.ObterPorIdAsync(aula.Id) != null)
                return await _aulaRepository.RemoverAsync(aula);

            return false;
        }
    }
}
