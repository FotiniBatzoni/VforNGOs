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


    }
}