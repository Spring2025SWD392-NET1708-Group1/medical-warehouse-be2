using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LotRequestViewDTO
    {
        public Guid LotRequestId { get; set; }
        public DateTime StockInDate { get; set; }
        public string Quality { get; set; } = string.Empty;
        public required ItemViewDTO Item { get; set; }
        public string StaffName { get; set; } = string.Empty;
    }

    public class LotRequestCreateDTO
    {
        public DateTime StockInDate { get; set; }
        public string Quality { get; set; } = string.Empty;
        public Guid ItemId { get; set; }
        public Guid StaffId { get; set; }
    }

    public class LotRequestUpdateDTO
    {
        public DateTime StockInDate { get; set; }
        public bool Status { get; set; }
        public string Quality { get; set; } = string.Empty;
        public Guid ItemId { get; set; }
    }

}