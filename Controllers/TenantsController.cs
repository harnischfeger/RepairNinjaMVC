using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RepairNinjaMVC.Data;
using RepairNinjaMVC.Data.Entities;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RepairNinjaMVC.Controllers
{
    [EnableCors]
    [Route("api/[Controller]")]
    public class TenantsController : Controller
    {
        private readonly IRNRepository _repository;

        public TenantsController(IRNRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Tenants>> GetById(Guid id)
        {
            try 
            {
                var tenantRecord = await _repository.GetTenantsByTenantId(id);
                if (tenantRecord != null)
                {
                    return tenantRecord; 
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed{ex}");
            }
            return BadRequest("Failed to find tenant");
        }

        [HttpGet("[action]")]
        public List<Object> GetTenantsById(Guid landlord_id)
        {
            var tenants = _repository.GetTenantsByLandlordId(landlord_id).ToList();
            var properties = _repository.GetUserProperties(landlord_id).ToList();
            var tenResults = new List<dynamic>();
 

            for ( var t = 0; t < tenants.Count(); t++ )
            {
                for ( var p = 0; p< properties.Count(); p++)
                {
                    if(properties[p].id == tenants[t].property_id)
                    {
                        tenResults.Add(new{
                        id = tenants[t].id,
                        firstname = tenants[t].firstname,
                        lastname = tenants[t].lastname,
                        email = tenants[t].email,
                        phone = tenants[t].phone,
                        address = properties[p].address,
                        city = properties[p].city
                    }); 
                        break; 
                   
                    }
                }
             
            }
            return tenResults;
        }

        [HttpPost("[action]")]
        public IActionResult Post([FromBody] Tenants model)
        {
            try
            {
                model.id = Guid.NewGuid();
                _repository.AddEntity(model);
                if (_repository.SaveAll())
                {
                    return Created($"/api/tenants/{model.id}", model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed{ex}");
            }
            return BadRequest("Failed to register");
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Tenants>> Update([FromBody] Tenants model)
        {
            try
            {
                var tenantToUpdate = await _repository.GetTenantsByTenantId(model.id);
                if (tenantToUpdate != null)
                {
                    tenantToUpdate.email = model.email;
                    tenantToUpdate.phone = model.phone;
                    _repository.UpdateEntity(tenantToUpdate);
                    if (_repository.SaveAll())
                    {
                        return Created($"/api/tenants/{tenantToUpdate.id}", tenantToUpdate);
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Failed{ex}");
            }
            return BadRequest("Failed to delete tenant");
        }
        [HttpDelete("[action]")]
        public async Task<ActionResult<Tenants>> Delete(Guid tenant_id)
        {
            try
            {
                var tenantToDelete = await _repository.DeleteTenant(tenant_id); 
                if (tenantToDelete != null) 
                {
                    return tenantToDelete; 
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Failed{ex}");
            }
            return BadRequest("Failed to delete tenant");
        }
    }
}
