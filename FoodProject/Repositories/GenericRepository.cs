using FoodProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodProject.Repositories
{
    public class GenericRepository<T>  where T: class , new()
    {

        Context context = new Context();

        public List<T> List()
        {
            return context.Set<T>().ToList();
        }

        public void Add(T c)
        {
            context.Set<T>().Add(c);
            context.SaveChanges();
        }

        public void Delete(T c)
        {
            context.Set<T>().Remove(c);
            context.SaveChanges();
        }

        public void Update(T c)
        {
            context.Set<T>().Update(c);
            context.SaveChanges();
        }

        public T TGet(int id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> TList(string p)
        {
            return  context.Set<T>().Include(p).ToList();
        }

        public List<T> IlgiliList(Expression<Func<T,bool>> filter )   // herahngi bir sutuna gore arama islemi yapabilirim
        {
            return context.Set<T>().Where(filter).ToList() ;
        }

    }
}
