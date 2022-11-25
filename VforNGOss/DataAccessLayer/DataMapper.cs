﻿using System.Data.SqlClient;
using VforNGOss.Models;

namespace VforNGOss.DataAccessLayer
{
    public static class DataMapper
    {
        public static List<Volunteer> GetAllVolunteers()
        {
            List<Volunteer> volunteerList = new List<Volunteer>();

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

            reader.Close();

            DataAccessClient.ConnectionClose();

            return volunteerList;
        }

        public static List<Organization> GetAllOrganizations()
        {
            List<Organization> organizationList = new List<Organization>();
    
            string query = "SELECT *  FROM Organizations";


            SqlDataReader reader = DataAccessClient.ExecuteReader(query);

            // Call Read before accessing data.
            while (reader.Read())
            {
                Organization organization = new Organization();
                organization.Id = Convert.ToInt32(reader["Id"]);
                organization.Email = reader["Email"].ToString();
                organizationList.Add(organization);
            }

            reader.Close();

            DataAccessClient.ConnectionClose();

            return organizationList;
        }

        public static Volunteer PostVolunteer(Volunteer vol)
        {
            var volEmail = vol.Email;

            string query = "Insert into Volunteers (Email) values(@email)";

            DataAccessClient.ExecuteNonQuery(query, "email", volEmail);

            DataAccessClient.ConnectionClose();

            return vol;
        }
    }
}
