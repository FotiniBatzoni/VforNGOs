using Microsoft.AspNetCore.Mvc;
using VforNGOss.Dapper.Repositories;
using VforNGOss.ViewModels;

namespace VforNGOss.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationController( IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }



        // GET: OrganizationController
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                OrganizationVM organizationVM = new OrganizationVM();
                organizationVM.OrganizationList =  _organizationRepository.GetAll();
                return View(organizationVM);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }


        // GET: OrganizationController/Details/5
        [HttpGet]
        [Route("id")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganizationController/Create
        [HttpGet]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }


        // POST: OrganizationController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public Task<IActionResult> Create(CreateDTO createDTO, int Id)
        //{
        //    //try
        //    //{
        //    //    RepositoryOrganization.PostOrganization(organization);

        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    //catch
        //    //{
        //    //    return View();
        //    //}

        //    try
        //    {
        //        _organizationRepository.Create(createDTO, Id);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}
