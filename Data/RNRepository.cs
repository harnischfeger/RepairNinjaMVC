using Microsoft.EntityFrameworkCore;
using RepairNinjaMVC.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepairNinjaMVC.Data
{
    public class RNRepository : IRNRepository
    {
        private readonly RepairNinjaContext _ctx;

        public RNRepository(RepairNinjaContext ctx)
        {
            _ctx = ctx;
        }
        //shared
        public void AddEntity(object model)
        {
            _ctx.Add(model); 

        }

        public void UpdateEntity(object model)
        {
            _ctx.Update(model);

        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0; 
        }
        //user 
        public IEnumerable<Users> GetAllUsers()
        {
            return _ctx.Users
                    .OrderBy(cd => cd.created_date)
                    .ToList();
        }
        public IEnumerable<Users> GetUserRecord(string username, string password)
        {
            return _ctx.Users
                    .Where(u => u.user_id == username && u.password == password)
                    .ToList();
        }
        //properties

        public IEnumerable<Properties> GetAllProperties() {

            return _ctx.Properties.ToList();

        }
        public IEnumerable<Properties> GetUserProperties(Guid id)
        {
            return _ctx.Properties
                    .Where(p => p.landlord_id == id)
                    .ToList();
        }

        public IEnumerable<Categories> GetAllCatTypes(string cat_itemname)
        {
            return _ctx.Categories
                    .Where(p => p.cat_name == cat_itemname)
                    .ToList();
        }

        public IEnumerable<Requests> GetAllRequestsByUser(Guid id)
        {
           return _ctx.Requests
                .Where(r=> r.landlord_id == id)
                .ToList();
        }
        public IEnumerable<Tenants> GetTenantsByLandlordId(Guid landlord_id)
        {
            return _ctx.Tenants
                 .Where(t => t.landlord_id == landlord_id)
                 .ToList();
        }

        public async Task<Tenants?> GetTenantsByTenantId(Guid tenant_id)
        {
            var results = await _ctx.Tenants.FirstOrDefaultAsync(t => t.id == tenant_id); 
            if(results != null)
            {
                return results; 
            }
            return null; 
        }


        public async Task<Tenants?> DeleteTenant(Guid tenant_id)
        {
            var result = await _ctx.Tenants
                .FirstOrDefaultAsync(t => t.id == tenant_id);
            if(result != null)
            {
                _ctx.Tenants.Remove(result);
                await _ctx.SaveChangesAsync();
                return result;
            }
            return null;     
        }
    }
}
