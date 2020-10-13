using System.Collections.Generic;

namespace PontoID.Web.Models
{
    public class ResponseApi<T>
    {
        public bool Ok { get; set; }
        public T Entity { get; set; }
        public List<T> Entities { get; set; }
        public List<string> Errors { get; set; }
        public string AllErros { get; set; }
        public List<string> Mensagens { get; set; }
        public string AllMensagens { get; set; }
    }
}
