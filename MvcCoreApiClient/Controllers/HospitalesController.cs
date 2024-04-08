using Microsoft.AspNetCore.Mvc;
using MvcCoreApiClient.Models;
using MvcCoreApiClient.Services;

namespace MvcCoreApiClient.Controllers
{
    public class HospitalesController : Controller
    {
        private ServiceHospital service;

        public HospitalesController(ServiceHospital service) 
        { 
            this.service = service;
        }

        public async Task<IActionResult> Servidor()
        {
            List<Hospital> hospitals =
                await this.service.GetHospitalesAsync();
            return View(hospitals); 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cliente()
        {
            return View();
        }
    }
}
