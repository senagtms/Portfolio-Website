using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using My_CV.Models.Entity;

namespace My_CV.Repositories
{
    public class GenericRepository<T> where T: class,new()
    {
        DB_CvEntities2 db = new DB_CvEntities2();
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void Tadd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void Tdelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();

        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);

        }
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>>where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}