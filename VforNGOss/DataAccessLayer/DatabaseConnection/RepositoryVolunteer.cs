using System.Data.SqlClient;
using VforNGOss.Models;

namespace VforNGOss.DataAccessLayer
{
    public static class RepositoryVolunteer
    {
        public static List<Volunteer> GetAllVolunteers()
        {
            List<Volunteer> volunteerList = new List<Volunteer>();

            string query = "SELECT *  FROM Volunteers";

            SqlDataReader reader = DatabaseClient.ExecuteReader(query);

            // Call Read before accessing data.
            while (reader.Read())
            {
                Volunteer volunteer = new Volunteer();
                volunteer.Id = Convert.ToInt32(reader["Id"]);
                volunteer.Email = reader["Email"].ToString();
                volunteerList.Add(volunteer);
            }

            reader.Close();

            DatabaseClient.ConnectionClose();

            return volunteerList;
        }


        public static Volunteer PostVolunteer(Volunteer volunteer)
        {
            var volEmail = volunteer.Email;

            string query = "Insert into Volunteers (Email) values(@email)";

            DatabaseClient.ExecuteNonQuery(query, "email", volEmail);

            DatabaseClient.ConnectionClose();

            return volunteer;
        }



        public static Volunteer GetVolunteerById(int id, Volunteer volunteer)
        {
            string query = "SELECT *  FROM Volunteers WHERE ID=" + id;

            SqlDataReader reader = DatabaseClient.ExecuteReader(query);
            while (reader.Read())
            {
                volunteer.Id = Convert.ToInt32(reader["Id"]);
                volunteer.Email = reader["Email"].ToString();
            }
            DatabaseClient.ConnectionClose();

            return volunteer;
        }


        public static Volunteer EditVolunteerById(int id, Volunteer volunteer)
        {
            string query = "Update volunteers Set Email = @email Where id=" + id;

            DatabaseClient.ExecuteNonQuery(query, "email", volunteer.Email);
            DatabaseClient.ConnectionClose();


            return volunteer;
        }


        public static Volunteer DeleteVolunteerById(int id)
        {
            Volunteer volunteer = new Volunteer();
            string query = "Delete from Volunteers where id = " + id;

            DatabaseClient.ExecuteNonQuery(query);
            DatabaseClient.ConnectionClose();

            return volunteer;
        }

    }
}
