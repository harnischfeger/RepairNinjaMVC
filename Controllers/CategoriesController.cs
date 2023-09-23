using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RepairNinjaMVC.Data.Entities;
using RepairNinjaMVC.Data;

namespace RepairNinjaMVC.Controllers
{
    [EnableCors]
    [Route("api/[Controller]")]
    public class CategoriesController : Controller
    {
        private readonly IRNRepository _repository;

        public CategoriesController(IRNRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("[action]")]
        public IEnumerable<Categories> GetCategories(string cat_itemname)
        {
            return _repository.GetAllCatTypes(cat_itemname);
        }
    }
}
