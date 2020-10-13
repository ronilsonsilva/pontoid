using System;

namespace PontoID.Web.Models
{
    public class ExcluirAlunoTurmaCommand
    {
        public ExcluirAlunoTurmaCommand(Guid alunoId, Guid turmaId)
        {
            AlunoId = alunoId;
            TurmaId = turmaId;
        }

        public Guid AlunoId { get; set; }
        public Guid TurmaId { get; set; }
    }
}
