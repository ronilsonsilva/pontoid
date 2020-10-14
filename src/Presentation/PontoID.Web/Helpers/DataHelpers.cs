using Microsoft.AspNetCore.Mvc.Rendering;
using PontoID.Web.Models.Enums;
using System.Collections.Generic;

namespace PontoID.Web.Helpers
{
    public static class DataHelpers
    {
        public static SelectList Turnos(TurnoEnum turnoSelected)
        {
            var items = new List<SelectListItem>();
            items.Add(new SelectListItem(text: "Matutino", value: TurnoEnum.MATUTINO.ToString()));
            items.Add(new SelectListItem(text: "Noturno", value: TurnoEnum.NOTURNO.ToString()));
            items.Add(new SelectListItem(text: "Vespertino", value: TurnoEnum.VESPERTINO.ToString()));
            return new SelectList(items, "Text", "Value", turnoSelected);
        }
    }
}
