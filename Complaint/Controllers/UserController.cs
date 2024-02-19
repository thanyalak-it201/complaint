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

        // ===================================== Update บันทึกรายการแก้ไข =============================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProfile(User user, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {

                var fileName = Path.GetFileNameWithoutExtension(file.FileName);// ดึงชื่อไฟล์ โดยที่ไม่เอานามสกุล
                var fileExtension = Path.GetExtension(file.FileName); // ดึงนามสกุลไฟล์
                var imagePath = Path.Combine("wwwroot", "images", $"{fileName}{fileExtension}"); // กำหนดบันทึกที่ wwwroot\images\{ชื่อไฟล์}{นามสกุลไฟล์}
                var imagesFolderPath = Path.Combine("wwwroot", "images");

                // ตรวจสอบว่าโฟลเดอร์ images มีอยู่หรือไม่
                if (!Directory.Exists(imagesFolderPath))
                {
                    // ถ้าไม่มี, ให้สร้างโฟลเดอร์ images
                    Directory.CreateDirectory(imagesFolderPath);
                }

                if (System.IO.File.Exists(imagePath)) // ตรวจสอบว่ามีชื่อซ้ำหรือไหม
                {
                    var counter = 1; // เพิ่ม _1 หลังชื่อไฟล์
                    var originalFileName = fileName; // เก็บชื่อไฟล์ต้นฉบับ

                    while (System.IO.File.Exists(imagePath)) // ตรวจสอบว่ามีชื่อซ้ำไหม
                    {
                        fileName = $"{originalFileName}_{counter}"; // ชื่อต้นฉบับ_เลข
                        imagePath = Path.Combine("wwwroot", "img", "Signature", $"{fileName}{fileExtension}"); // กำหนดบันทึกที่ wwwroot\images\{ชื่อไฟล์}{นามสกุลไฟล์}
                        counter++; // เพิ่มเรือยๆ
                    }
                }
                using (var stream = new FileStream(imagePath, FileMode.Create)) // สร้างไฟล์ใหม่
                {
                    file.CopyTo(stream);
                }

                // กำหนดเส้นทางไฟล์ให้กับ property ImagePath ของ obj
                user.ImgProfile = Path.Combine("img", $"{fileName}{fileExtension}");
                _db.SaveChanges();
            }

            _db.Forms.Update(user);
            Boolean result = _db.SaveChanges() > 0;
            return RedirectToAction(nameof(Index));
        }
    }
}
