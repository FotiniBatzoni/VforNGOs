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
    public class VolunteerController : Controller
    {
    // GET: VolunteerController
    public ActionResult Index()
    {
            List<Volunteer> volunteerList = new List<Volunteer>();
            VolunteerVM volunteerVM = new VolunteerVM();

            string query = "SELECT *  FROM Volunteers";

            SqlDataReader reader = DataAccessClient.ExecuteReader(query);

            // Call Read before accessing data.
            while (reader.Read())
            {
                Volunteer volunteer = new Volunteer();
                volunteer.Id = Convert.ToInt32(reader["Id"]);
                volunteer.Email = reader["Email"].ToString();
                volunteerList.Add(volunteer);
            }

            volunteerVM.VolunteerList = volunteerList;

            reader.Close();

            DataAccessClient.ConnectionClose();
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
        public ActionResult Create(Volunteer vol)
        {
            try
            {
                var volEmail = vol.Email;
                string query = "Insert into Volunteers (Email) values(@email)";

                DataAccessClient.ExecuteNonQuery(query, "email", volEmail);

                DataAccessClient.ConnectionClose();

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
            string query = "SELECT *  FROM Volunteers WHERE ID=" + id;

            SqlDataReader reader = DataAccessClient.ExecuteReader(query);
               while (reader.Read())
                {
                    volunteer.Id = Convert.ToInt32(reader["Id"]);
                    volunteer.Email = reader["Email"].ToString();
                }
            DataAccessClient.ConnectionClose();
            return View(volunteer);
        }

        // POST: VolunteerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Volunteer volunteer)
        {
            try
            {
                string query = "Update volunteers Set Email = @email Where id=" + id;

                DataAccessClient.ExecuteNonQuery(query, "email", volunteer.Email);
                DataAccessClient.ConnectionClose();


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
            string query = "Delete from Volunteers where id = " + id;

            DataAccessClient.ExecuteNonQuery(query);
            DataAccessClient.ConnectionClose();

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
