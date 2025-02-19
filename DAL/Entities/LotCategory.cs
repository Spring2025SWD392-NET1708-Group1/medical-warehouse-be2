using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class LotCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<LotRequest>? Requests { get; set; }
    }
}
