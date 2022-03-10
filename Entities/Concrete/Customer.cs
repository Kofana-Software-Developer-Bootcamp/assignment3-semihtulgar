using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerID { get; set; }
        public string IdentityNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
