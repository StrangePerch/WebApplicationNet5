using System.Collections.Generic;

namespace WebApplicationNet5.Entities.Product
{
    public class Vendor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}