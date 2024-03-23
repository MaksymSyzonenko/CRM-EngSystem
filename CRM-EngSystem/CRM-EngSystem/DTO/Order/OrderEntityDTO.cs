using CRM_EngSystem_PostgreSQL.Data.Enums;

namespace CRM_EngSystem.DTO.Order
{
    public sealed class OrderEntityDTO
    {
        public int OrderId { get; set; }
        public OrderStatusValue Status { get; set; }
        public DateTime DateTimeActiveStatusStart { get; set; }
        public DateTime? DateTimeOfferStatusStart { get; set; }
        public DateTime? DateTimeProcessingStatusStart { get; set; }
        public DateTime? DateTimeCompletedStatusStart { get; set; }
        public PriorityValue Priority { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public DateTime DateTimeUpdate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = default!;
    }
}
