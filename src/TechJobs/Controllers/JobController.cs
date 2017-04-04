using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.ViewModels;
using TechJobs.Models;
using System.Collections.Generic;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // Get the Job with the given ID and pass it into the view
            Job job = jobData.Find(id);
            DisplayJobViewModel displayJobViewModel = new DisplayJobViewModel();
            displayJobViewModel.job = job;

            return View(displayJobViewModel);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.
            if (ModelState.IsValid)
            {
                Employer employer = jobData.Employers.Find(newJobViewModel.EmployerID);
                Location location = jobData.Locations.Find(newJobViewModel.LocationID);
                PositionType positionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID);
                CoreCompetency coreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID);
                Job newJob = new Job {
                    Name = newJobViewModel.Name,
                    Employer = employer,
                    Location = location,
                    PositionType = positionType,
                    CoreCompetency = coreCompetency
                };
                jobData.Jobs.Add(newJob);

                // display job on page made earlier
                return Redirect("/Job?id=" + newJob.ID);
            }

            return View(newJobViewModel);
        }
    }
}
