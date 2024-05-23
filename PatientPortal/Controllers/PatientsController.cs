using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

public class PatientsController : Controller
{
    public IActionResult Create()
    {
        return View(new Patient());
    }

    public IActionResult PatientsList()
    {
        return View();
    }

    public IActionResult Edit(int id)
    {
        Patient patient = new Patient();
        patient.Id = id;
        return View(patient);
    }

    public IActionResult Details(int id)
    {
        Patient patient = new Patient();
        patient.Id = id;
        return View(patient);
    }
}