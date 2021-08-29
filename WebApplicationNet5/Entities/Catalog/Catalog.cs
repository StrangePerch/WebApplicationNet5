namespace WebApplicationNet5.Entities.Catalog
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentCatalogId { get; set; }
        public Catalog ParentCatalog { get; set; }
    }
}