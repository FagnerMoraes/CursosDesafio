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
    public class ModuloService : IModuloService
    {

        private readonly IModuloRepository _moduloRepository;

        public ModuloService(IModuloRepository moduloRepository)
        {
            _moduloRepository = moduloRepository;
        }

        public async Task<bool> AtualizarModuloAsync(Modulo modulo)
        {
            if (await _moduloRepository.ObterPorIdAsync(modulo.Id) != null)
                return await _moduloRepository.AtualizarAsync(modulo);

            return false;
        }

        public async Task<bool> CriarModuloAsync(Modulo modulo)
        {
            if (await _moduloRepository.ObterPorIdAsync(modulo.Id) == null)
                return await _moduloRepository.AdicionarAsync(modulo);

            return false;
        }

        public async Task<bool> RemoverModuloAsync(Modulo modulo)
        {
            if (await _moduloRepository.ObterPorIdAsync(modulo.Id) != null)
                return await _moduloRepository.RemoverAsync(modulo);

            return false;
        }
    }
}
