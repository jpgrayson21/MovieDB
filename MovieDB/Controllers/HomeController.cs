using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private MovieSubmissionContext daContext { get; set; }

        public HomeController(MovieSubmissionContext newOne)
        {

            daContext = newOne;
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
            ViewBag.Categories = daContext.Categories.ToList();

            return View();
        }
        /*when a submission is posted*/
        [HttpPost]
        public IActionResult MovieSubmission(SubmissionResponse sr)
        {
            /*adds changes to database, only if valid entries, and saves them. This is really a redundancy,
             the validation that's actually running is within the input tags on the MovieSubmission view
            (the 'required' argument).*/
            if (ModelState.IsValid)
            {
                daContext.Add(sr);
                daContext.SaveChanges();

                return View("Confirmation", sr);
            }
            else //if invalid
            {
                ViewBag.Majors = daContext.Categories.ToList();

                return View(sr);
            }
        }
        public IActionResult MovieDatabase()
        {
            var submissions = daContext.Submissions
                .Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();

            return View(submissions);
        }

        /*the get and post for the edit table option*/
        [HttpGet]
        public IActionResult Edit (int submissionid)
        {
            ViewBag.Categories = daContext.Categories.ToList();

            var submission = daContext.Submissions.Single(x => x.SubmissionId == submissionid);

            return View("MovieSubmission", submission);
        }
        [HttpPost]
        public IActionResult Edit(SubmissionResponse updatedForm)
        {
            daContext.Update(updatedForm);
            daContext.SaveChanges();

            return RedirectToAction("MovieDatabase");
        }

        /*the get and post for the delete table option*/
        [HttpGet]
        public IActionResult Delete(int submissionid)
        {
            var submission = daContext.Submissions.Single(x => x.SubmissionId == submissionid);

            return View(submission);
        }
        [HttpPost]
        public IActionResult Delete(SubmissionResponse sr)
        {
            daContext.Submissions.Remove(sr);
            daContext.SaveChanges();

            return RedirectToAction("MovieDatabase");
        }
    }
}
