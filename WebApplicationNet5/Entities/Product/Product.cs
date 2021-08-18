namespace WebApplicationNet5.Entities.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}