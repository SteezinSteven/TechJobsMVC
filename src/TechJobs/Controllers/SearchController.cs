using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {[HttpGet]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        [Route("/Search")]
        [HttpPost]
        
        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchTerm == null)
            {
                if (searchType.Equals("all"))
                {
                    List<Dictionary<string, string>> jobs = JobData.FindAll();
                    ViewBag.columns = ListController.columnChoices;
                    ViewBag.jobs = jobs;

                    
                }
                return View("Index");   
            }
          
            

            else if (searchType.Equals("all"))

            {
                
                List<Dictionary<string, string>> Items = JobData.FindByValue(searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = Items;
                return View("Index");
            
            }
            else
            { List<Dictionary<string, string>> results = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.columns = ListController.columnChoices;
                ViewBag.jobs = results;
                return View("Index");
            }
        }
        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
