﻿using AppMvcCoreBasica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspMvcCoreFull.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(keyExpression:p => p.Id);
            builder.Property(p => p.Nome).IsRequired().HasColumnType("varchar(100)");
            builder.Property(p => p.Descricao).IsRequired().HasColumnType("varchar(1000)");
            builder.Property(p => p.Imagem).IsRequired().HasColumnType("varchar(100)");

            builder.ToTable("Produtos");
        }
    }
}
