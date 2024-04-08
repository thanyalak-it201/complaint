using Complain.Data;
using Microsoft.AspNetCore.Mvc;
using Complain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Microsoft.Reporting.NETCore;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Complaint.Models;

namespace Complaint.Controllers
{
    [Authorize]
    public class ComplaintController : Controller
    {
        private readonly Db_ComplaintModel _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICompositeViewEngine _viewEngine;

        public ComplaintController(Db_ComplaintModel db , IWebHostEnvironment webHostEnvironment, ICompositeViewEngine viewEngine)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _viewEngine = viewEngine;
        }

        //=========================================== Dashboard =============================================
        public IActionResult Home()
        {

            ViewBag.StatusId0 = _db.VForms.Count(s => s.StatusId == 0);
            ViewBag.StatusId1 = _db.VForms.Count(s => s.StatusId == 1);
            ViewBag.StatusId2 = _db.VForms.Count(s => s.StatusId == 2);
            ViewBag.StatusId3 = _db.VForms.Count(s => s.StatusId == 3);

            return View();
        }
        public IActionResult HomeCustomerData()
        {
            var ProblemsData = new Dashboard();
            ProblemsData.ListProblem = new List<ProblemResponse>();

            var topProblems = _db.VForms
                                 .GroupBy(s => s.ProblemId)
                                 .OrderByDescending(g => g.Count())
                                 .Take(3)
                                 .Select(g => new ProblemResponse
                                 {
                                     NameProblem = g.First().ProblemName, 
                                     CountProblem = g.Count()
                                 })
                                 .ToList();

            ProblemsData.ListProblem.AddRange(topProblems);

            ViewBag.ProblemsData = ProblemsData;


            return View();
        }


        //=========================================== Index =================================================
        public IActionResult Index()
        {
            List<VForm> Vforms = _db.VForms.ToList();
            ViewBag.VForm = Vforms;
            
            int V = _db.VForms.Count();
            ViewBag.V = V;
            return View();
        }

        //=========================================== PrintReport ===========================================
        public IActionResult PrintReport(int Id)
        {

            VForm VForms = _db.VForms.FirstOrDefault(s => s.FromId == Id); //ดึงข้อมูลจากฐานข้อมูล
            var dt = GetData(VForms); // เก็บค่าใน dt

            ViewBag.Id = Id;

            using var report = new LocalReport(); // สร้าง report

            report.DataSources.Add(new ReportDataSource("dsForm", dt)); // โปรแกรมนำข้อมูลที่ได้มาจากฐานข้อมูลและเพิ่มเป็น DataSource ในรายงาน
            var parameters = new[] { new ReportParameter("param1", "RDLC Sub-Report Example") }; // กำหนดค่าพารามิเตอร์ที่ใช้ในรายงาน
            report.ReportPath = $"{this._webHostEnvironment.WebRootPath}\\Reports\\rpForm.rdlc"; // กำหนดที่อยู่ของไฟล์รายงาน RDLC ที่ใช้ในการสร้างรายงาน
            report.SetParameters(parameters); // ตั้งค่า parameters

            var pdfBytes = report.Render("PDF"); // เรนเดอร์รายงานป็น "PDF" เก็บไว้ใน pdfBytes
            var base64String = Convert.ToBase64String(pdfBytes);
            //แปลงไบต์แอร์เรย์ของ PDF(pdfBytes) เป็นสตริงที่ถูกเข้ารหัส Base64 จะถูกใช้ต่อไปเพื่อแทรกรายงานลงใน HTML หรือส่งผ่าน URL.


            ViewBag.PDFData = base64String;
            ViewBag.ReportData = dt;
            ViewBag.ReportTitle = "RDLC Sub-Report Example";


            return View("PrintReport");
        }

