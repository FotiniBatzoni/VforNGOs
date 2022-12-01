using Microsoft.AspNetCore.Mvc;
using VforNGOss.Dapper.Repositories;
using VforNGOss.DataAccessLayer;
using VforNGOss.Models;
using VforNGOss.ViewModels;

namespace VforNGOss.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationController : Controller
    {
        private readonly ILogger<Controller> _logger;
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationController(ILogger<Controller> logger, IOrganizationRepository organizationRepository)
        {
            _logger = logger;
            _organizationRepository = organizationRepository;
        }



        // GET: OrganizationController
        public IActionResult Index()
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

    


    }
}
