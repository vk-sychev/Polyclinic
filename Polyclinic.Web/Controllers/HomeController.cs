using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Polyclinic.BLL.Entities;
using Polyclinic.BLL.Interfaces;
using Polyclinic.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IVisitService _visitService;
        private readonly int _pageSize = 3;

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

        [Route("")]
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            _logger.LogInformation("Home - Index");
            var visitsPageModel = await _visitService.GetVisitsPaginatedAsync(pageIndex, _pageSize);
            var mappedVisits = _mapper.Map<List<VisitViewModel>>(visitsPageModel.Items);

            var model = new PageViewModel<VisitViewModel>(visitsPageModel.Count, pageIndex, _pageSize, mappedVisits);
            ViewBag.PageSize = _pageSize;
            return View(model);
        }

        [Route("[action]")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisit(int id)
        {
            _logger.LogInformation($"Home - Delete Visit with id = {id}");
            await _visitService.DeleteVisitAsync(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CreateVisit()
        {
            _logger.LogInformation($"Home - Create Visit Get Request");
            ViewBag.Doctors = await GetDoctors();
            ViewBag.Patiens = await GetPatiens();
            return View();
        }

        private async Task<SelectList> GetDoctors()
        {
            var doctors = await _doctorService.GetDoctorsAsync();
            var mappedDoctors = _mapper.Map<List<DoctorViewModel>>(doctors);
            var selectList = new SelectList(mappedDoctors, "DoctorId", "DoctorFullName");
            return selectList;
        }

        private async Task<SelectList> GetPatiens()
        {
            var patiens = await _patientService.GetPatientsAsync();
            var mappedPatiens = _mapper.Map<List<PatientViewModel>>(patiens);
            var selectList = new SelectList(mappedPatiens, "PatientId", "PatientFullName");
            return selectList;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateVisit(VisitViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"Home - Create Visit Post Request");
                var visitDTO = _mapper.Map<VisitDTO>(model);
                var isValidDate = await _visitService.CreateVisitAsync(visitDTO);

                if (isValidDate)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("InvalidDate", "This time is already taken!");
                }
            }
            ViewBag.Doctors = await GetDoctors();
            ViewBag.Patiens = await GetPatiens();
            return View(model);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EditVisit(int id)
        {
            _logger.LogInformation($"Home - Edit Visit with id = {id} Get Request");

            var visit = await _visitService.GetVisitByIdAsync(id);
            var mappedVisit = _mapper.Map<VisitViewModel>(visit);

            ViewBag.Doctors = await GetDoctors();
            ViewBag.Patiens = await GetPatiens();

            return View(mappedVisit);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> EditVisit(VisitViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"Home - Edit Visit with id = {model.VisitId} Post Request");
                var visitDTO = _mapper.Map<VisitDTO>(model);
                await _visitService.UpdateVisitAsync(visitDTO);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Doctors = await GetDoctors();
            ViewBag.Patiens = await GetPatiens();

            return View(model);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> DetailsVisit(int id)
        {
            var visit = await _visitService.GetVisitByIdAsync(id);
            var mappedVisit = _mapper.Map<VisitViewModel>(visit);
            return View(mappedVisit);
        }

        [Route("[action]")]
        public async Task<IActionResult> GetStatistics(SearchModel model) 
        {
            _logger.LogInformation("Home - GetStatistics");
            var doctors = await _doctorService.GetStatisticsAsync(model);
            var mappedVisits = _mapper.Map<List<DoctorViewModel>>(doctors);

            ViewBag.Specialties = await GetSpecialties();
            ViewBag.IsPeriod = model.IsPeriod;
            ViewBag.StartDate = model.StartDate;
            ViewBag.EndDate = model.EndDate;
            ViewBag.SpecialtyId = model.SpecialtyId;

            return View(mappedVisits);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> DownloadStatistics(SearchModel model)
        {
            var content = await _doctorService.GetStatisticsInFileAsync(model);

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Statistics.xlsx");
        }

        private async Task<SelectList> GetSpecialties()
        {
            var specialties = await _doctorService.GetSpecialtiesAsync();
            specialties = specialties.Prepend(new SpecialtyDTO { SpecialtyId = 0, Name = "All" }).ToList();
            return new SelectList(specialties, "SpecialtyId", "Name");
        }
    }
}
