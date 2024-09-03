using API_listaTelefone.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using System.Xml;

namespace API_listaTelefone.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        }

        public DbSet <Pessoa> Pessoa { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasSequence<int>("dbo.sequencia_pessoa")
            .StartsAt(1)
            .IncrementsBy(1);

            modelBuilder.Entity<Pessoa>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEXT VALUE FOR dbo.sequencia_pessoa");

            modelBuilder.Entity<Pessoa>()
            .HasMany(p => p.Telefones)
            .WithOne(t => t.Pessoa)
            .HasForeignKey(t => t.PessoaId);
        }

    }
}
