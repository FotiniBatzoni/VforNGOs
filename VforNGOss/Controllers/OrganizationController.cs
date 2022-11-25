using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

            //List<Organization> organizationList = new List<Organization>();
            //OrganizationVM organizationVM = new OrganizationVM();

            //string query = "SELECT *  FROM Organizations";


            //SqlDataReader reader = DataAccessClient.ExecuteReader(query);

            //// Call Read before accessing data.
            //while (reader.Read())
            //{
            //    Organization organization = new Organization();
            //    organization.Id = Convert.ToInt32(reader["Id"]);
            //    organization.Email = reader["Email"].ToString();
            //    organizationList.Add(organization);
            //}

            //organizationVM.OrganizationList = organizationList;

            //reader.Close();

            //DataAccessClient.ConnectionClose();

            OrganizationVM organizationVM = new OrganizationVM();
            organizationVM.OrganizationList = DataMapper.GetAllOrganizations();;
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
                //var orgEmail = org.Email;
                //string query = "Insert into Organizations (Email) values(@email)";

                //DataAccessClient.ExecuteNonQuery(query, "email", orgEmail);

                //DataAccessClient.ConnectionClose();

                DataMapper.PostOrganization(organization);

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
            //string query = "SELECT *  FROM Organizations WHERE ID=" + id;

            //SqlDataReader reader = DataAccessClient.ExecuteReader(query);
            //while (reader.Read())
            //{
            //    organization.Id = Convert.ToInt32(reader["Id"]);
            //    organization.Email = reader["Email"].ToString();
            //}
            //DataAccessClient.ConnectionClose();
            DataMapper.GetOrganizationById(id,organization);
            return View(organization);
        }

        // POST: OrganizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Organization organization)
        {
            try
            {
                //string query = "Update Organizations Set Email = @email Where id=" + id;

                //DataAccessClient.ExecuteNonQuery(query, "email", organization.Email);
                //DataAccessClient.ConnectionClose();

                DataMapper.EditOrganizationById(id, organization);

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
            string query = "Delete from Organizations where id = " + id;

            DataAccessClient.ExecuteNonQuery(query);
            DataAccessClient.ConnectionClose();
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
