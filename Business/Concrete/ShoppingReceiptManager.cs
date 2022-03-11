using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ShoppingReceiptManager : IShoppingReceiptService
    {
        IShoppingReceiptDal _shoppingReceiptDal;

        public ShoppingReceiptManager(IShoppingReceiptDal shoppingReceiptDal)
        {
            _shoppingReceiptDal = shoppingReceiptDal;
        }

        public void AddShoppingReceipt(ShoppingReceipt shoppingReceipt)
        {
            _shoppingReceiptDal.Add(shoppingReceipt);

        }

        public List<ShoppingReceipt> GetShoppingReceiptsList()
        {
            return _shoppingReceiptDal.GetShoppingReceiptsList();
        }

        public void ListShoppingReceipt()
        {
            _shoppingReceiptDal.ListShoppingReceipt();
        }
    }
}
