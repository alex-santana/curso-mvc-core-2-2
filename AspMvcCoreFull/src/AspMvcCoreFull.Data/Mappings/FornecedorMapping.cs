using AppMvcCoreBasica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspMvcCoreFull.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(keyExpression:p => p.Id);
            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Documento).IsRequired().HasColumnType("varchar(14)");

            //Relacionamento 1:1  - Fornecedor : Endereco  
            builder.HasOne(f => f.Endereco).WithOne(e => e.Fornecedor);

            //Relacionamento 1:N  - Fornecedor : Produto  
            builder.HasMany(f => f.Produtos).WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}
