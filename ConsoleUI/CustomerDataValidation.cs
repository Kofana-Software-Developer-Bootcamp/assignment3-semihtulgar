using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class CustomerDataValidation
    {
        public bool ValidateCustomer(string identityNo, string name, string surname)
        {
            if ((identityNo.Length == 11) && !string.IsNullOrEmpty(identityNo) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
