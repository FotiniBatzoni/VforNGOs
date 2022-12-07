using Microsoft.AspNetCore.Mvc;
using VforNGOss.Dapper.Repositories;
using VforNGOss.Models;
using VforNGOss.ViewModels;

namespace VforNGOss.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationController(IOrganizationRepository organizationRepository)
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
                organizationVM.OrganizationList = _organizationRepository.GetAll();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public ActionResult Create([FromForm] Organization organization)
        {
            try
            {
                _organizationRepository.Create(organization);
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


        // POST: OrganizationController/ForgotPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword([FromForm] Organization organization)
        {
            try
            {
               var organizationDb =  _organizationRepository.ForgotPassword(organization);

                if (organizationDb == null)
                {
                    ViewBag.emailnotfoundmsg = "Email doesn't exist";
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: OrganizationController/Edit/5
        [HttpGet]
        [Route("Edit")]
        public ActionResult Edit(Guid id)
        {
            Organization organization = new Organization();

            organization = _organizationRepository.FindById(id);
            //if (organization.Id == 0)
            //{
            //    return View("_404NotFound");
            //}
            return View(organization);

        }


        // POST: OrganizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]
        public ActionResult Edit([FromForm] Organization organization)
        {
            try
            {
                _organizationRepository.Update(organization);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: OrganizationController/Delete/5
        [HttpGet]
        [Route("Delete")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _organizationRepository.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();

            }

        }

        // POST: OrganizationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Delete")]
        public ActionResult Delete(int id, Organization organization)
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
