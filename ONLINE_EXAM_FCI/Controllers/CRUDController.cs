using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ONLINE_EXAM_FCI.Data;
using ONLINE_EXAM_FCI.Models;

public class CRUDController : Controller
{

    ApplicationDbContext db = new();
    public CRUDController(ApplicationDbContext context)
    {
        db = context;
    }

    // GET: Exams
    public IActionResult Index()
    {
        var exams = db.Exams.ToList();
        return View(exams);
    }

    // GET: Exams/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Exams/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Exam exam)
    {
        if (ModelState.IsValid)
        {
            db.Exams.Add(exam);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(exam);
    }

    // GET: Exams/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var exam = db.Exams.Find(id);
        if (exam == null)
        {
            return NotFound();
        }

        return View(exam);
    }

    // POST: Exams/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Exam exam)
    {
        if (id != exam.ExId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamExists(exam.ExId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(exam);
    }

    // GET: Exams/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var exam = db.Exams.Find(id);
        if (exam == null)
        {
            return NotFound();
        }

        return View(exam);
    }

    // POST: Exams/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var exam = db.Exams.Find(id);
        db.Exams.Remove(exam);
        db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    private string EncryptPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }

    private bool ExamExists(int id)
    {
        return db.Exams.Any(e => e.ExId == id);
    }
}
