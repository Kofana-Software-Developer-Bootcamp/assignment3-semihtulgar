using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IShoppingReceiptDal
    {
        void Add(ShoppingReceipt shoppingReceipt);

        void ListShoppingReceipt();

        List<ShoppingReceipt> GetShoppingReceiptsList();
    }
}
