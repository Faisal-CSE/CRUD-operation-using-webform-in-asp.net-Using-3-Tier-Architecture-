using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessEntites;

namespace DataAccess
{
    public class StudentDataAccess
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["poragConString"].ToString());
        private SqlCommand cmd;
        private DataTable dt;

        //Method for Insert 
        public int StudentEntry(StudentEntites entites)
        {
            bool status = false;
            cmd = new SqlCommand("spInsertStudent",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FName", entites.FName);
            cmd.Parameters.AddWithValue("@LName", entites.LName);
            cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(entites.Age));
            cmd.Parameters.AddWithValue("@Sex", entites.Sex);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            //if (res > 0)
            //{
            //    status = true;
            //}

            return res;

        }

        //Method for getting all student
        public DataTable GetAllStudent()
        {
            cmd = new SqlCommand("spGetAllStudent",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        //Method for update student 
        public void UpdateStudent(int id, string fname, string lname, int age, string sex)
        {
            cmd = new SqlCommand("spUpdateStudent",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@FName", fname);
            cmd.Parameters.AddWithValue("@LName", lname);
            cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(age));
            cmd.Parameters.AddWithValue("@Sex", sex);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
        }

        //Method for delete student 
        public int DeleteStudent(int id)
        {
            cmd = new SqlCommand("spDeleteStudent",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();

            return res;
        }

    }
}
