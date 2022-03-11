using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductID = 0, ProductName="Ülker Çikolatalı Gofret",UnitPrice=3},
                new Product{ProductID = 1, ProductName="Çaykur Altın Süzme Poşet Çay",UnitPrice=8},
                new Product{ProductID = 2, ProductName="ETİ Form Kepekli Bisküvi",UnitPrice=6},
                new Product{ProductID = 3, ProductName="Ülker ÇOKOPRENS",UnitPrice=10},
                new Product{ProductID = 4, ProductName="Bioblas Botanic Oils Şampuan",UnitPrice=25},
                new Product{ProductID = 5, ProductName="Cafex Sıcak Çikolata",UnitPrice=13}
            };
        }

        public void GetAllProduct()
        {
            Console.WriteLine("---> Ürün Listesi <---");
            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine($"[{_products[i].ProductID}] {_products[i].ProductName} {_products[i].UnitPrice} TL");
            }
            Console.WriteLine("\n");
            Console.WriteLine($"Alışverişi Tamamlamak İçin 't' Tuşuna Basınız");
            Console.Write($"Seçmek istediğiniz ürünün numarasını giriniz [1-{_products.Count}] : ");
        }

        public List<Product> GetAllProductList()
        {
            return _products;
        }
    }
}
