using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Polyclinic.BLL.Entities;
using Polyclinic.BLL.Interfaces;
using Polyclinic.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polyclinic.Web.Controllers
{
    [Route("[controller]")]
    public class PatientController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;
        private readonly int _pageSize = 3;

        public PatientController(IMapper mapper,
                                 IPatientService patientService,
                                 ILogger<PatientController> logger)
        {
            _mapper = mapper;
            _patientService = patientService;
            _logger = logger;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetPatients(int pageIndex = 1)
        {
            _logger.LogInformation($"Patient - GetPatients Get Request");

            var patientsPageModel = await _patientService.GetPatientsPaginatedAsync(pageIndex, _pageSize);
            var mappedPatients = _mapper.Map<List<PatientViewModel>>(patientsPageModel.Items);

            var model = new PageViewModel<PatientViewModel>(patientsPageModel.Count, pageIndex, _pageSize, mappedPatients);
            ViewBag.PageSize = _pageSize;
            return View(model);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> CreatePatient()
        {
            _logger.LogInformation($"Patient - Create Patient Get Request");

            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreatePatient(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"Patient - Create Patient Post Request");

                var mappedModel = _mapper.Map<PatientDTO>(model);
                await _patientService.CreatePatientAsync(mappedModel);
                return RedirectToAction("GetPatients");
            }

            return View(model);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> EditPatient(int id)
        {
            _logger.LogInformation($"Patient - Edit Patient with id = {id} Get Request");
            var patient = await _patientService.GetPatientByIdAsync(id);
            var mappedPatient = _mapper.Map<PatientViewModel>(patient);
            return View(mappedPatient);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> EditPatient(PatientViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"Patient - Edit Patient with id = {model.PatientId} Post Request");
                var mappedModel = _mapper.Map<PatientDTO>(model);
                await _patientService.UpdatePatientAsync(mappedModel);
                return RedirectToAction("GetPatients");
            }

            return View(model);
        }

        [Route("[action]")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            _logger.LogInformation($"Patient - Delete Patient with id = {id}");
            await _patientService.DeletePatientAsync(id);
            return RedirectToAction("GetPatients");
        }
    }
}