        //=========================================== UpdateReport ===========================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateReport(int Id, int StatusId)
        {
            // ค้นหาข้อมูลจากฐานข้อมูล
            var form = _db.Forms.Find(Id);

            if (form != null)
            {
                // กำหนดค่า StatusId ตามที่ถูกส่งมาจาก View
                form.StatusId = StatusId;

                // บันทึกการเปลี่ยนแปลงลงในฐานข้อมูล
                _db.Forms.Update(form);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        //=========================================== แปลงภาพเป็นbit ===========================================
        public string getImageFromPath(string images)
        {
            string imgFile = "";
            using (var b = new Bitmap(images))
            {
                using (var ms = new MemoryStream())
                {
                    b.Save(ms, ImageFormat.Bmp);
                    imgFile = Convert.ToBase64String(ms.ToArray());
                }
            }
            return imgFile;
        }

        //=========================================== Data Report =====================================================
        public DataTable GetData(VForm VForms)
        {
            var dt = new DataTable();
            dt.Columns.Add("FromId", typeof(int));
            dt.Columns.Add("FromData", typeof(DateTime));
            dt.Columns.Add("ToId", typeof(int));
            dt.Columns.Add("CCId", typeof(int));
            dt.Columns.Add("FromName", typeof(string));
            dt.Columns.Add("CostomerName", typeof(string));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("Lot", typeof(DateTime));
            dt.Columns.Add("ProblemName", typeof(string));
            dt.Columns.Add("ProblemOthet", typeof(string));
            dt.Columns.Add("Number", typeof(int));
            dt.Columns.Add("Price", typeof(int));
            dt.Columns.Add("Co", typeof(string));
            dt.Columns.Add("TypeName", typeof(string));
            dt.Columns.Add("Image", typeof(string));
            dt.Columns.Add("Note", typeof(string));
            dt.Columns.Add("UserId", typeof(string));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("EmpDepartment", typeof(string));
            dt.Columns.Add("EmpSection", typeof(string));
            dt.Columns.Add("EmpPosition", typeof(string));
            dt.Columns.Add("MngName", typeof(string));
            dt.Columns.Add("StatusName", typeof(string));
            dt.Columns.Add("ImgSignature", typeof(string));
            dt.Columns.Add("ImgSignatureMng", typeof(string));

            
                    dt.Rows.Add(
                        VForms.FromId,
                        VForms.FromData,
                        VForms.ToId,
                        VForms.CCId,
                        VForms.FromName,
                        VForms.CostomerName,
                        VForms.ProductName,
                        VForms.Lot,
                        VForms.ProblemName,
                        VForms.ProblemOthet,
                        VForms.Number,
                        VForms.Price,
                        VForms.Co,
                        VForms.TypeName,
                        getImageFromPath(Path.Combine(_webHostEnvironment.WebRootPath, VForms.Image)),
                        VForms.Note,
                        VForms.UserId,
                        VForms.UserName,
                        VForms.EmpDepartment,
                        VForms.EmpSection,
                        VForms.EmpPosition,
                        VForms.MngName,
                        VForms.StatusName,
                        getImageFromPath(Path.Combine(_webHostEnvironment.WebRootPath, VForms.ImgSignature)),
                        (VForms.StatusName == "อนุมัติ" ? getImageFromPath(Path.Combine(_webHostEnvironment.WebRootPath, VForms.ImgSignatureMng)): "" )
                    );
            return dt;
        }

        //=========================================== แสดงรายการหน้า Create ==============================================
        public IActionResult Create()
        {
            List<VCostomer> List = _db.VCostomers.ToList();
            ViewBag.ListCostomer = new SelectList(List, "CostomerId", "CostomerId");

            List<Problem> data = _db.Problems.ToList();
            ViewBag.ListProblem = new SelectList(data, "ProblemId", "ProblemName");

            List<Manager> dataMng = _db.Managers.ToList();
            ViewBag.ListManager = new SelectList(dataMng, "MngId", "MngName");

            List<TypeFrom> dataTF = _db.TypeFroms.ToList();
            ViewBag.ListTypeFrom = new SelectList(dataTF, "TypeId", "TypeName");

            List<Complain.Models.User> User = _db.Users.ToList();
            ViewBag.ListUser = new SelectList(User, "UserId", "UserName");

            var model = new Status();
            model.StatusId = 0;// กำหนดค่า StatusId ให้เป็น 0

            return View();
        }

        //=========================================== เพิ่มรายการ หน้า Create ==============================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateF(Form obj, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {

                var fileName = Path.GetFileNameWithoutExtension(file.FileName);// ดึงชื่อไฟล์ โดยที่ไม่เอานามสกุล
                var fileExtension = Path.GetExtension(file.FileName); // ดึงนามสกุลไฟล์
                var imagePath = Path.Combine("images", $"{fileName}{fileExtension}"); // กำหนดบันทึกที่ wwwroot\images\{ชื่อไฟล์}{นามสกุลไฟล์}
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
                        imagePath = Path.Combine("images", $"{fileName}{fileExtension}"); // กำหนดบันทึกที่ wwwroot\images\{ชื่อไฟล์}{นามสกุลไฟล์}
                        counter++; // เพิ่มเรือยๆ
                    }
                }
                using (var stream = new FileStream(imagePath, FileMode.Create)) // สร้างไฟล์ใหม่
                {
                    file.CopyTo(stream);
                }

