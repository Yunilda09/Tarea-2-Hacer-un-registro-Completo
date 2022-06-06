using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public DbSet<Nombres> Nombres{get; set;}

    public Contexto(DbContextOptions<Contexto> options) : base(options){
     }
}