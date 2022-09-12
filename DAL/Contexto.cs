using Microsoft.EntityFrameworkCore;
using RegistroPersona.Models;


namespace RegistroPersona.DAL { 

public class Contexto : DbContext
    {
        public DbSet<Ocupaciones>Ocupaciones{get; set;}
        public DbSet<Personas>Personas{get; set;}
        public DbSet<TiposTelefonos>TipoTelefono{get; set;}
 
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {   
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        

            modelBuilder.Entity<TiposTelefonos>().HasData(new TiposTelefonos
            {
             TiposTelefonoId = 1,
                Descripcion = "Casa"
            });

            modelBuilder.Entity<TiposTelefonos>().HasData(new TiposTelefonos
            {
             TiposTelefonoId = 2,
                Descripcion = "Celular"

            });
         }    
    }
}