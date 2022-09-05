
namespace CursosDesafio.Domain.Entities
{
    public class Curso
    {
        public Guid Id { get; set; }
        public string? Tag { get; set; }
        public string? Titulo { get; set; }
        public int DuracaoEmMinutos { get; set; }

        public ICollection<Modulo>? Modulos { get; set; }

        
    }
}
