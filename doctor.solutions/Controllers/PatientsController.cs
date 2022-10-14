using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Controllers
{
  public class PatientsController : Controller
  {
    private readonly DoctorsOfficeContext _db;

    public PatientsController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Patients.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.DocId = new SelectList(_db.Doctors, "DocId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Patient patient, int DocId)
    {
      _db.Patients.Add(patient);
      _db.SaveChanges();

      if (DocId != 0)
      {
        _db.DoctorPatient.Add(new DoctorPatient() { DocId = DocId, PatientId = patient.PatientId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisPatient = _db.Patients
            .Include(patient => patient.JoinEntities)
            .ThenInclude(join => join.Doctor)
            .FirstOrDefault(patient => patient.PatientId == id);
      return View(thisPatient);
    }

    public ActionResult Delete(int id)
    {
      var thisPatient = _db.Patients.FirstOrDefault(patient => patient.PatientId == id);
      return View(thisPatient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPatient = _db.Patients.FirstOrDefault(patient => patient.PatientId == id);
      _db.Patients.Remove(thisPatient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      var thisPatient = _db.Patients.FirstOrDefault(patient => patient.PatientId == id);
      ViewBag.DocId = new SelectList(_db.Doctors, "DocId", "Name");
      return View(thisPatient);
    }

    [HttpPost]
    public ActionResult Edit(Patient patient, int DocId)
    {
      if (DocId != 0)
      {
        _db.DoctorPatient.Add(new DoctorPatient() { DocId = DocId, PatientId = patient.PatientId });
      }
      _db.Entry(patient).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


  }
}