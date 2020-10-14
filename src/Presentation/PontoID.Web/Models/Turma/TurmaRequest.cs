using System;

namespace PontoID.Web.Models
{
    public class TurmaRequest
    {
        public TurmaRequest() {}

        public TurmaRequest(Guid? alunoId, Guid? escolaId)
        {
            AlunoId = alunoId;
            EscolaId = escolaId;
        }

        public Guid? AlunoId { get; set; }
        public Guid? EscolaId { get; set; }
    }
}
