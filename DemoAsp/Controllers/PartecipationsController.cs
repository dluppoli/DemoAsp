using DemoAsp.Models;
using DemoAsp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoAsp.Controllers
{
    [RoutePrefix("Partecipations")]
    public class PartecipationsController : Controller
    {
        // GET: Partecipations
        [Route("Random")]
        public ActionResult Random()
        {
            using (var context = new OlympicsEntities())
            {
                AthletesFull p = context.AthletesFull.FirstOrDefault();

                //ViewData["Titolo"] = "Partecipazione Random";
                ViewBag.Titolo = "Partecipazione Random";
                return View(p);

                //return Content("ajdsajds");
                //return JsonResult()
                //return FileResult()
                //return HttpNotFoundResult()
                //return EmptyResult()
                //return RedirectResult
            }
        }

        [Route("GetOne/{id}")]
        public ActionResult GetOne(int id)
        {
            //ViewData["Titolo"] = "Partecipazione di Id="+id;
            ViewBag.Titolo = "Partecipazione di Id=" + id;
            using (var context = new OlympicsEntities())
            {
                AthletesFull p = context.AthletesFull.FirstOrDefault(q=>q.Id==id);
                return View("Random",p);
            }
        }

        [Route("all/{idAthlete}")]
        public ActionResult GetPartecipations(int idAthlete, int pagesize=10, int page=1 )
        {
            using (var context = new OlympicsEntities())
            {
                List<AthletesFull> risultati = context.AthletesFull
                    .Where(w => w.IdAthlete == idAthlete)
                    .OrderBy(ob => ob.Id)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize)
                    .ToList();

                int righeTotali = context.AthletesFull
                    .Where(w => w.IdAthlete == idAthlete)
                    .Count();


                var vm = new PaginatedResultViewModel<AthletesFull>()
                {
                    results = risultati,
                    page = page,
                    pageSize = pagesize,
                    pages = (int)Math.Ceiling((double)righeTotali / pagesize)
                };

                return View(vm);
            }
        }

        [Route("ByYear/{idAthlete}/{year}")]
        public ActionResult GetPartecipationsByYear(int idAthlete, int year, int pagesize = 10, int page = 1)
        {
            return Content("to be defined");
        }

        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            using (var context = new OlympicsEntities())
            {
                AthletesFull p = context.AthletesFull.FirstOrDefault(q => q.Id == id);
                return View(p);
            }
        }

        [Route("Edit/{id}")]
        [HttpPost]
        public ActionResult Edit(int id, AthletesFull newPartecipation)
        {
            using (var context = new OlympicsEntities())
            {
                AthletesFull oldPartecipation = context.AthletesFull.FirstOrDefault(q => q.Id == id);

                oldPartecipation.Name = newPartecipation.Name;
                oldPartecipation.NOC = newPartecipation.NOC;

                context.SaveChanges();

                return RedirectToAction("all", new { idAthlete = newPartecipation.IdAthlete});
            }
        }
    }
}