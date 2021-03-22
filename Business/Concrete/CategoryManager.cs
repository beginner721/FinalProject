using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal; //_categoryDal sağ tıklayarak ctoru aşağıya açıyoruz

        public CategoryManager(ICategoryDal categoryDal)
        { /*bu şu demektir: ben kategori manager olarak veri erişim katmanına bağımlıyım ama biraz zayıf bağımlılığım var 
            çünkü interface üzerinden/referans üzerinden bağımlıyım
            o sebeple kurallara uyduğun sürece dataaccess katmanında istediğin kadar at koşturabilirsin demektir...*/

            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //varsa iş kodlarımızı yazarız.
            return _categoryDal.GetAll(); //_categoryDal interface olduğu için oradaki bütün fonksiyonlar gelir, getall vs. vs.
            
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryID == categoryId);   
        }
    }
}
