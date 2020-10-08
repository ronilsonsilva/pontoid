using System;

namespace PontoID.Domain.Shared.Request
{
    public class AlunoRequest
    {
        public Guid? TurmaId { get; set; }
        public Guid? EscolaId { get; set; }
    }
}
