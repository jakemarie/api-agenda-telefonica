using API_listaTelefone.Models;
using Microsoft.EntityFrameworkCore;

namespace API_listaTelefone.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        }

        public DbSet <Pessoa> Pessoa { get; set; }
        public DbSet <Telefone> Telefone { get; set; }

    }
}
