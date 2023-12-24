using Microsoft.AspNetCore.Mvc;
using ONLINE_EXAM_FCI.Data;
using ONLINE_EXAM_FCI.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ONLINE_EXAM_FCI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _database;

        public AccountController(ApplicationDbContext context)
        {
            _database = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            var isEmailExist = _database.Users.Any(x => x.Email == user.Email);
            if (isEmailExist)
            {
                ModelState.AddModelError("Email", "Email already exists");
                return View();
            }

            if (ModelState.IsValid)
            {
               
                user.Password = EncryptPassword(user.Password);
                user.PasswordConfirmed = EncryptPassword(user.PasswordConfirmed);

                _database.Users.Add(user);
                _database.SaveChanges();
                return RedirectToAction("Login", "Account");
            }

            return View(user);
        }

        // Hash the password using SHA-256
        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var userFromDb = _database.Users.FirstOrDefault(x => x.Email == user.Email);
            if (userFromDb != null && userFromDb.Password == EncryptPassword(user.Password))
            {


                if(userFromDb.RoleID==0)
                {
                    return RedirectToAction("admin", "Account");
                }
                else if (userFromDb.RoleID == 2)
                {
                    return RedirectToAction("Welcome", "Account");
                }
                else if (userFromDb.RoleID == 1)
                {
                    return RedirectToAction("Doctor", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email or Password");

                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Email or Password");
            }
            return View(user);
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Doctor()
        {
            return View();
        }
        public IActionResult Admin()
        {
            var adminUser = _database.Users.FirstOrDefault(u => u.RoleID == 0); // Assuming RoleID 1 is for admin
            return View(adminUser);
        }
    }
}