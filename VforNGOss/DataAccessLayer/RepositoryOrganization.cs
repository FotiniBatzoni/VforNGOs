using System.Data.SqlClient;
using VforNGOss.Models;

namespace VforNGOss.DataAccessLayer
{
    public static class RepositoryOrganization
    {

        public static List<Organization> GetAllOrganizations()
        {
            List<Organization> organizationList = new List<Organization>();

            string query = "SELECT *  FROM Organizations";


            SqlDataReader reader = DatabaseClient.ExecuteReader(query);

            // Call Read before accessing data.
            while (reader.Read())
            {
                Organization organization = new Organization();
                organization.Id = Convert.ToInt32(reader["Id"]);
                organization.Email = reader["Email"].ToString();
                organizationList.Add(organization);
            }

            reader.Close();

            DatabaseClient.ConnectionClose();

            return organizationList;
        }




        public static Organization PostOrganization(Organization organization)
        {
            var orgEmail = organization.Email;
            string query = "Insert into Organizations (Email) values(@email)";

            DatabaseClient.ExecuteNonQuery(query, "email", orgEmail);

            DatabaseClient.ConnectionClose();


            return organization;
        }


        public static Organization GetOrganizationById(int id, Organization organization)
        {
            ;
            string query = "SELECT *  FROM Organizations WHERE ID=" + id;

            SqlDataReader reader = DatabaseClient.ExecuteReader(query);
            while (reader.Read())
            {
                organization.Id = Convert.ToInt32(reader["Id"]);
                organization.Email = reader["Email"].ToString();
            }
            DatabaseClient.ConnectionClose();
            return organization;
        }



        public static Organization EditOrganizationById(int id, Organization organization)
        {
            string query = "Update Organizations Set Email = @email Where id=" + id;

            DatabaseClient.ExecuteNonQuery(query, "email", organization.Email);
            DatabaseClient.ConnectionClose();

            return organization;
        }

        public static Organization DeleteOrganizationById(int id)
        {
            Organization organization = new Organization();

            string query = "Delete from Organizations where id = " + id;

            DatabaseClient.ExecuteNonQuery(query);
            DatabaseClient.ConnectionClose();

            return organization;
        }
    }
}
