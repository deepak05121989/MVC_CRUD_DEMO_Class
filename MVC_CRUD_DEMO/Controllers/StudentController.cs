using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using MVC_CRUD_DEMO.Models;

namespace MVC_CRUD_DEMO.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();
            using(SqlConnection connection=new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString))
            {
                using(SqlCommand cmd=new SqlCommand())
                {
                    connection.Open();
                    string query = "select * from student";
                    cmd.CommandText = query;
                    cmd.Connection= connection;
                    SqlDataReader dr=cmd.ExecuteReader();
                    while(dr.Read())
                    {
                        Student student = new Student
                        {
                            Name = dr["Name"].ToString(),
                            RollNo = Convert.ToInt32(dr["roleno"].ToString()),
                            Address= dr["Address"].ToString(),
                            Mobile= Convert.ToInt64(dr["mobile"].ToString())

                        };
                        students.Add(student);
                    }

                }

            }
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
                    string query = "select * from student where roleno='" + id + "'";
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        student = new Student
                        {
                            Name = dr["Name"].ToString(),
                            RollNo = Convert.ToInt32(dr["roleno"].ToString()),
                            Address = dr["Address"].ToString(),
                            Mobile = Convert.ToInt64(dr["mobile"].ToString())

                        };
                    }

                }              
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            connection.Open();
                            string query = "insert into student ([Name], [Address], [mobile]) values(@Name, @Address, @mobile)";
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@Name", student.Name);
                            cmd.Parameters.AddWithValue("@Address", student.Address);
                            cmd.Parameters.AddWithValue("@mobile", student.Mobile);
                            cmd.Connection = connection;
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                return RedirectToAction("Index");
                            }

                        }


                    }
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
                    string query = "select * from student where roleno='" + id + "'";
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        student = new Student
                        {
                            Name = dr["Name"].ToString(),
                            RollNo = Convert.ToInt32(dr["roleno"].ToString()),
                            Address = dr["Address"].ToString(),
                            Mobile = Convert.ToInt64(dr["mobile"].ToString())

                        };
                    }

                }
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        connection.Open();
                        string query = "update student set [Name]=@Name, [Address]=@Address, [mobile]=@mobile where roleno='"+id+"'";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@Name", student.Name);
                        cmd.Parameters.AddWithValue("@Address", student.Address);
                        cmd.Parameters.AddWithValue("@mobile", student.Mobile);
                        cmd.Connection = connection;
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            return RedirectToAction("Index");
                        }

                    }


                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    connection.Open();
                    string query = "select * from student where roleno='" + id + "'";
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        student = new Student
                        {
                            Name = dr["Name"].ToString(),
                            RollNo = Convert.ToInt32(dr["roleno"].ToString()),
                            Address = dr["Address"].ToString(),
                            Mobile = Convert.ToInt64(dr["mobile"].ToString())

                        };
                    }

                }
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDBConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        connection.Open();
                        string query = "delete from student where roleno='" + id + "'";
                        cmd.CommandText = query;
                        cmd.Connection = connection;
                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            return RedirectToAction("Index");
                        }

                    }


                }
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}
