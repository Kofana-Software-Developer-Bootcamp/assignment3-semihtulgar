using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryShoppingReceiptDal : IShoppingReceiptDal
    {
        List<ShoppingReceipt> _shoppingReceipts;
        

        public InMemoryShoppingReceiptDal()
        {
            _shoppingReceipts = new List<ShoppingReceipt>();
        }

        public void Add(ShoppingReceipt shoppingReceipt)
        {
            _shoppingReceipts.Add(shoppingReceipt);
        }

        public List<ShoppingReceipt> GetShoppingReceiptsList()
        {
            return _shoppingReceipts;
        }

        public void ListShoppingReceipt()
        {
            // Alışverişin tamamlanmasından sonra alışveriş fişini bulur
            //ShoppingReceipt shoppingReceipt = _shoppingReceipts.Find(shprcpt => shprcpt.ID.Equals(_shoppingReceipts.Count - 1));

            ShoppingReceipt shoppingReceipt = _shoppingReceipts.FindLast(shprcpt => shprcpt.ID == GetShoppingReceiptsList().Count);

            // Alışveriş fişini yazdırır
            Console.WriteLine("\n\n");
            Console.WriteLine("---> Alışveriş Fişi <---");
            Console.WriteLine($"Fiş No : {shoppingReceipt.ID}");
            for (int i = 0; i < shoppingReceipt.ListOfProducts.Count; i++)
            {
                Console.WriteLine($"[{i}] - {shoppingReceipt.ListOfProducts[i].ProductName} ** {shoppingReceipt.ListOfProducts[i].UnitPrice} TL");
            }
            Console.WriteLine("\n\n");
        }
    }
}
