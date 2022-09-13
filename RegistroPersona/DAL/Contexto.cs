using Microsoft.EntityFrameworkCore;
using RegistroPersona.Models;


namespace RegistroPersona.DAL { 

public class Contexto : DbContext
    {
        public DbSet<Ocupaciones>Ocupaciones{get; set;}
        public DbSet<Personas>Personas{get; set;}
        
 
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {   
        }
        
    }    

}
