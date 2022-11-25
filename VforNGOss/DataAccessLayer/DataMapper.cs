using System.Data.SqlClient;
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


        public static Volunteer PostVolunteer(Volunteer volunteer)
        {
            var volEmail = volunteer.Email;

            string query = "Insert into Volunteers (Email) values(@email)";

            DataAccessClient.ExecuteNonQuery(query, "email", volEmail);

            DataAccessClient.ConnectionClose();

            return volunteer;
        }



        public static Volunteer GetVolunteerById(int id)
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

            return volunteer;
        }


        public static Volunteer EditVolunteerById(int id, Volunteer volunteer)
        {
            string query = "Update volunteers Set Email = @email Where id=" + id;

            DataAccessClient.ExecuteNonQuery(query, "email", volunteer.Email);
            DataAccessClient.ConnectionClose();


            return volunteer;
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




        public static Organization PostOrganization(Organization organization)
        {
            var orgEmail = organization.Email;
            string query = "Insert into Organizations (Email) values(@email)";

            DataAccessClient.ExecuteNonQuery(query, "email", orgEmail);

            DataAccessClient.ConnectionClose();


            return organization;
        }



        public static Organization EditOrganizationrById(int id, Organization organization)
        {
            string query = "Update Organizations Set Email = @email Where id=" + id;

            DataAccessClient.ExecuteNonQuery(query, "email", organization.Email);
            DataAccessClient.ConnectionClose();

            return organization;
        }
    }
}
