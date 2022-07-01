using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MVCSQLConnection.Models
{
    public class EmployeeDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public EmployeeDal()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> list = new List<Employee>();
            string str = "select * from Employee";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                if(dr.Read())
                {
                    Employee e = new Employee();
                    e.Id = Convert.ToInt32(dr["Id"]);
                    e.Name = dr["Name"].ToString();
                    e.Designation = dr["Designation"].ToString();
                    e.Salary = Convert.ToDouble(dr["Salary"]);
                    list.Add(e);
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

        public Employee GetEmployeeById(int id)
        {
            Employee e = new Employee();
            string str = "select * from Employee where Id=@id";
            cmd = new SqlCommand(str,con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            dr =cmd.ExecuteReader();
            if(dr.HasRows)
            {
                if(dr.Read())
                {
                    e.Id = Convert.ToInt32(dr["Id"]);
                    e.Name = dr["Name"].ToString();
                    e.Designation = dr["Designation"].ToString();
                    e.Salary = Convert.ToDouble(dr["Salary"]);
                }
                con.Close();
                return e;
            }
            else
            {
                con.Close();
                return e;
            }
        }

        public int Save(Employee emp)
        {
            string str = "insert into Employee values(@name,@designation,@salary)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@designation", emp.Designation);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(Employee emp)
        {
            string str = "update Employee set Name=@name,Designation=@designation,Salary=@salary where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", emp.Id);
            cmd.Parameters.AddWithValue("@name", emp.Name);
            cmd.Parameters.AddWithValue("@designation", emp.Designation);
            cmd.Parameters.AddWithValue("@salary", emp.Salary);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int id)
        {
            string str = "delete from Employee where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
