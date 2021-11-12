﻿using MultiBooks_DataAccess.Data;
using MultiBooks_DataAccess.Repositoy.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MultiBooks_DataAccess.Repositoy
{
  public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
  {

    private readonly MultiBooksDbContext _db;
    internal DbSet<T> dbSet;

    public RepositoryAsync(MultiBooksDbContext db)
    {
      _db = db;
      this.dbSet = _db.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
      await dbSet.AddAsync(entity);
    }

    public async Task<T> GetAsync(int id)
    {
      return await dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = null)
    {
      IQueryable<T> query = dbSet;

      if (filter != null)
      {
        query = query.Where(filter);
      }

      if (includeProperties != null)
      {
        foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
          query = query.Include(includeProp);
        }
      }

      if (orderBy != null)
      {
        return await orderBy(query).ToListAsync();
      }
      return await query.ToListAsync();
    }

    public async Task<T> GetFirstOrDefaultAsync(
        Expression<Func<T, bool>> filter = null,
        string includeProperties = null)
    {
      IQueryable<T> query = dbSet;

      if (filter != null)
      {
        query = query.Where(filter);
      }

      if (includeProperties != null)
      {
        foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
          query = query.Include(includeProp);
        }
      }


      return await query.FirstOrDefaultAsync();
    }

    public virtual async Task RemoveAsync(int id)
    {
      T entity = await dbSet.FindAsync(id);
       RemoveAsync(entity);
    }

    // pas de Async pour Remove
    // structure utilisé pour garder standard et distinguer le Repo du Repo Async
    public virtual async Task RemoveAsync(T entity)
    {
      dbSet.Remove(entity);
    }

    // pas de Async pour RemoveRange
    // structure utilisé pour garder standard et distinguer le Repo du Repo Async
    public virtual async Task RemoveRangeAsync(IEnumerable<T> entity)
    {
      dbSet.RemoveRange(entity);
    }

  }
}
