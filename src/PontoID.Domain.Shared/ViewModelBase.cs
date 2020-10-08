using System;

namespace PontoID.Domain.Shared
{
    public class ViewModelBase
    {
        public Guid Id { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime Atualizado { get; set; }
    }
}
