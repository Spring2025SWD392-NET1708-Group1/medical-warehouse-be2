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
        public Guid LotCategoryID { get; set; }
        public string LotCategoryName { get; set; }  // Lấy tên danh mục
        public DateTime StockInDate { get; set; }
        public bool Status { get; set; }
        public List<ItemViewDTO> Items { get; set; } = new List<ItemViewDTO>();  // Chi tiết danh sách Item
    }

    public class LotRequestCreateDTO
    {
        public Guid LotCategoryID { get; set; }
        public DateTime StockInDate { get; set; }
        public bool Status { get; set; }
        public List<Guid> ItemIds { get; set; } = new List<Guid>();  // Gửi danh sách ID của các Item
    }

    public class LotRequestUpdateDTO
    {
        public DateTime StockInDate { get; set; }
        public bool Status { get; set; }
        public List<Guid> ItemIds { get; set; } = new List<Guid>();  // Cho phép cập nhật danh sách Items
    }
}