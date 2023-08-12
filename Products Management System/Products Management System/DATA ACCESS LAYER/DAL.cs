using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Products_Management_System.DATA_ACCESS_LAYER
{
    class DAL
    {
        SqlConnection sqlconnection;

        //constructor to inetialize the connection object
        public DAL()
        {
            sqlconnection = new SqlConnection(@"server=DESKTOP-K1QJI6I\SQLEXPRESS;Database=Products_DB;Integrated security=true");
        }
        // open connection method
        public void open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        // close connection method
        public void close()
        {
            if (sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close();
            }
        }
        //read data from DB method
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            if ( param!=null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter DA = new SqlDataAdapter(sqlcmd);
            DataTable DT = new DataTable();
            DA.Fill(DT);
            return DT;
         }
        // insert,update,dalete data from DB Method
        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;

            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}
