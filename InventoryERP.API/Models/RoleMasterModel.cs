namespace InventoryERP.API.Models
{
    public class RoleMasterModel
    {
        public string  Id { get; set; } = string.Empty;
        public string RoleType { get; set; } = string.Empty;

    }
    public class AddRoleMaster
    {
        public string RoleType { get; set; } =string.Empty;
    }
}
