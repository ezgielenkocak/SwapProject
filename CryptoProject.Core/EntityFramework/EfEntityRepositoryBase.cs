﻿using CryptoProject.Business.Entities;
using CryptoProject.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CryptoProject.Core.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context=new TContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State=EntityState.Added;
                context.SaveChanges();  
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context=new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State=EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context=new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public TEntity GetLast(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, int>> orderby = null)
        {
            using (var context=new TContext())
            {
                return context.Set<TEntity>().OrderBy(orderby).LastOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context=new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList(); 
            }
        }

        public void Update(TEntity entity)
        {
            using (var context=new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
