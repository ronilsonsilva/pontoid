﻿using PontoID.Domain.Shared.Enums;
using System;

namespace PontoID.Domain.Shared.ViewModels
{
    public class TurmaViewModel : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public TurnoEnum Turno { get; set; }
        public Guid EscolaId { get; set; }
    }
}
