﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace VforNGOss.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IConfiguration _configuration;


        // GET: OrganizationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrganizationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrganizationController/Create
        public ActionResult Create()
        {
            using (SqlConnection conn = new SqlConnection("Server= .; Database=VforNGOs;Trusted_Connection=True;"))
            {
                int count = 0;
                var orgEmail = String.Format("org{0}@mail.com", count);
                SqlCommand cmd = new SqlCommand("Insert into Organizations (Email) values(@email) ", conn);
                cmd.Parameters.AddWithValue("email", orgEmail);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            return View();
        }

        // POST: OrganizationController/Create
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

        // GET: OrganizationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrganizationController/Edit/5
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

        // GET: OrganizationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrganizationController/Delete/5
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