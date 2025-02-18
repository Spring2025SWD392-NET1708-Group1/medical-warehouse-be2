namespace BLL.DTOs
{
    public class ItemDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
