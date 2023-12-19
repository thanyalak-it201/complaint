using Complaint.Datas;
using Complaint.Models;
using Microsoft.AspNetCore.Mvc;

namespace Complaint.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly ComplaintModel _db;

        public ComplaintController(ComplaintModel db)
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
