using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
                    Volunteer volunteer = new Volunteer();
                    volunteer.Id = Convert.ToInt32(reader["Id"]);
                    volunteer.Email = reader["Email"].ToString();
                    volunteerList.Add(volunteer);
                }
                
                volunteerVM.VolunteerList = volunteerList;

                reader.Close();

                conn.Close();

            }
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
                using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
                {
                    var volEmail = vol.Email;
                    SqlCommand cmd = new SqlCommand("Insert into Volunteers (Email) values(@email) ", conn);
                    cmd.Parameters.AddWithValue("email", volEmail);
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

        // GET: VolunteerController/Edit/5
        public ActionResult Edit(int id)
        {
            Volunteer volunteer = new Volunteer();
            string query = "SELECT *  FROM Volunteers WHERE ID=" + id;

            using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                // Call Read before accessing data.
                while (reader.Read())
                {
                    volunteer.Id = Convert.ToInt32(reader["Id"]);
                    volunteer.Email = reader["Email"].ToString();
                }

                reader.Close();
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
                using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
                {
                    var volunteerEmail = volunteer.Email;
                    SqlCommand cmd = new SqlCommand("Update Volunteers Set Email = @email Where id=" + id, conn);
                    cmd.Parameters.AddWithValue("email", volunteerEmail);
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

        // GET: VolunteerController/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
            {
                SqlCommand cmd = new SqlCommand("Delete from Volunteers where id = " + id + " ", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
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
