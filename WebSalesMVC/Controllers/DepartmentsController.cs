using Microsoft.AspNetCore.Mvc;
using WebSalesMVC.Models;

namespace WebSalesMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department { Id = 1, Name = "Depósito" });
            list.Add(new Department { Id = 2, Name = "Hamburgueria" });
            list.Add(new Department { Id = 3, Name = "Padaria" });

            return View(list);
        }
    }
}
