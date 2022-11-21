using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VforNGOss.Controllers
{
    public class VolunteerController : Controller
    {
        // GET: VolunteerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VolunteerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: VolunteerController/Create
        public ActionResult Create()
        {
      
            using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
            {
                var volEmail = String.Format("vol11@mail.com");
                SqlCommand cmd = new SqlCommand("Insert into Volunteers (Email) values(@email) ", conn);
                cmd.Parameters.AddWithValue("email", volEmail);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            return RedirectToAction("Index");
        }

        // POST: VolunteerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: VolunteerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VolunteerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: VolunteerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
