namespace InventoryERP.API.Models
{
    public class AddPartyModel
    {
        public string PartyName { get; set; } 
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string GSTNo { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string WhatsAppNo { get; set; } = string.Empty;
        public string EmailID { get; set; } = string.Empty;
        public string AAdharCardNo { get; set; } = string.Empty;
        public string PanCardNo { get; set; } = string.Empty;
        public string AdditionField { get; set; } = string.Empty;
        public decimal OpeningBalance { get; set; } = 0;
        public DateTime? OpeningBalanceDate { get; set; } = DateTime.Now;
        public string PartyType { get; set; } 
    }
}
