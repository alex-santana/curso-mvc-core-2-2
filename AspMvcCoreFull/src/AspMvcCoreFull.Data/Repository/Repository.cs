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
    /// <summary>
    /// Classe de repositorio generica, só pode ser herdada e não instanciada
    /// </summary>
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        //protected pq todos que herdarem poderão ter acesso ao contexto
        protected readonly MeuDbContext _context;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(MeuDbContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }


        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity obj)
        {
            DbSet.Update(obj);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {

            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
