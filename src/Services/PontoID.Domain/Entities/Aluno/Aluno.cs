using PontoID.Domain.Shared;
using System;
using System.Collections.Generic;

namespace PontoID.Domain.Entities
{
    public class Aluno : EntityBase
    {
        protected Aluno() {}

        public Aluno(string nome, DateTime dataNascimento, string cpf)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
        }

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }

        public ICollection<AlunoTurma> Turmas { get; set; }

        public override bool IsValid()
        {
            var validator = new AlunoValidators();
            this.Validators = validator.Validate(this);
            return this.Validators.IsValid;
        }
    }
}
