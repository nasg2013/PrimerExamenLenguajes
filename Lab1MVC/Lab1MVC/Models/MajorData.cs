using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab1MVC.Models
{
    public class MajorData
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        public List<Major> ListAll()
        {
            List<Major> majors = new List<Major>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectMajor", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                //this reads all the rows coming from DB
                while (sqlDataReader.Read())
                {
                    majors.Add(new Major
                    {
                        MajorId = Convert.ToInt32(sqlDataReader["MajorId"]),
                        Name = sqlDataReader["Name"].ToString(),
                    }
                    );
                }
                connection.Close();
            }
            return majors;
        }
    }
}