namespace ProductsAPI
{
    public class Kind
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int MainProductId { get; set; }
        public MainProduct MainProduct { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }
}
