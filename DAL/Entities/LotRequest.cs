using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class LotRequest
    {
        [Key]
        public Guid LotRequestId { get; set; }
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Quality { get; set; } = string.Empty;
        public LotRequestEnums? Status { get; set; }


    }
}
