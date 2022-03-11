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
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void GetAllProduct()
        {
            _productDal.GetAllProduct();            
        }

        public List<Product> GetAllProductList()
        {
            return _productDal.GetAllProductList();
        }
    }
}
