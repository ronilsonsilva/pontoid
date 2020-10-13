using System;

namespace PontoID.Web.Models
{
    public class AlunoRequest
    {
        public Guid? TurmaId { get; set; }
        public Guid? EscolaId { get; set; }
    }
}
