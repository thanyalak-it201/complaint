using Complaint.Models;
using Complain.Data;
using Microsoft.AspNetCore.Mvc;
using Complain.Models;

namespace Complaint.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly Db_ComplaintModel _db;

        public ComplaintController(Db_ComplaintModel db)
        {
            _db = db;
        }

        [HttpPost]
        public JsonResult Customerselect(int CostomerId)
        {
            VCostomer result = _db.VCostomers.FirstOrDefault(s => s.CostomerId == CostomerId)!;
            return Json(result);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
