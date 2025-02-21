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
        public Guid LotCategoryID { get; set; }
        public DateTime StockInDate {  get; set; }
        public bool Status { get; set; }
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
