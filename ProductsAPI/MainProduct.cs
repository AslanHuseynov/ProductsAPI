namespace ProductsAPI
{
    public class MainProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;

        public List<Kind> Kinds { get; set; }
    }
}
