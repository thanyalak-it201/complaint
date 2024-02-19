using Complain.Data;
using Complain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Complaint.Controllers
{
    public class AddUserController : Controller
    {
        private readonly Db_ComplaintModel _db;
        public AddUserController(Db_ComplaintModel db)
        {
            _db = db;
        }
        // ===================================== Index ===========================================================
        public IActionResult Index()
        {
            List<VUser> VUsers = _db.VUsers.ToList();
            ViewBag.VUser = VUsers;

            List<Role> RoleList = _db.Roles.ToList();
            ViewBag.Role = new SelectList(RoleList, "RoleId", "RoleName");

            List<Department> DepartmentsList = _db.Departments.ToList();
            ViewBag.Department = new SelectList(DepartmentsList, "DepartmentId", "DepartmentName");

            List<Section> SectionList = _db.Sections.ToList();
            ViewBag.Section = new SelectList(SectionList, "SectionId", "SectionName");

            List<Position> PositionList = _db.Positions.ToList();
            ViewBag.Position = new SelectList(PositionList, "PositionId", "PositionName");

            return View();
        }

        // ===================================== Create แสดงรายการเพิ่ม User =========================================
        public IActionResult Create()
        {
            List<Department> DepartmentsList = _db.Departments.ToList();
            ViewBag.Department = new SelectList(DepartmentsList, "DepartmentId", "DepartmentName");
            
            List<Section> SectionList = _db.Sections.ToList();
            ViewBag.Section = new SelectList(SectionList, "SectionId", "SectionName");
            
            List<Position> PositionList = _db.Positions.ToList();
            ViewBag.Position = new SelectList(PositionList, "PositionId", "PositionName");

            List<Role> RoleList = _db.Roles.ToList();
            ViewBag.Role = new SelectList(RoleList, "RoleId", "RoleName");


            return View();
        }

        // ===================================== CreateF บันทึกรายการ ===============================================

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateF(User obj )
        {
            obj.StatusUsId = "0";

            var imagesFolderPath = Path.Combine("img", "Profile", "imgProfile.jpg");
            obj.ImgProfile = imagesFolderPath;

            _db.Users.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ===================================== Edit แสดงรายการแก้ไข ===============================================
        public IActionResult Edit(string Id)
        {
            VUser VUser = _db.VUsers.FirstOrDefault(s => s.UserId == Id); //ดึงข้อมูลจากฐานข้อมูล

            ViewBag.Id = Id;


            List<Department> DepartmentsList = _db.Departments.ToList();
            ViewBag.Department = new SelectList(DepartmentsList, "DepartmentId", "DepartmentName");

            List<Section> SectionList = _db.Sections.ToList();
            ViewBag.Section = new SelectList(SectionList, "SectionId", "SectionName");

            List<Position> PositionList = _db.Positions.ToList();
            ViewBag.Position = new SelectList(PositionList, "PositionId", "PositionName");

            List<Role> RoleList = _db.Roles.ToList();
            ViewBag.Role = new SelectList(RoleList, "RoleId", "RoleName");

            return View(Id);
        }

        // ===================================== Update บันทึกรายการแก้ไข =============================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(string UserId, string RoleId)
        {
            // ค้นหาข้อมูลจากฐานข้อมูล
            var Id = _db.Users.FirstOrDefault(s => s.UserId == UserId); //ดึงข้อมูลจากฐานข้อมูล

            if (Id != null)
            {
                // กำหนดค่า StatusId ตามที่ถูกส่งมาจาก View
                Id.RoleId = RoleId;

                // บันทึกการเปลี่ยนแปลงลงในฐานข้อมูล
                _db.Users.Update(Id);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        // ===================================== Delete ==========================================================
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var data = _db.Users.Find(id);
            data!.StatusUsId = "1";
            _db.Users.Update(data);
            Boolean result = _db.SaveChanges() > 0;
            return RedirectToAction(nameof(Index));
        }


    }
}
