namespace ProductsAPI
{
    public class Kind
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }
}
