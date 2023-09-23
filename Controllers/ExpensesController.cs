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
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IRNRepository _repository;
        public ExpensesController(IRNRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("[action]")]
        public IActionResult PostYTD([FromForm] Expenses model)
        {
            try
            {
                var cat_itemname = "YTD";
                var catType = _repository.GetAllCatTypes(cat_itemname);
                //var _date = DateTime.Now;
                //model.created_date = _date;

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
