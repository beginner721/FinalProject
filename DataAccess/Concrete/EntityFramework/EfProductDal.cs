using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    //IProductDal'ın istediği herşey EfEntityRepository'nin içinde var, artık hazır...
    /*Peki zaten IProductDal istekleri EfEntityRepository'nin içinde varsa neden IProductDal'ı hala kullanıyoruz ?
     * 
     * Çünkü!!! Sadece Product'ler için bulunacak işlemleri IProductDal'a ekleyeceğiz! Bunun için gereklidir....
     Yani EfEntityRepositoryBase'den temel olan ihtiyaçlarımızı alacağız ardından sadece Product'ler için gerekebilecek 
    özellikleri de IProductDal'a yazarak oradan implemente edeceğiz........*/
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context= new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDto { ProductId = p.ProductID, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock };
                return result.ToList();
            }
        }
    }
}
