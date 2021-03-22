using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //bir tane tablo ver(product veya customer ?), bir tane de çalışacağın context tipini ver (database)
    //öyle bir yapı tasarlayacağız ki burada, artık yeni tablo eklenince get all vs. gibi fonksiyonlar için tekrar kod yazmayacağız....
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity> //hangi tabloyu verirsem onun entityrepository'si olacak
        where TEntity:class,IEntity,new() //TEntity'nin kurallarını belirledik, class olacak, IEntity'den gelecek ve Newlenebilir olacak....
        where TContext: DbContext,new() //entityframework un DbContext'ini inherite etmeli!!!
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            /*using: kullanımı bitince direkt olarak garbage collectore gider ve kendini sistemden atar, belleği temizler
    Context işyükünü arttırır,pahalıdır. doğrudan newlemek yerine using kullanmak performansımızı artıracaktır. */
            {
                var addedEntity = context.Entry(entity); //veri kaynağımızla ilişkilendirdik(referansı yakaladık) peki bunu ne yapalım ?
                addedEntity.State = EntityState.Added; //eklenecek bir nesnedir, EntityState.Added 
                context.SaveChanges(); //işlemleri gerçekleştir... yani yukarıdaki Added gerçekleştirilir.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())

            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
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
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList() //filter eşittir null ise burası değilse alt kısım çalışır
                    : context.Set<TEntity>().Where(filter).ToList(); // ternary operatorudur.
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())

            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
