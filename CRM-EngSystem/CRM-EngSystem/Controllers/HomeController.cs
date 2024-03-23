using AutoMapper;
using CRM_EngSystem.DTO.Enterprise;
using CRM_EngSystem.Models;
using CRM_EngSystem_PostgreSQL.Data.Builder.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Entities.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.Repositories.Enterprise;
using CRM_EngSystem_PostgreSQL.Data.UnitOfWorkPattern;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRM_EngSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}