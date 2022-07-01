using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MVCSQLConnection.Models
{
    public class CourseDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CourseDal()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Course> GetAllCourse()
        {
            List<Course> list = new List<Course>();
            string str = "select * from Course";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Course f = new Course();
                    f.Id = Convert.ToInt32(dr["Id"]);
                    f.Name = dr["Name"].ToString();
                    f.Fees = Convert.ToInt32(dr["Fees"]);
                    list.Add(f);
                }
                con.Close();
                return list;
            }
            else
            {
                con.Close();
                return list;
            }

        }
        public Course GetCourseById(int id)
        {
            Course f = new Course();
            string str = "select * from Product where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    f.Id = Convert.ToInt32(dr["Id"]);
                    f.Name = dr["Name"].ToString();
                    f.Fees = Convert.ToInt32(dr["Fees"]);
                }
                con.Close();
                return f;
            }
            else
                return f;
        }
        public int Save(Course c)
        {
            string str = "insert into Course values(@name,@fees)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", c.Name);
            cmd.Parameters.AddWithValue("@fees", c.Fees);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Course f)
        {
            string str = "update Course set Name=@name,Fees=@fees where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", f.Id);
            cmd.Parameters.AddWithValue("@name", f.Name);
            cmd.Parameters.AddWithValue("@fees", f.Fees);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int id)
        {
            string str = "delete from Course where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
