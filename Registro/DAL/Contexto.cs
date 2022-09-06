using Microsoft.EntityFrameworkCore;
using Registro.Models;

namespace Registro.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Ocupaciones> Ocupaciones { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

    }
}