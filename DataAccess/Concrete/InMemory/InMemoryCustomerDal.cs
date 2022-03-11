using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCustomerDal : ICustomerDal
    {
        List<Customer> _customers;

        public InMemoryCustomerDal(List<Customer> customer)
        {
            _customers = customer;
        }

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public bool GetCustomerByIdentityNo(string identityNo)
        {
            return _customers.Exists(customer => customer.IdentityNo == identityNo);
        }
    }
}
