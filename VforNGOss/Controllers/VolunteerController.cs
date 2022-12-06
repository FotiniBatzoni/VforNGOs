using Microsoft.AspNetCore.Mvc;
using VforNGOss.Dapper.IRepositories;
using VforNGOss.Models;
using VforNGOss.ViewModels;

namespace VforNGOss.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolunteerController : Controller
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public VolunteerController(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }



        // GET: VolunteerController
        public IActionResult Index()
        {
            try
            {
                VolunteerVM volunteerVM = new VolunteerVM();
                volunteerVM.VolunteerList = _volunteerRepository.GetAll();
                return View(volunteerVM);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }

        // GET: VolunteerController/Details/5
        [HttpGet]
        [Route("id")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VolunteerController/Create
        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }


        // POST: VolunteerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([FromForm] Volunteer volunteer)
        {
            try
            {
                _volunteerRepository.Create(volunteer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/ForgotPassword
        [HttpGet]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword()
        {
            return View();
        }


        // POST: VolunteerController/ForgotPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword([FromForm] Volunteer volunteer)
        {
            try
            {
                _volunteerRepository.ForgotPassword(volunteer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VolunteerController/Edit/5
        [HttpGet]
        [Route("Edit")]
        public ActionResult Edit(Guid id)
        {
            Volunteer volunteer = new Volunteer();

            volunteer = _volunteerRepository.FindById(id);
            //if (volunteer.Id == 0)
            //{
            //    return View("_404NotFound");
            //}
            return View(volunteer);

        }


        // POST: VolunteerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]
        public ActionResult Edit([FromForm] Volunteer volunteer)
        {
            try
            {
                _volunteerRepository.Update(volunteer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: VolunteerController/Delete/5
        [HttpGet]
        [Route("Delete")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _volunteerRepository.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }

        }

        // POST: VolunteerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Delete")]
        public ActionResult Delete(int id, Volunteer volunteer)
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