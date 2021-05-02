using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Polyclinic.BLL.Entities;
using Polyclinic.BLL.Interfaces;
using Polyclinic.Models;
using Polyclinic.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IVisitService _visitService;

        public HomeController(ILogger<HomeController> logger,
                              IMapper mapper,
                              IDoctorService doctorService,
                              IPatientService patientService,
                              IVisitService visitService)
        {
            _logger = logger;
            _mapper = mapper;
            _doctorService = doctorService;
            _patientService = patientService;
            _visitService = visitService;
        }

        public async Task<IActionResult> Index()
        {
            var visits = await _visitService.GetVisitsAsync();
            var mappedVisits = _mapper.Map<List<VisitViewModel>>(visits);
            return View(mappedVisits);
        }

        [Route("Home/DeleteVisit/{id}")]
        public async Task<IActionResult> DeleteVisit(int? id)
        {
            await _visitService.DeleteVisitAsync(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> CreateVisit()
        {
            ViewBag.Doctors = await GetDoctors();
            ViewBag.Patiens = await GetPatiens();
            return View();
        }

        private async Task<SelectList> GetDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            var mappedDoctors = _mapper.Map<List<DoctorViewModel>>(doctors);
            var selectList = new SelectList(mappedDoctors, "DoctorId", "DoctorFullName");
            return selectList;
        }

        private async Task<SelectList> GetPatiens()
        {
            var patiens = await _patientService.GetAllPatientsAsync();
            var mappedPatiens = _mapper.Map<List<PatientViewModel>>(patiens);
            var selectList = new SelectList(mappedPatiens, "PatientId", "PatientFullName");
            return selectList;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisit(VisitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var visitDTO = _mapper.Map<VisitDTO>(model);
                await _visitService.CreateVisitAsync(visitDTO);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Doctors = await GetDoctors();
            ViewBag.Patiens = await GetPatiens();
            return View(model);
        }

        [HttpGet]
        [Route("Home/EditVisit/{id}")]
        public async Task<IActionResult> EditVisit(int? id)
        {
            var visit = await _visitService.GetVisitByIdAsync(id);
            var mappedVisit = _mapper.Map<VisitViewModel>(visit);

            ViewBag.Doctors = await GetDoctors();
            ViewBag.Patiens = await GetPatiens();

            return View(mappedVisit);
        }

        [HttpPost]
        //[Route("Home/EditVisit/{id}")]
        public async Task<IActionResult> EditVisit(VisitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var visitDTO = _mapper.Map<VisitDTO>(model);
                await _visitService.UpdateVisitAsync(visitDTO);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Doctors = await GetDoctors();
            ViewBag.Patiens = await GetPatiens();

            return View(model);
        }

        [HttpGet]
        [Route("Home/DetailsVisit/{id}")]
        public async Task<IActionResult> DetailsVisit(int? id)
        {
            var visit = await _visitService.GetVisitByIdAsync(id);
            var mappedVisit = _mapper.Map<VisitViewModel>(visit);
            return View(mappedVisit);
        }
    }
}
