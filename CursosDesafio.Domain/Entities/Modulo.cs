

using System.Reflection;

namespace CursosDesafio.Domain.Entities
{
    public class Modulo
    {
        
        public Guid Id { get; set; }
        
        public Guid CursoId { get; set; }

        public string? TituloDoModulo { get; set; }
        public short OrdemDeExibicao { get; set; }
        public Curso Curso { get; set; }


        public ICollection<Aula>? Aulas { get; set; }
    }
}