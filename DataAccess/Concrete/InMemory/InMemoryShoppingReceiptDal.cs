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
        List<Customer> _customers;

        public InMemoryShoppingReceiptDal(List<Customer> customers)
        {
            _shoppingReceipts = new List<ShoppingReceipt>();
            _customers = customers;
        }

        public void Add(ShoppingReceipt shoppingReceipt)
        {
            _shoppingReceipts.Add(shoppingReceipt);
        }

        public void ListShoppingReceipt()
        {
            // Alışverişin tamamlanmasından sonra alışveriş fişini bulur
            ShoppingReceipt shoppingReceipt = _shoppingReceipts.Find(shprcpt => shprcpt.ID.Equals(_shoppingReceipts.Count - 1));
            // Alışverişi gerçekleştiren kişiyi bulur
            Customer customer = _customers.Find(customer => customer.CustomerID.Equals(shoppingReceipt.CustomerID));

            // Alışveriş fişini yazdırır
            Console.WriteLine("\n\n");
            Console.WriteLine("---> Alışveriş Fişi <---");
            Console.WriteLine($"Fiş No : {shoppingReceipt.ID}");
            Console.WriteLine($"Müşteri Adı : {customer.Name}");
            for (int i = 0; i < shoppingReceipt.ListOfProducts.Count; i++)
            {
                Console.WriteLine($"[{i}] - {shoppingReceipt.ListOfProducts[i].ProductName} ** {shoppingReceipt.ListOfProducts[i].UnitPrice} TL");
            }
            Console.WriteLine("\n\n");
        }
    }
}
