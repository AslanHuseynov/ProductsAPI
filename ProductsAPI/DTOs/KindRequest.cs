namespace ProductsAPI.DTOs
{
    public class KindRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
