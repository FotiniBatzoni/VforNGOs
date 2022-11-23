using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

            List<Organization> organizationList = new List<Organization>();
            OrganizationVM organizationVM = new OrganizationVM();

            string query = "SELECT *  FROM Organizations";

            using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader;
                conn.Open();
                reader = cmd.ExecuteReader();

                if (!reader.HasRows) return null;

                // Call Read before accessing data.
                while (reader.Read())
                {
                    Organization organization = new Organization();
                    organization.Id = Convert.ToInt32(reader["Id"]);
                    organization.Email = reader["Email"].ToString();
                    organizationList.Add(organization);
                }

                organizationVM.OrganizationList = organizationList;

                reader.Close();

                conn.Close();

            }
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
        public ActionResult Create(Organization org)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
                {
                    var orgEmail = org.Email;
                    SqlCommand cmd = new SqlCommand("Insert into Organizations (Email) values(@email) ", conn);
                    cmd.Parameters.AddWithValue("email", orgEmail);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
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
            string query = "SELECT *  FROM Organizations WHERE ID=" + id;

            using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                // Call Read before accessing data.
                while (reader.Read())
                {
                    organization.Id = Convert.ToInt32(reader["Id"]);
                    organization.Email = reader["Email"].ToString();
                }

                reader.Close();
            }

            return View(organization);
        }

        // POST: OrganizationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Organization organization)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
                {
                    var organizationEmail = organization.Email;
                    SqlCommand cmd = new SqlCommand("Update Organizations Set Email = @email Where id="+id, conn);
                    cmd.Parameters.AddWithValue("email", organizationEmail);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
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
            using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand("Delete from Organizations where id = " + id + " ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
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
