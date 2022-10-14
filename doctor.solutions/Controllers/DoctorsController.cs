using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Controllers
{
  public class DoctorsController : Controller
  {
    private readonly DoctorsOfficeContext _db;

    public DoctorsController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      // List<Doctor> model = _db.Categories.ToList();
      return View(_db.Doctors.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doc doctor)
    {
      _db.Doctors.Add(doctor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}