using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

       
    }
}
