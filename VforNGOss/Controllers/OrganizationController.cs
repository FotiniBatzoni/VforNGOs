using Microsoft.AspNetCore.Mvc;
using VforNGOss.DataAccessLayer;
using VforNGOss.Models;
using VforNGOss.ViewModels;

namespace VforNGOss.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IConfiguration _configuration;


        // GET: OrganizationController
        public ActionResult Index()
        {
            OrganizationVM organizationVM = new OrganizationVM();
            organizationVM.OrganizationList = Repository.GetAllOrganizations();;
            return View(organizationVM);
        }

    


        // GET: OrganizationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganizationController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: OrganizationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization)
        {
            try
            {
                Repository.PostOrganization(organization);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Edit/5
        public ActionResult Edit(int id)
        {
            Organization organization = new Organization();

            Repository.GetOrganizationById(id,organization);
            return View(organization);
        }

        // POST: OrganizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Organization organization)
        {
            try
            {
                Repository.EditOrganizationById(id, organization);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrganizationController/Delete/5
        public ActionResult Delete(int id)
        {

            Repository.DeleteOrganizationById(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: OrganizationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
