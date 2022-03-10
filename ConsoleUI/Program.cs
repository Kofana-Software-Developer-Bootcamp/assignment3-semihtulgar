using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program başladığında yeni bir müşteri listesi tanımlıyoruz.
            List<Customer> customers = new List<Customer>();

            // Ürünlerin belleğe eklenmesi için ProductManager sınıfının örneğini alıyoruz
            ProductManager productManager = new ProductManager(new InMemoryProductDal());
            // Ürünleri Listeler
            productManager.GetAll();

            // Müşteri listesini başlattık
            CustomerManager customerManager = new CustomerManager(new InMemoryCustomerDal(customers));

            // Sistemde kayıtlı müşteri sayısını verir
            //Console.WriteLine($"Sistemde Kayıtlı Müşteri Sayısı : {customerManager.GetAllCustomers().Count}");


            if (customerManager.GetAllCustomers().Count == 0)
            {
                Console.WriteLine("Müşteri Kayıt Ekranı");
                   
            }

            // Kullanıcı Bilgilerini Doğrulamak için fonksiyon
            CustomerDataValidation customerDataValidation = new CustomerDataValidation();





        }
    }
}
