using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            using (NorthwindContext context =new NorthwindContext())
                /*using: kullanımı bitince direkt olarak garbage collectore gider ve kendini sistemden atar, belleği temizler
        Context işyükünü arttırır,pahalıdır. doğrudan newlemek yerine using kullanmak performansımızı artıracaktır. */
            {
                var addedEntity = context.Entry(entity); //veri kaynağımızla ilişkilendirdik(referansı yakaladık) peki bunu ne yapalım ?
                addedEntity.State = EntityState.Added; //eklenecek bir nesnedir, EntityState.Added 
                context.SaveChanges(); //işlemleri gerçekleştir... yani yukarıdaki Added gerçekleştirilir.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
      
            {
                var deletedEntity = context.Entry(entity); 
                deletedEntity.State = EntityState.Deleted; 
                context.SaveChanges(); 
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); 
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() //filter eşittir null ise burası değilse alt kısım çalışır
                    : context.Set<Product>().Where(filter).ToList(); // ternary operatorudur.
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())

            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
