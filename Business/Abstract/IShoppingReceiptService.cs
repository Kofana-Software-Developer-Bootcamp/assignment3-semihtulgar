using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IShoppingReceiptService
    {
        void AddShoppingReceipt(ShoppingReceipt shoppingReceipt);

        void ListShoppingReceipt();

        List<ShoppingReceipt> GetShoppingReceiptsList();
    }
}
