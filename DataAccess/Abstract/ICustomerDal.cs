using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerDal
    {
        void AddCustomer(Customer customer);

        List<Customer> GetAllCustomers();

        bool GetCustomerByIdentityNo(string identityNo);
    }
}
