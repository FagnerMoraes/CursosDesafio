
namespace CursosDesafio.Domain.Entities
{
    public class Aula
    {
        protected Aula()
        {
        }
        public Aula(Guid id,
                    string tituloDaAula,
                    string descricaoDaAula,
                    string urlVideoDaAula) : this()
        {
            Id = id;            
            TituloDaAula = tituloDaAula;
            DescricaoDaAula = descricaoDaAula;
            UrlVideoDaAula = urlVideoDaAula;
        }

        public Guid Id { get; set; }
        public string? TituloDaAula { get; set; }
        public string? DescricaoDaAula { get; set; }
        public string? UrlVideoDaAula { get; set; }

        public Modulo? Modulo { get; set; }

    }
}