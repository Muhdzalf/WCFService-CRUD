using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace service_userregistration
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        string msg;
        string dbstring = "Data Source=DZALFIQ\\DZALFIQRISABANI;Initial Catalog=TestDb;Integrated Security=True";

        public string Insert(InsertUser user)
        {
            SqlConnection con = new SqlConnection(dbstring);
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into dbo.UserTab (Name, Email) values (@Name,@Email)", con);
            cmd.Parameters.AddWithValue("@Name", user.Name);
            cmd.Parameters.AddWithValue("@Email", user.Email);

            int g = cmd.ExecuteNonQuery();
            if (g == 1)
            {
                msg = "Succesfully Add Data";
            }
            else
            {
                msg = "Failed to Add Data";
            }
            return msg;
        }

        public gettestdata Getinfo()
        {
            gettestdata g = new gettestdata();
            SqlConnection con = new SqlConnection(dbstring);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * From dbo.UserTab", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("GvTable");
            adapter.Fill(dt);
            g.usertab = dt;
            return g;
        }

        public string Update(UpdateUser u)
        {
            SqlConnection con = new SqlConnection(dbstring);
            con.Open();

            SqlCommand cmd = new SqlCommand("Update dbo.UserTab set Name = @Name, Email = @Email where User_ID = @UserID", con);
            cmd.Parameters.AddWithValue("@UserID", u.UID);
            cmd.Parameters.AddWithValue("@Name", u.Name);
            cmd.Parameters.AddWithValue("@Email", u.Email);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                msg = "Succesfully Updated";
            }
            else
            {
                msg = "Failed to Update";
            }
            return msg;
        }

        public string Delete(DeleteUser u)
        {
            SqlConnection con = new SqlConnection(dbstring);
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete dbo.UserTab where User_ID = @UserID", con);
            cmd.Parameters.AddWithValue("@UserID", u.UID);

            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                msg = "Succesfully Deleted";
            }
            else
            {
                msg = "Failed to Delete";
            }
            return msg;
        }
    }
}
 