using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using CRUDMVC.Models;
using System.Data;

namespace CRUDMVC.Repository
{
    public class DAL
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        
        public List<User>GetDataList()
        {

            List<User>lst = new List<User>();
            SqlCommand cmd = new SqlCommand("sp_select", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                lst.Add(new User{
                    Id = Convert.ToInt32(dr[0]),
                    Name = Convert.ToString(dr[1]),
                    EmailId = Convert.ToString(dr[2]),
                    Password = Convert.ToString(dr[3])
                 });
            }
            return lst;
        }
        public bool InsertData(User ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",ur.Id);
            cmd.Parameters.AddWithValue("@name",ur.Name);
            cmd.Parameters.AddWithValue("@email",ur.EmailId);
            cmd.Parameters.AddWithValue("@pwd",ur.Password);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 1)
            {
                return true;
            }
            else
            {
                return false ;
            }
        }
        public bool UpdateData(User ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",ur.Id);
            cmd.Parameters.AddWithValue("@name",ur.Name);
            cmd.Parameters.AddWithValue("@email",ur.EmailId);
            cmd.Parameters.AddWithValue("@pwd",ur.Password);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 1)
            {
                return true;
            }
            else
            {
                return false ;
            }
        }
        public bool DeleteData(User ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",ur.Id);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 1)
            {
                return true;
            }
            else
            {
                return false ;
            }
        }

    }
}