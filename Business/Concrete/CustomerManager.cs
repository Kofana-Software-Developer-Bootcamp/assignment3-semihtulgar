using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void AddCustomer(Customer customer)
        {
            // Müşteri listesine ekler
            _customerDal.AddCustomer(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            // Bütün müşterilerin bulunduğu listeyi verir
            return _customerDal.GetAllCustomers();
        }
    }
}
