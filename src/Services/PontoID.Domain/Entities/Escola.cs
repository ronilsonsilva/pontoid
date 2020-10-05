using System.Collections.Generic;

namespace PontoID.Domain.Entities
{
    public class Escola : EntityBase
    {
        protected Escola() { }

        public Escola(string nome, long codigoINEP)
        {
            Nome = nome;
            CodigoINEP = codigoINEP;
        }

        public string Nome { get; set; }
        public long CodigoINEP { get; set; }

        public ICollection<Turma> Turmas { get; set; }
    }
}
