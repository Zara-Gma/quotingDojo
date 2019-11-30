using System.Collections.Generic;
using DbConnection;
using quotingDojo.Models;
using Microsoft.AspNetCore.Mvc;

namespace quotingDojo.Controllers
{
    public class QuotesController : Controller
    {
        [HttpGet("quotes/all")]
        public IActionResult All()
        {
            List<Dictionary<string, object>> allQuotes
                = DbConnector.Query("SELECT * FROM quotes");
            return View(allQuotes);
        }

        [HttpGet("quotes/new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("quotes/create")]
        public IActionResult Create(Quote newQuote)
        {

            if (ModelState.IsValid)
            {
                string insertSql = $@"
                    INSERT INTO quotes (Name, Message)
                    VALUES (
                        '{newQuote.Name}', 
                        '{newQuote.Message}')
                ";

                DbConnector.Execute(insertSql);
                return RedirectToAction("All");
            }
            else
            {
                return View("New");
            }
        }
    }
}