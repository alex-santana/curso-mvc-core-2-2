using AppMvcCoreBasica.Models;
using AspMvcCoreFull.Business.Interfaces;
using AspMvcCoreFull.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspMvcCoreFull.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context):base(context)
        {

        }
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            //Inclui o Fornecedor no resultado
            return await _context.Produtos
                .AsNoTracking()
                .Include(p => p.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await _context.Produtos
                .AsNoTracking()
                .Include(p => p.Fornecedor)
                .OrderBy(p => p.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid FornecedorId)
        {
            //return await _context.Produtos.AsNoTracking().Include(p => p.Fornecedor).Where(p => p.FornecedorId == FornecedorId).ToListAsync();
            return await Buscar(p => p.FornecedorId == FornecedorId);
        }
    }
}
