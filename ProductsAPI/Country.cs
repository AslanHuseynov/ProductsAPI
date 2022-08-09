namespace ProductsAPI
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }

        public List<ProductDetail> ProductDetails { get; set; }
    }
}
