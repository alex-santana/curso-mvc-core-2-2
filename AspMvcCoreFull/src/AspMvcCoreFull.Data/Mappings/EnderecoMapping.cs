using AppMvcCoreBasica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspMvcCoreFull.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(keyExpression:p => p.Id);
            builder.Property(p => p.Logradouro).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Bairro).IsRequired().HasColumnType("varchar(50)");
            builder.Property(p => p.Cidade).IsRequired().HasColumnType("varchar(50)");
            builder.Property(p => p.Cep).IsRequired().HasColumnType("varchar(8)");
            builder.Property(p => p.Complemento).HasColumnType("varchar(100)");
            builder.Property(p => p.Numero).HasColumnType("varchar(20)");

            builder.ToTable("Endereco");
        }
    }
}
