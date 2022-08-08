namespace ProductsAPI
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public Nullable<decimal> Price { get; set; }
        public string Country { get; set; } = string.Empty;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public int KindId { get; set; }
        public Kind Kind { get; set; }


    }
}
