using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class LotCategoryViewDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<LotRequestViewDTO>? Requests { get; set; }
    }

    public class LotCategoryCreateDTO
    {
        public string Name { get; set; }
    }

    public class LotCategoryUpdateDTO
    {
        public string Name { get; set; }
    }
}
