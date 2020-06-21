using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Lab1MVC.Models
{
    public class StudentData
    {
        //Student Data use EF

        string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        /*-------------------------------------------------------------
       Methods from stored proceduress
       -------------------------------------------------------------*/
        //List All Students Entity SP
        public List<SelectStudent_Result> ListAllSp()
        {
            try
            {
                using (var context = new IF4101_A95777_2020Entities())
                {
                    return context.SelectStudent().ToList();
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }

        }

        //GET STUDENT BY ID FROM SP
        public SelectStudentById_Result GetByIdSp(int id)
        {
            try
            {
                using (var context = new IF4101_A95777_2020Entities())
                {
                    var student = context.SelectStudentById(id).Single();
                    return student;
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }

        //Get Student OR STUDENTS By Name FROM SP
        public List<SelectStudentByName_Result> GetStudentByName(string name) 
        {
            try
            {
                using (var context = new IF4101_A95777_2020Entities())
                {
                    return context.SelectStudentByName(name).ToList();
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }


        /*-------------------------------------------------------------
        Methods using LinQ
        -------------------------------------------------------------*/
        //List Students LINQ
        public List<StudentRazorDTO> ListAllLinQ()
        {
            try
            {
                using (var context = new IF4101_A95777_2020Entities())
                {
                    var students = (from student in context.Student
                                    join nationality in context.Nationality
                                    on student.Nationality
                                    equals nationality.NationalityId
                                    join major in context.Major
                                    on student.Major
                                    equals major.MajorId

                                    select new StudentRazorDTO
                                    {
                                        StudentId = student.StudentId,
                                        Name = student.Name,
                                        Age = student.Age,
                                        Seniority = student.Seniority,
                                        EntryDate = student.EntryDate,
                                        Interests = student.Interests,
                                        NationalityName = nationality.Description,
                                        MajorName = major.Name,
                                        NationalityId = nationality.NationalityId,
                                        MajorId = major.MajorId
                                    }).ToList();
                    return students;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }
        //List Students by name
        public List<StudentRazorDTO> ListAllLinQByName( string name)
        {
            try
            {
                using (var context = new IF4101_A95777_2020Entities())
                {
                    var students = (from student in context.Student
                                    join nationality in context.Nationality
                                    on student.Nationality
                                    equals nationality.NationalityId
                                    join major in context.Major
                                    on student.Major
                                    equals major.MajorId
                                    where student.Name.Contains(name)

                                    select new StudentRazorDTO
                                    {
                                        StudentId = student.StudentId,
                                        Name = student.Name,
                                        Age = student.Age,
                                        Seniority = student.Seniority,
                                        EntryDate = student.EntryDate,
                                        Interests = student.Interests,
                                        NationalityName = nationality.Description,
                                        MajorName = major.Name,
                                        NationalityId = nationality.NationalityId,
                                        MajorId = major.MajorId
                                    }).ToList();
                    return students;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }
        //Get Student by id LINQ
        public StudentRazorDTO GetByIdLinQ(int id)
        {
            try
            {
                return ListAllLinQ().Find(s => s.StudentId.Equals(id));

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }
        //Get Student by id LINQ
        public List<StudentRazorDTO> GetByNameLinQ(string name)
        {
            try
            {
                var students = from s in ListAllLinQ() where s.Name == name select s;
                return students.ToList();
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }
        /*-------------------------------------------------------------
        Others methods
        -------------------------------------------------------------*/

        public int Add(StudentDTO student)
        {
            try
            {
                int resultToReturn;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertUpdateStudent", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@StudentId", student.StudentId);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Age", student.Age);
                    command.Parameters.AddWithValue("@Nationality", student.Nationality.NationalityId);
                    command.Parameters.AddWithValue("@Major", student.Major.MajorId);
                    command.Parameters.AddWithValue("@Action", "Insert");

                    resultToReturn = command.ExecuteNonQuery();
                    connection.Close();
                }
                return resultToReturn;
            }
            catch (Exception error)
            {
                return error.HResult;
            }
            
        }
        public List<StudentDTO> ListAll()
        {
            try
            {
                List<StudentDTO> students = new List<StudentDTO>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SelectStudent", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    //this reads all the rows coming from DB
                    while (sqlDataReader.Read())
                    {
                        students.Add(new StudentDTO
                        {
                            StudentId = Convert.ToInt32(sqlDataReader["StudentId"]),
                            Name = sqlDataReader["Name"].ToString(),
                            Age = Convert.ToInt32(sqlDataReader["Age"]),
                            Nationality = new Nationality(Convert.ToInt32(sqlDataReader["NationalityId"]), sqlDataReader["NationalityName"].ToString()),
                            Major = new Major(Convert.ToInt32(sqlDataReader["MajorId"]), sqlDataReader["MajorName"].ToString())
                        }
                        );
                    }
                    connection.Close();
                }
                return students;

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }

        }
        public StudentDTO GetById(int id)
        {
            try
            {
                StudentDTO student = new StudentDTO();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SelectStudentById", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentId", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    //this reads the row coming from DB
                    if (sqlDataReader.Read())
                    {
                        student.StudentId = Convert.ToInt32(sqlDataReader["StudentId"]);
                        student.Name = sqlDataReader["Name"].ToString();
                        student.Age = Convert.ToInt32(sqlDataReader["Age"]);
                        var nationalityId = Convert.ToInt32(sqlDataReader["NationalityId"]);
                        var nationalityName = sqlDataReader["NationalityName"].ToString();
                        student.Nationality = new Nationality(nationalityId, nationalityName);
                        student.Major = new Major(Convert.ToInt32(sqlDataReader["MajorId"]), sqlDataReader["MajorName"].ToString());

                    }
                    connection.Close();
                }
                return student;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return null;
            }
        }
        public int Update(StudentDTO student)
        {
            try
            {
                int resultToReturn;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertUpdateStudent", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@StudentId", student.StudentId);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Age", student.Age);
                    command.Parameters.AddWithValue("@Nationality", student.Nationality.NationalityId);
                    command.Parameters.AddWithValue("@Major", student.Major.MajorId);
                    command.Parameters.AddWithValue("@Action", "Update");

                    resultToReturn = command.ExecuteNonQuery();
                    connection.Close();
                }
                return resultToReturn;
            }
            catch (Exception error)
            {
                return error.HResult;
            }
        }
        public int Delete(int id)
        {
            try
            {
                int resultToReturn;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteStudent", connection);

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StudentId", id);

                    resultToReturn = command.ExecuteNonQuery();
                    connection.Close();
                }
                return resultToReturn;
            }
            catch (Exception error)
            {
                return error.HResult;
            }
        }
        public int AddSp(Student student)
        {
            try
            {
                int resultToReturn;

                using (var context = new IF4101_A95777_2020Entities())
                {
                    resultToReturn = context.SpInsertUpdateStudent(student.StudentId, student.Name, student.Age, student.Nationality, student.Major, "Insert");
                }
                return resultToReturn;
            }
            catch (Exception error)
            {
                return error.HResult;
            }

        }
        public int UpdateSp(Student student)
        {
            try
            {
                int resultToReturn;

                using (var context = new IF4101_A95777_2020Entities())
                {
                    resultToReturn = context.SpInsertUpdateStudent(student.StudentId, student.Name, student.Age, student.Nationality, student.Major, "Update");
                }
                return resultToReturn;
            }
            catch (Exception error)
            {
                return error.HResult;
            }

        }
        public int DeleteSp(int id) 
        {
            try
            {
                int resultToReturn;

                using (var context = new IF4101_A95777_2020Entities())
                {
                    resultToReturn = context.SpDeleteStudent(id);
                }
                return resultToReturn;
            }
            catch (Exception error)
            {
                return error.HResult;
            }
        }

       
    }
}

//error.Message = "LINQ to Entities does not recognize the method 'Int32 ToInt32(System.Object)' method, and this method cannot be translated into a store expression."