using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspMvcCoreFull.App.ViewModels;

namespace AspMvcCoreFull.App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AspMvcCoreFull.App.ViewModels.FornecedorViewModel> FornecedorViewModel { get; set; }
        public DbSet<AspMvcCoreFull.App.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; }
        public DbSet<AspMvcCoreFull.App.ViewModels.EnderecoViewModel> EnderecoViewModel { get; set; }
    }
}
