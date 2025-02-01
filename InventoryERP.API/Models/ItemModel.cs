namespace InventoryERP.API.Models
{
    public class ItemModel
    {
        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public string? CompanyName { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? PurDiscPer { get; set; }  
        public decimal? PurDiscAMT { get; set; }  
        public decimal? SalesPrice { get; set; }
        public decimal? SalesDiscPer { get; set; } 
        public decimal? SalesDiscAMT { get; set; } 
        public decimal? Discount { get; set; }
        public string? GSTNo { get; set; }
        public string? HSNCODE { get; set; }
        public string? BATCHNO { get; set; }
        public int? UnityId { get; set; }
        public decimal? Taxes { get; set; }
        public decimal? DiscountPer { get; set; }
        public decimal? DiscountAMT { get; set; }
        public UnityList unitylist { get; set; }

    }

    public class UnityList
    {
        public int? Box { get; set; }
        public int? Piece { get; set; }
    }
}
