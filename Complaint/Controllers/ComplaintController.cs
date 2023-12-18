using Complaint.Data;
using Microsoft.AspNetCore.Mvc;

namespace Complaint.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly db_ComplaintModel _db;

        public ComplaintController(db_ComplaintModel db)
        {
            _db = db;
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
