using Microsoft.AspNetCore.Mvc;
using OrderTask.Business.Dto;
using OrderTask.UI.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using OlderTask.Domain.Entities;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OrderTask.Business.Contracts.Persistence.IRepository;
using Microsoft.AspNetCore.Authorization;

namespace OrderTask.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginRepository _loginRep;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, ILoginRepository loginRep, IConfiguration configuration)
        {
            _logger = logger;
            _loginRep = loginRep;
            _configuration = configuration;
        }

        [Authorize]
        public ActionResult Index()
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