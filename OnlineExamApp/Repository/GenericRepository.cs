﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using System.Linq;
using OnlineExamApp.Data;

namespace OnlineExamApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            this.context = context;
        }

        public virtual void Add(T entity)
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var data = context.Set<T>().Find(id);
            if (data != null)
            {
                context.Remove(data);
                context.SaveChanges();
            }

        }

        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().FirstOrDefault(filter);
        }

        public virtual IList<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? context.Set<T>().ToList()
                : context.Set<T>().Where(filter).ToList();
        }

        public virtual void Update(T entity)
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
