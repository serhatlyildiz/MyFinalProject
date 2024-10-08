﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class, IEntity ,new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entitiy)
        {
            using (TContext context = new TContext())
            {
                var addedEntitiy = context.Entry(entitiy);
                addedEntitiy.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entitiy)
        {
            using (TContext context = new TContext())
            {
                var deletedEntitiy = context.Entry(entitiy);
                deletedEntitiy.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext contex = new TContext())
            {
                return filter == null
                    ? contex.Set<TEntity>().ToList()
                    : contex.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entitiy)
        {
            using (TContext context = new TContext())
            {
                var updatedEntitiy = context.Entry(entitiy);
                updatedEntitiy.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
