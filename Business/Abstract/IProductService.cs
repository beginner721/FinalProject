using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max); // şu fiyatlar aralığında ürünleri getir ...
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult Add(Product product); //burada data yok o sebeple IResult, diğerlerinde data var...
        IDataResult<Product> GetById(int productId);
    }
}
