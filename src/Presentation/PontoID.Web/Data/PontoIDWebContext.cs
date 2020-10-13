using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PontoID.Web.Models;

namespace PontoID.Web.Data
{
    public class PontoIDWebContext : DbContext
    {
        public PontoIDWebContext (DbContextOptions<PontoIDWebContext> options)
            : base(options)
        {
        }

        public DbSet<PontoID.Web.Models.EscolaViewModel> EscolaViewModel { get; set; }

        public DbSet<PontoID.Web.Models.TurmaViewModel> TurmaViewModel { get; set; }

        public DbSet<PontoID.Web.Models.AlunoViewModel> AlunoViewModel { get; set; }
    }
}
