using RepairNinjaMVC.Data.Entities;

namespace RepairNinjaMVC.Data
{
    public interface IRNRepository
    {
        void AddEntity(object model);
        void UpdateEntity(object model);
        IEnumerable<Users> GetAllUsers();
        IEnumerable<Users> GetUserRecord(string userName, string password);
        IEnumerable<Properties> GetAllProperties();
        IEnumerable<Properties> GetUserProperties(Guid id);
        IEnumerable<Categories> GetAllCatTypes(string cat_itemname);
        IEnumerable<Requests> GetAllRequestsByUser(Guid landlord_id);
        IEnumerable<Tenants> GetTenantsByLandlordId(Guid landlord_id);
        Task<Tenants?> GetTenantsByTenantId(Guid tenant_id);
        Task<Tenants?> DeleteTenant(Guid tenant_id);
        bool SaveAll();
    }
}