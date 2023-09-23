using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairNinjaMVC.Data; 
using Microsoft.AspNetCore.Mvc;

namespace RepairNinjaMVC.Controllers
{
    public class AppConrroller : Controller
    {
        private readonly IRNRepository _rnRepository;

        public AppConrroller(IRNRepository rnRepository)
        {
            _rnRepository = rnRepository;
        }

    }
}
