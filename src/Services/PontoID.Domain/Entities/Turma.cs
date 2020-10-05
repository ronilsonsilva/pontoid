using PontoID.Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace PontoID.Domain.Entities
{
    public class Turma : EntityBase
    {
        public Turma(string nome, string descricao, TurnoEnum turno, Guid escolaId)
        {
            Nome = nome;
            Descricao = descricao;
            Turno = turno;
            EscolaId = escolaId;
        }

        protected Turma() {}

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TurnoEnum Turno { get; set; }
        public Guid EscolaId { get; set; }

        public Escola Escola { get; set; }
        public ICollection<AlunoTurma> Alunos { get; set; }
    }
}
