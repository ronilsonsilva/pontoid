using System;

namespace PontoID.Domain.Shared.Request
{
    public class TurmaRequest
    {
        public Guid? AlunoId { get; set; }
        public Guid? EscolaId { get; set; }
    }
}
