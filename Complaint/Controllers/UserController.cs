using Complain.Data;
using Complain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SetCookie;

namespace Complaint.Controllers
{
    public class UserController : Controller
    {
        private readonly Db_ComplaintModel _db;
        public UserController(Db_ComplaintModel db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            VUser user = _db.VUsers.FirstOrDefault(u => u.UserId == User.GetLoggedInUserId());
            ViewBag.ListUserProfile = user;

            return View();
        }

        // ===================================== Edit แสดงรายการแก้ไข ===============================================
        public IActionResult Edit()
        {
            VUser user = _db.VUsers.FirstOrDefault(u => u.UserId == User.GetLoggedInUserId());
            ViewBag.UserProfile = user;

            List<Department> DepartmentsList = _db.Departments.ToList();
            ViewBag.Department = new SelectList(DepartmentsList, "DepartmentId", "DepartmentName");

            List<Section> SectionList = _db.Sections.ToList();
            ViewBag.Section = new SelectList(SectionList, "SectionId", "SectionName");

            List<Position> PositionList = _db.Positions.ToList();
            ViewBag.Position = new SelectList(PositionList, "PositionId", "PositionName");

            return View();
        }

        // ===================================== Update Profile =============================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProfile(User Id, IFormFile file)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserId == User.GetLoggedInUserId());
            
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var fileExtension = Path.GetExtension(file.FileName);
                var imagePath = Path.Combine("wwwroot", "img", "Profile", $"{fileName}{fileExtension}");
                var imagesFolderPath = Path.Combine("wwwroot", "img", "Profile");

                if (!Directory.Exists(imagesFolderPath))
                {
                    Directory.CreateDirectory(imagesFolderPath);
                }

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                user.ImgProfile = Path.Combine("img", "Profile", $"{fileName}{fileExtension}");
                _db.SaveChanges();
            }

            _db.Users.Update(user);
            Boolean result = _db.SaveChanges() > 0;
            return RedirectToAction(nameof(Index));
        }
    }
}
