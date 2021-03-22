using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //IEntity: IEntity olabilir veya bunu Implemente eden bir nesne olabilir...
    //class: Class olabilir değil, referans tip olabilir demek
    //new(): NEW'lenebilir olmalı, IENTİTY newlenemez!!! o sebeple direkt olarak IEntity verilemeyecek !!! bu sayede sadece somut olan entities verilebilir...
    public interface IEntityRepository<T> where T:class,IEntity,new()
        
        //<T> = çalışacağımız Tipi söyle, product ise product, category iste category
        //burada IProductDal ve ICategoryDal birleştirilmiş oldu... generic repository
        //Generic Repository Design Pattern
    {   // ** T yi sınırlamamız lazım, herşey gelemesin, yalnızca entities de bulunanlar gelsin (generic constraint, generic KISIT!)
        List<T> GetAll(Expression<Func<T,bool>> filter=null); 
        //yukarıdaki Expression ile birlikte get all fonksiyonu ister tamamını isterse filtreleme seçenekleriyle kullanılabilir
        //yani kategoriye göre ürün fiyatına göre get all kullanılabilir... hepsi için ayrı ayrı metodlar yazmamıza gerek yok
        //filter=null demek filtre vermeyebilir demektir!!!!!! 
        T Get(Expression<Func<T, bool>> filter); 
        //burası tek bir data getirmek için kullanılır, bir sistemde bir şeyin detayına gitmek için kullanılır
        //bir bankacılık uygulamasında görünen hesaplarınızın listesi görünüyor birine tıklayıp o tek hesabın detayını görüyorsunuz..
        //burada filter=null olmayacak, yani mutlaka filter vermelisin. çünkü detaya iniyoruz .....

        //expression yapısı yazılımda bir kere yazacağınız ve bir daha yazmayacağınız yapılardan biridir ....
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
