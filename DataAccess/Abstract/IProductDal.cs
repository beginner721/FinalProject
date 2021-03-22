﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
        //IEntity Repositoryi Product için yapılandırdık ......
    {
        List<ProductDetailDto> GetProductDetails(); //işte bu yüzden IProductDal kullanılır, producta özel bir fonksiyon verdik
        //bunu gidip Ef katmanında implemente edip kullanalım
        
    }
}
