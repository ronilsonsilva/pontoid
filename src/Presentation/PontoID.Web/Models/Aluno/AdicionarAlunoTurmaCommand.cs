using System;

namespace PontoID.Web.Models
{
    public class AdicionarAlunoTurmaCommand
    {
        public AdicionarAlunoTurmaCommand(Guid alunoId, Guid turmaId)
        {
            AlunoId = alunoId;
            TurmaId = turmaId;
        }

        public Guid AlunoId { get; set; }
        public Guid TurmaId { get; set; }
    }
}
