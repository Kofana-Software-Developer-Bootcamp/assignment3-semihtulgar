using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCustomerDal : ICustomerDal
    {
        List<Customer> _customer;

        public InMemoryCustomerDal(List<Customer> customer)
        {
            _customer = customer;
        }

        public void AddCustomer(Customer customer)
        {
            _customer.Add(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customer;
        }
    }
}
