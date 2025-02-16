namespace DAL.Entities
{
    public class WarehouseLot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int SupplierId { get; set; } // Reference to Supplier
        public Supplier Supplier { get; set; } // Navigation Property
        public ICollection<MedicalItem> MedicalItems { get; set; } = new List<MedicalItem>(); // Many-to-Many Relationship
    }
}
 
