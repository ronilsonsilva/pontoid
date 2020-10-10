using System;

namespace PontoID.Domain.Shared.ViewModels
{
    public class AlunoViewModel : ViewModelBase
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
    }
}
