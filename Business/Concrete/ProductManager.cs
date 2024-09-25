using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _IProductDal;

        public ProductManager(IProductDal productDal)
        {
            _IProductDal = productDal;
        }
        public List<Product> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?

            return _IProductDal.GetAll();
        }
    }
}
