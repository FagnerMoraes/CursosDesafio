using CursosDesafio.Domain.Entities;

namespace CursosDesafio.MVC.Models {

    public class CommonViewModel
    {
        public Curso curso {get;set;}
        public Modulo modulo { get; set; }
        public Aula aula { get; set; }
}
}