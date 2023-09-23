using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RepairNinjaMVC.Data;
using RepairNinjaMVC.Data.Entities;
using System.Linq;

namespace RepairNinjaMVC.Controllers
{
    [EnableCors]
    [Route("api/[Controller]")]
    public class UsersController : Controller
    {
        private readonly IRNRepository _repository;

        public UsersController(IRNRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("[action]")]
        public IEnumerable<Users> Get()
        {
            return _repository.GetAllUsers();
        }

        [HttpGet("[action]")]
         public IEnumerable<Users>? GetByUserName(string userName, string password)
        {
            try
            {
                var user = _repository.GetUserRecord(userName, password);
                if(user.Count() != 0)
                {
                    return user;
                }
                else
                {
                    return null; 
                }
            }
            catch (Exception ex)
            {
                return null; 
            }
        }
        [HttpPost("[action]")]
        public IActionResult Post([FromBody]Users model) {
            try
            {
                var _date= DateTime.Now;
                model.created_date = _date; 
                model.is_active= true;
                model.id = Guid.NewGuid();
                _repository.AddEntity(model);
                if (_repository.SaveAll())
                {
                    return Created($"/api/users/{model.id}", model);
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
