using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: db tabloları ile proje classlarımızı bağlamamıza yarar...
    public class NorthwindContext:DbContext
    {
        /*ADIM1:
        aşağıdaki OnConfiguring methodu bizim projemiz hangi veritabanlı ile ilişkili olduğunu belirteceğimiz kısımdır... */ 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true"); //tam burada hangi veritabanına bağlanacağımızı göstereceğiz
            /*@ koymamızın sebebi ters slash'ların c#da anlamı vardır @ koyarak bunu ortadan kaldırırız
              gerçek projelerde serverin karşısında bir IP yazacaktır... 
            Database=Northwind, nortvind DB mizi seçer...
            trusted_connection=true şifresiz bağlantı demektir, bazen kullanıcı adı ve şifre de olabilir */ 
        }

        //context yukarıda hangi db ye baglanacagını buldu peki hangi class hangi tabloya karşılık gelir onu yapalım

        public DbSet<Product> Products  { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
