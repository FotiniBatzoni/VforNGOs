using Microsoft.AspNetCore.Mvc;
using VforNGOss.DataAccessLayer;
using VforNGOss.Models;
using VforNGOss.ViewModels;

namespace VforNGOss.Controllers
{
    public class VolunteerController : Controller
    {
    // GET: VolunteerController
    public ActionResult Index()
    {
            VolunteerVM volunteerVM = new VolunteerVM();
            volunteerVM.VolunteerList = RepositoryVolunteer.GetAllVolunteers();
            return View(volunteerVM);
    }

        // GET: VolunteerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: VolunteerController/Create
        public ActionResult Create()
        {
            return View("Create");

        }

        // POST: VolunteerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Volunteer volunteer)
        {
            try
            {
                RepositoryVolunteer.PostVolunteer(volunteer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VolunteerController/Edit/5
        public ActionResult Edit(int id)
        {
            Volunteer volunteer = new Volunteer();
            volunteer = RepositoryVolunteer.GetVolunteerById(id,volunteer);
            if (volunteer.Id == 0)
            {
                return View("_404NotFound");
            }

            return View(volunteer);
        }

        // POST: VolunteerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Volunteer volunteer)
        {
            try
            {
                RepositoryVolunteer.EditVolunteerById(id,volunteer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VolunteerController/Delete/5
        public ActionResult Delete(int id)
        {
            RepositoryVolunteer.DeleteVolunteerById(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: VolunteerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
