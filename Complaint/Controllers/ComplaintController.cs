using Complain.Data;
using Microsoft.AspNetCore.Mvc;
using Complain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Complaint.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly Db_ComplaintModel _db;

        public ComplaintController(Db_ComplaintModel db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<VCostomer> List = _db.VCostomers.ToList();
            //List<VCostomer> List = new List<VCostomer>();
            //List = _db.VCostomers.ToList();
            ViewBag.ListCostomer = new SelectList(List, "CostomerId", "CostomerId");

            return View();
        }

        [HttpPost]
        public JsonResult Customerselect(string CostomerId)
        {
            VCostomer result = _db.VCostomers.FirstOrDefault(s => s.CostomerId == CostomerId)!;
            return Json(result);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
