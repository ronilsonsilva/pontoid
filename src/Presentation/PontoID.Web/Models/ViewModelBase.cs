using System;

namespace PontoID.Web.Models
{
    public class ViewModelBase
    {
        public Guid Id { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime Atualizado { get; set; }
    }
}
