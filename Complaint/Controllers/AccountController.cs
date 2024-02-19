using Complain.Data;
using Complain.Models;
using Complaint.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Complaint.Controllers
{
    public class AccountController : Controller
    {
        private readonly Db_ComplaintModel _db;
        public AccountController(Db_ComplaintModel db)
        {
            _db = db;
        }
        public IActionResult Home()
        {
            return View();
        }

        // ตั้งค่า Cookie 
        private async Task SetCookie(LoginViewModel model, VUser Users)
        {
            // กำหนดคุณสมบัติของการตรวจสอบสิทธิ์ (Authentication) 
            var props = new AuthenticationProperties // 
            {
                IsPersistent = model.RememberMe, //ตรวจสอบว่าต้องการให้การตรวจสอบสิทธิ์อยู่ในระยะยาวหรือไม่ ยังคงอยู่เมื่อผู้ใช้ปิดเบราว์เซอร์ แต่ถ้าค่าเป็น false การตรวจสอบสิทธิ์จะสิ้นสุด
                AllowRefresh = true, // กำหนดค่า AllowRefresh ให้เป็น true อนุญาตให้ผู้ใช้รีเฟรชการตรวจสอบสิทธิ์โดยไม่ต้องเข้าสู่ระบบใหม่
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30) // กำหนดให้เวลาหมดอายุของการตรวจสอบสิทธิ์ คือ 30 วัน
            };

            // กำหนดรายการข้อมูลการอนุญาต (Claims) ที่จะเก็บไว้ในคุกกี้
            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()), // สร้าง claim ที่เกี่ยวข้องกับรหัสระบุตัวตน (NameIdentifier) โดยให้มีค่าเป็น Guid ที่สร้างขึ้นใหม่ โดยทั่วไป, รหัสนี้ใช้เพื่อระบุบุคคลอย่างเฉพาะ.
                        new Claim(ClaimTypes.Name, Users.UserName),
                        new Claim("RoleId", Users.RoleId),
                        new Claim("UserId", Users.UserId),
                        new Claim("StatusUsId", Users.StatusUsId),
                        new Claim("ImgProfile", Users.ImgProfile)
                    };

            // สร้าง Identity ขึ้นมา
            var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.NameIdentifier, ClaimsIdentity.DefaultRoleClaimType);
            // CookieAuthenticationDefaults.AuthenticationScheme: ระบุ Authentication Scheme ที่ใช้ในการลงชื่อเข้าใช้. ในที่นี้มีการใช้ Cookie Authentication Scheme ซึ่งเป็นวิธีที่พบมากในการจัดการการตรวจสอบสิทธิ์ใน ASP.NET.

            // ClaimTypes.NameIdentifier: ระบุประเภทของ claim ที่ใช้เป็นรหัสระบุตัวตน(NameIdentifier) ใน Identity.

            // ClaimsIdentity.DefaultRoleClaimType: ระบุประเภทของ claim ที่ใช้เป็น Role ใน Identity.

            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity); // ระบุตัวตนของผู้ใช้และข้อมูลการอนุญาต (claims) ที่เกี่ยวข้อง

            // ทำการลงชื่อเข้าใช้ (Sign In) ด้วยการใช้คุกกี้
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) // ตรวจสอบว่าข้อมูลที่รับมาจากแบบฟอร์มถูกต้องตามเงื่อนไขที่ได้กำหนดไว้ไหม
            {
                var Users = _db.VUsers
                    .Where(m => m.Email == model.Email && m.Password == model.Password).FirstOrDefault();
                // ดึงค่าจาก VUsers โดยเลือกเฉพาะผู้ใช้ที่มีอีเมลและรหัสผ่านตรงกับฐานข้อมูลใน VUsers
                // FirstOrDefault(): ใช้เพื่อดึงผู้ใช้ที่ตรงกับเงื่อนไขที่กำหนด ถ้าไม่พบผู้ใช้ที่ตรงกับเงื่อนไข, จะได้ค่าเป็น null.
                    

                switch (Users) // ตรวจสอบค่า Users
                {
                    case null: // กรณีที่ Users เป็น null (ไม่พบผู้ใช้)
                        TempData["Danger"] = "ชื่อผู้ใช้งานหรือรหัสผ่านไม่ถูกต้อง";
                        break;

                    default: // กรณีเริ่มต้นเมื่อ Users ไม่เท่ากับ null (พบผู้ใช้)

                        if (Users.StatusUsId == "1") // ตรวจสอบค่า StatusUsId ก่อนที่จะอนุญาตให้ผู้ใช้ login
                        {
                            TempData["Danger"] = "ไม่สามารถเข้าสู่ระบบได้ เนื่องจากสถานะของบัญชีไม่อนุญาต";
                            break;
                        }

                        var LoginDate = _db.Users.Where(s => s.Email == model.Email).FirstOrDefault();
                        // สร้างตัวแปร LoginDate เพื่อเก็บค่า Email ที่ตรงกับฐานข้อมูล Users และ FirstOrDefault() จะคืนค่าเป็น null ถ้าไม่พบผู้ใช้
                        LoginDate.DateLogin = DateTime.Now.ToString();
                        // นำ LoginDate ที่ได้มาจากการค้นหาและกำหนดค่า DateLogin เป็นเวลาปัจจุบันในรูปแบบข้อความ
                        _db.SaveChanges(); // บันทึกการเปลี่ยนแปลงลงในฐานข้อมูล

                        // ตั้งค่าคุกกี้และเปลี่ยนเส้นทางไปที่หน้า Index ของ Complaint Controller
                        await SetCookie(model, Users); // เรียกใช้เมธอด SetCookie โดยส่งข้อมูล model,Users ไปด้วย
                        return RedirectToAction(nameof(Home), "Complaint"); //เปลี่ยนเส้นทางไปที่หน้า Index ของ Complaint Controller
                }
               }
            // ถ้าข้อมูลจากแบบฟอร์มไม่ถูกต้อง, กลับไปที่หน้าแบบฟอร์ม
            return View(model);
        }

        public async Task<IActionResult> Login()
        {
            if (User.Identity!.IsAuthenticated) // ตรวจสอบสิทธิ์เข้าใช้งานของผู้ใช้งาน
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // หลังจากการล็อกเอาท์นี้จะทำการตรวจสอบต่อ โดยใช้เครื่องมือก็ตั้งค่าคุกกี้

                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName, //Cookie ที่ใช้ในการจัดเก็บข้อมูลการตั้งค่าภาษา
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("th-TH")), //สร้างค่าของ Cookie โดยให้มีค่าเท่ากับข้อมูลการตั้งค่าภาษา "th-TH".
                        new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) } //กำหนดให้ Cookie มีอายุ (Expires) 30 วันนับจากปัจจุบัน
                    );

                return RedirectToAction(nameof(Home), "Complaint"); //เปลี่ยนเส้นทางไปที่หน้า Index ของ Complaint Controller
            }

            return View("Home");
        }

        public async Task<IActionResult> Logout()
        {

            // Clear the existing external cookie
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme); //ระบบทำการล็อกเอาท์ผู้ใช้จากระบบการตรวจสอบแบบคุกกี้

            return RedirectToAction(nameof(Home), "Account"); //
        }

    }
}
