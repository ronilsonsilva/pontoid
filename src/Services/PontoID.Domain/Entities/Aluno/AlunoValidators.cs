using FluentValidation;
using System;

namespace PontoID.Domain.Entities
{
    public class AlunoValidators : AbstractValidator<Aluno>
    {
        public AlunoValidators()
        {
            RuleFor(x => x.DataNascimento)
                .NotNull().WithMessage("Data de nascimento não foi preenchido")
                .NotEqual(DateTime.MinValue).WithMessage("Data de nascimento inválida")
                .GreaterThan(DateTime.Now).WithMessage($"Data de nasciemnto deve ser menor ou igual a {DateTime.Now}");

            RuleFor(x => x.Cpf)
                .NotNull().WithMessage("CPF não foi fornecido")
                .NotEmpty().WithMessage("CPF não foi fornecido")
                .Must(CPFValido).WithMessage("CPF inválido")
                .Length(11,11).WithMessage("CPF inválido");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome deve ser fornecido")
                .Length(2, 256).WithMessage("Nome deve ter entre 2 e 256 caracteres");
        }


        protected static bool CPFValido(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
