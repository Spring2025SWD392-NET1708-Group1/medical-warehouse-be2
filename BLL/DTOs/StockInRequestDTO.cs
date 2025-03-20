using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class StockInRequestViewDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal ImportPricePerUnit { get; set; }
        public string? Note { get; set; }
        public DateTime ExpiryDate { get; set; }
        public StockInRequestStatus Status { get; set; }
        public TransactionStatus PaymentStatus {  get; set; } 
        public DateTime CreatedAt { get; set; }
    } 

    public class StockInRequestCreateDTO
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal ImportPricePerUnit { get; set; }
        public string? Note { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
    public class StockInRequestUpdateDTO
    {
        public StockInRequestStatus? Status { get; set; }
        public TransactionStatus? PaymentStatus { get; set; }
    }

}
