using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentManagementSystem.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RentManagementSystem.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitRepository repo;

        public UnitController(IUnitRepository repo)
        {
            this.repo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var units = repo.GetAllUnits();
            return View(units);
        }
        public IActionResult ViewTenant(int id)
        {
            var unit = repo.GetUnitsByTenantId(id);
            return View(unit);
        }
        public IActionResult UpdateUnit(int id)
        {
            Units units = repo.GetUnitsByTenantId(id);

            if (units == null)
            {
                return View("ProductNotFound");
            }

            return View(units);
        }
        public IActionResult UpdateUnitToDatabase(Units units)
        {
            repo.UpdateUnit(units);

            return RedirectToAction("ViewTenant", new { id = units.Tenant_ID });

        }

        public IActionResult InsertUnit()
        {
            var unit = repo.AssignCategory();

            return View(unit);
        }

        public IActionResult InsertUnitToDatabase(Units unitsToInsert)
        {
            repo.InsertUnit(unitsToInsert);

            return RedirectToAction("Index");
        }
    }
}

