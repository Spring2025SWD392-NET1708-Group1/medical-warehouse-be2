using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class LotRequest
    {
        public Guid LotRequestId { get; set; }
        public DateTime StockInDate { get; set; }
        public string Quality { get; set; } = string.Empty;
        public Guid ItemId { get; set; }
        public required Item Item { get; set; }
        public bool Status { get; set; } = false;
        public Guid StaffId { get; set; }
        public required User Staff { get; set; }
    }
}
