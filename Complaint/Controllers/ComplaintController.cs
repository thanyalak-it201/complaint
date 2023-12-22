using Complain.Data;
using Microsoft.AspNetCore.Mvc;
using Complain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

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

            List<Problem> data = _db.Problems.ToList();
            ViewBag.ListProblem = new SelectList(data, "ProblemId", "ProblemName" );

            List<Manager> dataMng = _db.Managers.ToList();
            ViewBag.ListManager = new SelectList(dataMng, "MngId", "MngName");

            return View();
        }

        [HttpPost]
        public JsonResult Customerselect(string CostomerId)
        {
            VCostomer result = _db.VCostomers.FirstOrDefault(s => s.CostomerId == CostomerId)!;
            return Json(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Form obj)
        {
            _db.Forms.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