                // กำหนดเส้นทางไฟล์ให้กับ property ImagePath ของ obj
                obj.Image = imagePath;
            }
            else
            {
                var ImagePath = Path.Combine("images", "default-img.png");
                obj.Image = ImagePath;
                _db.SaveChanges();
            }

            _db.Forms.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //===================================== รายการส่วนCustomerselect หน้า Create ======================================
        [HttpPost]
        public JsonResult Customerselect(string CostomerId)
        {
            VCostomer result = _db.VCostomers.FirstOrDefault(s => s.CostomerId == CostomerId)!;
            return Json(result);
        }

        //============================================= รายการแสดง หน้า Edit ============================================
        public IActionResult Edit (int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var obj = _db.Forms.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }


            List<VCostomer> List = _db.VCostomers.ToList();
            ViewBag.ListCostomer = new SelectList(List, "CostomerId", "CostomerId");

            List<Problem> data = _db.Problems.ToList();
            ViewBag.ListProblem = new SelectList(data, "ProblemId", "ProblemName");

            List<Manager> dataMng = _db.Managers.ToList();
            ViewBag.ListManager = new SelectList(dataMng, "MngId", "MngName");

            List<TypeFrom> dataTF = _db.TypeFroms.ToList();
            ViewBag.ListTypeFrom = new SelectList(dataTF, "TypeId", "TypeName");

            List<Complain.Models.User> User = _db.Users.ToList();
            ViewBag.ListUser = new SelectList(User, "UserId", "UserName");

            List<VCostomer> Data = _db.VCostomers.ToList();
            foreach (var item in Data)
            {
                ViewBag.costomername = item.CostomerName;
                ViewBag.productid = item.ProductId;
                ViewBag.productname = item.ProductName;
            }

            ViewBag.FromId = obj.FromId;
            return View(obj);
        }

        //============================================= Update หน้า Edit ===============================================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Form obj, IFormFile file)
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
                        imagePath = Path.Combine("wwwroot", "images", $"{fileName}{fileExtension}"); // กำหนดบันทึกที่ wwwroot\images\{ชื่อไฟล์}{นามสกุลไฟล์}
                        counter++; // เพิ่มเรือยๆ
                    }
                }
                using (var stream = new FileStream(imagePath, FileMode.Create)) // สร้างไฟล์ใหม่
                {
                    file.CopyTo(stream);
                }

                // กำหนดเส้นทางไฟล์ให้กับ property ImagePath ของ obj
                obj.Image = Path.Combine("images", $"{fileName}{fileExtension}");
            }
            else
            {
                var ImagePath = Path.Combine("images", "default-img.png");
                obj.Image = ImagePath;
            }

            _db.Forms.Update(obj);
            ////var existingObj = _db.Forms.FirstOrDefault(s => s.FromId == obj.FromId);
            _db.SaveChanges(); // บันทึกการเปลี่ยนแปลง
            return RedirectToAction(nameof(Index));
        }

        //================================================ Delete ======================================================
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Form data = _db.Forms.Find(id);
            data.StatusId = 3;
            _db.Forms.Update(data);
            Boolean result = _db.SaveChanges() > 0; //ตรวจสอบว่าถ้ามีการส่งค่ามากกว่า 0 จะส่งค่า false
            return RedirectToAction(nameof(Index));
        }

    }
}
