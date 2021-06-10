using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class DoctorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDoctorService _doctorService;
        private readonly ILogger<DoctorController> _logger;
        private readonly int _pageSize = 3;

        public DoctorController(IMapper mapper,
                                IDoctorService doctorService,
                                ILogger<DoctorController> logger)
        {
            _mapper = mapper;
            _doctorService = doctorService;
            _logger = logger;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetDoctors(int pageIndex = 1)
        {
            _logger.LogInformation("Doctor - GetDoctors");

            var doctorsPageModel = await _doctorService.GetDoctorsPaginatedAsync(pageIndex, _pageSize);
            var mappedDoctors = _mapper.Map<List<DoctorViewModel>>(doctorsPageModel.Items);

            var model = new PageViewModel<DoctorViewModel>(doctorsPageModel.Count, pageIndex, _pageSize, mappedDoctors);
            ViewBag.PageSize = _pageSize;
            return View(model);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> CreateDoctor()
        {
            _logger.LogInformation("Doctor - Create Doctor Get Request");
            ViewBag.Specialties = await GetSpecialties();
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Doctor - Create Doctor Post Request");
                var mappedModel = _mapper.Map<DoctorDTO>(model);
                await _doctorService.CreateDoctorAsync(mappedModel);
                return RedirectToAction("GetDoctors");
            }

            ViewBag.Specialties = await GetSpecialties();
            return View(model);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> EditDoctor(int id)
        {
            _logger.LogInformation($"Doctor - Edit Doctor with id = {id} Get Request");

            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            var mappedDoctor = _mapper.Map<DoctorViewModel>(doctor);
            ViewBag.Specialties = await GetSpecialties();
            return View(mappedDoctor);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> EditDoctor(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation($"Doctor - Edit Doctor with id = {model.DoctorId} Post Request");
                var mappedModel = _mapper.Map<DoctorDTO>(model);
                await _doctorService.UpdateDoctorAsync(mappedModel);
                return RedirectToAction("GetDoctors");
            }

            ViewBag.Specialties = await GetSpecialties();
            return View(model);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> DetailsDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            var mappedDoctor = _mapper.Map<DoctorDTO>(doctor);
            return View(mappedDoctor);
        }

        [Route("[action]")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            _logger.LogInformation($"Doctor - Delete Doctor with id = {id}");
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction("GetDoctors");
        }

        private async Task<SelectList> GetSpecialties()
        {
            var specialties = await _doctorService.GetSpecialtiesAsync();
            var selectList = new SelectList(specialties, "SpecialtyId", "Name");
            return selectList;
        }
    }
}
