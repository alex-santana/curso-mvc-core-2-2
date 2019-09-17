using AppMvcCoreBasica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspMvcCoreFull.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tamanho padrão para string no banco (varchar(100)), 
            //caso não tenha mapeado um campo string ele assumirá esse tamanho
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e=> e.GetProperties().Where(p=>p.ClrType == typeof(string))))
            {
                property.Relational().ColumnType = "varchar(100)";
            }

            //Busca classe que estão relacionadas ao MeuDbContext via Reflaction ao inves de buscar cada classe
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            //Desabilitar delete em cascata
            //Percorre as relacoes das Entidades atraves das foreignKeys, 
            foreach (var realationship in modelBuilder.Model.GetEntityTypes().SelectMany(e=>e.GetForeignKeys()))
            {
                realationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
