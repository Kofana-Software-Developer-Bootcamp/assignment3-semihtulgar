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
            //List<Customer> customers = new List<Customer>();
            List<Customer> customers = new List<Customer>();

            // Müşteri listesini başlattık
            CustomerManager customerManager = new CustomerManager(new InMemoryCustomerDal(customers));

            // Alişveriş listelerinin tutulacağı listeyi başlattık
            ShoppingReceiptManager shoppingReceiptManager = new ShoppingReceiptManager(new InMemoryShoppingReceiptDal());

            // Kullanıcı Bilgilerini Doğrulamak için fonksiyon
            CustomerDataValidation customerDataValidation = new CustomerDataValidation();


            Console.WriteLine($"=> Market Uygulamasına Hoşgeldiniz <=");

            string identityNo;
            string name;
            string surname;

            //Console.Write("Alışveriş Yapmak İçin 11 Haneli T.C No Giriniz : ");
            string kullanicideger = "a";

            do
            {   // Sistemde Kayıtlı müşteri yoksa müşteri formuna yönlendir
                if (customerManager.GetAllCustomers().Count == 0)
                {
                    Console.WriteLine("************************************************************************************");
                    Console.WriteLine("Sistemde Kayıtlı Müşteri Bulunmamaktadır! Müşteri Kayıt Formuna Yönlendiriliyorsunuz");
                    Console.WriteLine("************************************************************************************");

                    Console.Write("11 Haneli T.C No : ");
                    identityNo = Console.ReadLine();
                    Console.Write("Adınız : ");
                    name = Console.ReadLine();
                    Console.Write("Soyadınız : ");
                    surname = Console.ReadLine();


                    // Girilen Müşteri Verileri Geçerli mi?
                    if (customerDataValidation.ValidateCustomer(identityNo, name, surname))
                    {
                        // Müşteri Listesine Müşteri Ekler
                        customerManager.AddCustomer(new Customer { CustomerID = customers.Count + 1, IdentityNo = identityNo, Name = name, Surname = surname });
                    }
                    else
                    {
                        // Girilen Kullanıcı Bilgiler Geçersiz
                        Console.WriteLine("Girdiğiniz Bilgiler Geçersiz Tekrar Deneyin");
                    }
                }
                else
                {
                    // Sistemde kayıtlı müşteri varsa alışveriş arayüzüne gönder kullanıcıdan T.C No Al
                    Console.Write("Alışveriş Yapmak İçin 11 Haneli T.C No Giriniz : ");
                    identityNo = Console.ReadLine();


                    // Müşteri sistemde kayıtlı değilse
                    if (customerManager.GetCustomerByIdentityNo(identityNo) == false)
                    {
                        Console.WriteLine($"Sistemde Kayıtlı Değilsiniz Kayıt Olun...");
                        Console.Write("11 Haneli T.C No : ");
                        identityNo = Console.ReadLine();
                        Console.Write("Adınız : ");
                        name = Console.ReadLine();
                        Console.Write("Soyadınız : ");
                        surname = Console.ReadLine();


                        // Girilen Müşteri Verileri Geçerli mi?
                        if (customerDataValidation.ValidateCustomer(identityNo, name, surname))
                        {
                            // Müşteri Listesine Müşteri Ekler
                            customerManager.AddCustomer(new Customer { CustomerID = customers.Count + 1, IdentityNo = identityNo, Name = name, Surname = surname });
                            Console.WriteLine("\n\n");
                            Customer customer = customers.Find(customer => customer.IdentityNo == identityNo);
                            Console.WriteLine($"HOŞGELDİNİZ {customer.Name} {customer.Surname}...");
                        }
                        else
                        {
                            // Girilen Kullanıcı Bilgiler Geçersiz
                            Console.WriteLine("Girdiğiniz Bilgiler Geçersiz Tekrar Deneyin");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\n");
                        Customer customer = customers.Find(customer => customer.IdentityNo == identityNo);
                        Console.WriteLine($"HOŞGELDİNİZ {customer.Name} {customer.Surname}...");
                    }

                    // Alışveriş listesinde ürünleri tutacak olan liste
                    List<Product> products = new List<Product>();
                    int totalPrice = 0;

                    do
                    {
                        // Ürünlerin belleğe eklenmesi için ProductManager sınıfının örneğini alıyoruz
                        ProductManager productManager = new ProductManager(new InMemoryProductDal());
                        // Ürünleri Listeler
                        productManager.GetAllProduct(); // Bütün ürünleri Listeler


                        string chosenProduct = Console.ReadLine();
                        int outChosenProduct;
                        // Alışverişi tamamlamak için 't'ye basmadıysa
                        if (chosenProduct != "t")
                        {
                            bool parseResult = int.TryParse(chosenProduct, out outChosenProduct);

                            // Girilen Değer İstenilen Şekilde İse
                            if (parseResult)
                            {
                                // İstenilen Ürün Listede Var mı?
                                bool productExist = productManager.GetAllProductList().Exists(product => product.ProductID == outChosenProduct);
                                if (productExist)
                                {
                                    Console.Write("Ürün Adetini Giriniz : ");
                                    int amountOfProdcut;
                                    parseResult = int.TryParse(Console.ReadLine(), out amountOfProdcut);

                                    if (parseResult == true)
                                    {
                                        totalPrice += (amountOfProdcut * (productManager.GetAllProductList().Find(p => p.ProductID == outChosenProduct)).UnitPrice);
                                        // Ürünü Sepete Ekle
                                        products.Add(productManager.GetAllProductList().Find(p => p.ProductID == outChosenProduct));
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Geçerli Bir Ürün Miktarı Giriniz!");
                                    }

                                    
                                }
                                else
                                {
                                    Console.WriteLine("*****************************");
                                    Console.WriteLine("İstenilen Ürün Listede Yok...");
                                    Console.WriteLine("*****************************");
                                }

                            }
                            else
                            {   // İstenilen Ürün No'su Doğru Bir Biçimde Girilmemişse
                                Console.WriteLine("Lütfen Doğru Biçimde Ürün No Giriniz!");
                            }

                        }
                        else
                        {
                            // Alışveriş Tamamlandıktan Sonra Hesaplamalar Yapılıyor
                            shoppingReceiptManager.AddShoppingReceipt(new ShoppingReceipt
                            {
                                ID = shoppingReceiptManager.GetShoppingReceiptsList().Count + 1,
                                CustomerID = customers.Find(c => c.IdentityNo == identityNo).CustomerID,
                                ListOfProducts = products,
                                TotalPrice = totalPrice
                            });

                            shoppingReceiptManager.ListShoppingReceipt();
                            break;
                        }


                    } while (kullanicideger != "q");


                }


            } while (kullanicideger != "q");

        }
    }
}
