using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieDB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieSubmissionContext movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieSubmissionContext newOne)
        {
            _logger = logger;
            movieContext = newOne;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }
        /*when the page is called for the first time*/
        [HttpGet]
        public IActionResult MovieSubmission()
        {
            return View();
        }
        /*when a submission is posted*/
        [HttpPost]
        public IActionResult MovieSubmission(SubmissionResponse sr)
        {
            /*adds changes to database and saves them*/
            movieContext.Add(sr);
            movieContext.SaveChanges();

            return View("Confirmation", sr);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
