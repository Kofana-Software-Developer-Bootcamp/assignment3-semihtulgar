using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ShoppingReceipt : IEntity
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public List<Product> ListOfProducts { get; set; }
    }
}
