using PontoID.Web.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PontoID.Web.Models
{
    public class TurmaViewModel : ViewModelBase
    {
        [Required]
        [StringLength(maximumLength: 256, MinimumLength = 2)]
        public string Nome { get; set; }

        [StringLength(maximumLength: 4096)]
        [Display(Name = "Descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public TurnoEnum Turno { get; set; }
        public string NomeEscola { get; set; }

        public Guid EscolaId { get; set; }
        public EscolaViewModel Escola { get; set; }
    }
}
