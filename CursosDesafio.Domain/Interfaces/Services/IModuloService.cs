using CursosDesafio.Domain.Entities;


namespace CursosDesafio.Domain.Interfaces.Services
{
    public interface IModuloService
    {
        Task<bool> CriarModuloAsync(Modulo modulo);
        Task<bool> AtualizarModuloAsync(Modulo modulo);
        Task<bool> RemoverModuloAsync(Modulo modulo);
    }
}
