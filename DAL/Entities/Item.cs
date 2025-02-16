
namespace DAL.Entities
{
    public class MedicalItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Manufacturer { get; set; }
    }
}
 
