using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);

        List<Customer> GetAllCustomers();
    }
}
