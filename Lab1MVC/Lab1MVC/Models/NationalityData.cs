using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab1MVC.Models
{
    public class NationalityData
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public List<Nationality> ListAll()
        {
            List<Nationality> nationalities = new List<Nationality>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectNationality", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                //this reads all the rows coming from DB
                while (sqlDataReader.Read())
                {
                    nationalities.Add(new Nationality
                    {
                        NationalityId = Convert.ToInt32(sqlDataReader["NationalityId"]),
                        Name = sqlDataReader["Description"].ToString(),
                    }
                    );
                }
                connection.Close();
            }
            return nationalities;
        }
    }
}