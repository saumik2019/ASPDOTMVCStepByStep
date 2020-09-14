using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DataAccessLayer
{
    public class SalesERPDAL
    {
        public DataSet GetEmployees()
        {
            DataSet ds = null;
            string str = ConfigurationManager.ConnectionStrings["dbconnect"].ToString();
            using (MySqlConnection con = new MySqlConnection(str))
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblemployee;",con);
                MySqlDataAdapter dbAdapter = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                dbAdapter.Fill(ds);
                con.Close();
            }             
            return ds;
        }
        public int SaveEmployee(string firstName, string lastName, int salary)
        {
            string str = ConfigurationManager.ConnectionStrings["dbconnect"].ToString();
            using (MySqlConnection con = new MySqlConnection(str))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tblemployee (FirstName,LastName,Salary) values ('" + firstName + "','" + lastName + "'," + salary + ")",con);
                int i = cmd.ExecuteNonQuery();
                con.Close();
            }
            return 0;
        }
    }
}
