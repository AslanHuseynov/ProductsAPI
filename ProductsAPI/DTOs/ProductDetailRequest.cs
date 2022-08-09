namespace ProductsAPI.DTOs
{
    public class ProductDetailRequest
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public Nullable<decimal> Price { get; set; }
        public int CountryId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int KindId { get; set; }
    }
}
