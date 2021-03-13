using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        //burada business da asla entity framework memory vs. yok business ın bildiği tek şey IProductDal... BU HERŞEY OLABİLİR...
        IProductDal _productDal; //ctor oluşturduk

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {

            //burada varsa iş kodları bulunur,yetkisi var mı, şuna uygun mu buna uygun mu vs........ bunları geçerse alttaki komutlar çalışır...
            return _productDal.GetAll();
            
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p=>p.CategoryID==id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }
    }
}
