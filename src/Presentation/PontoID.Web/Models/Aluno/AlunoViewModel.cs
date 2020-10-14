using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoID.Web.Models
{
    public class AlunoViewModel : ViewModelBase
    {
        [Required]
        [StringLength(maximumLength: 256, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [StringLength(maximumLength: 11, MinimumLength = 11)]
        public string Cpf { get; set; }

        public ICollection<TurmaViewModel> Turmas { get; set; }
        public Guid TurmaId { get; set; }
        public TurmaViewModel Turma { get; set; }
    }
}
