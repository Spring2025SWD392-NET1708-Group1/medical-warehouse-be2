using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class WarehouseLot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SupplierId { get; set; } // Reference to Supplier
        public LotStatus Status { get; set; } // Status Object
    }

    public enum LotStatus
    {
        Pending,     // Waiting for approval or processing
        InStock,     // Available in the warehouse
        Reserved,    // Allocated for an order
        Shipped,     // Sent out from the warehouse
        Expired      // No longer usable
    }
}
/*public ICollection<MedicalItem> MedicalItems { get; set; } = new List<MedicalItem>(); // Many-to-Many Relationship*/
/**/
/*public Supplier Supplier { get; set; } // Navigation Property*/
