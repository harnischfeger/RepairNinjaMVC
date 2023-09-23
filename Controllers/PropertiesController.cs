using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RepairNinjaMVC.Data;
using RepairNinjaMVC.Data.Entities;
using System.Linq;

namespace RepairNinjaMVC.Controllers
{
    [EnableCors]
    [Route("api/[Controller]")]
    public class PropertiesController : Controller
    {     
        private readonly IRNRepository _repository;

        public PropertiesController(IRNRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("[action]")]
        public IEnumerable<Properties> GetProperties()
        {
            return _repository.GetAllProperties();
        }
        [HttpGet("[action]")]
        public IEnumerable<Properties> GetById(Guid id)
        {
            try
            {
                var properties = _repository.GetUserProperties(id);
                if (properties.Count() != 0)
                {
                    return properties;
                }
                else
                {
                    throw new ApplicationException("No Properties Found");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Request Failed: " + ex);
            }
        }
        [HttpPost("[action]")]
        public IActionResult Post([FromForm] Properties model)
        {
            try
            {
                var _date = DateTime.Now;
                model.created_date = _date;
                model.id = Guid.NewGuid();
                _repository.AddEntity(model);
                if (_repository.SaveAll())
                {
                    return Created($"/api/properties/{model.id}", model);
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

