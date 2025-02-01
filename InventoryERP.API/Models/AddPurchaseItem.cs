namespace InventoryERP.API.Models
{
    public class AddPurchaseItem
    {
        public string BillNo { get; set; }
        public DateTime? BillDate { get; set; } 
        public int? CompanyId { get; set; }
        public int? TaxTypeId { get; set; }
        public int? ItemId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? UnityId { get; set; } 
        public decimal? DiscountPer { get; set; }
        public decimal? DiscountAMT { get; set; } 
        public int? GSTTypeId { get; set; } 
        public decimal? GSTPer { get; set; } 
        public decimal? TotalAmount { get; set; } 
        public string CreatedBy { get; set; } = string.Empty;
    }
}
