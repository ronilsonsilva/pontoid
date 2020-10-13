using System.ComponentModel.DataAnnotations;

namespace PontoID.Web.Models
{
    public class EscolaViewModel : ViewModelBase
    {
        [Required]
        [StringLength(maximumLength: 256, MinimumLength = 4)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Código INEP")]
        public long CodigoINEP { get; set; }
    }
}
