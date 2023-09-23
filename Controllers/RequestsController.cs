using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RepairNinjaMVC.Data;
using RepairNinjaMVC.Data.Entities;

namespace RepairNinjaMVC.Controllers
{
    [EnableCors]
    [Route("api/[Controller]")]

    public class RequestsController : Controller
    {
        private readonly IRNRepository _repository;

        public RequestsController (IRNRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("[action]")]
        public IEnumerable<Requests> GetAllRequests(Guid landlord_id)
        {
            return _repository.GetAllRequestsByUser(landlord_id);
        }
        [HttpGet("[action]")]
        public List<Object> GetRequestsById(Guid landlord_id)
        {
            var requests = _repository.GetAllRequestsByUser(landlord_id).ToList();
           // var tenants = _repository.GetTenantsByLandlordId(landlord_id).ToList();
            var properties = _repository.GetUserProperties(landlord_id).ToList();
            var reqResults = new List<dynamic>();


            for (var r = 0; r < requests.Count(); r++)
            {
                for (var p = 0; p < properties.Count(); p++)
                {
                    if (properties[p].id == requests[r].property_id)
                    {
                        reqResults.Add(new
                        {
                            id = requests[r].id,
                            tenant_id = requests[r].tenant_id,
                            created_date = requests[r].created_date,
                            status = requests[r].status,    
                            repair_type = requests[r].type_of_service,
                            address = properties[p].address,
                            city = properties[p].city
                        });
                        break;

                    }
                }

            }
            return reqResults;
        }

        [HttpPost("[action]")]
        public IActionResult AddRequest([FromForm]Requests model)
        {
            try
            {
                var _date = DateTime.Now;
                model.created_date = _date;
                model.status = "New"; 
                model.id = Guid.NewGuid();
                _repository.AddEntity(model);
                if (_repository.SaveAll())
                {
                    return Created($"/api/requests/{model.id}", model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed{ex}");
            }
            return BadRequest("Failed to register");
        }

    }
}
