using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_Application.DAL
{
    class DBAccess
    {
        private static SqlConnection objConnection;
        private static SqlDataAdapter objDataAdapter;

        public static string ConnectionString = @"Data Source=NASHS_PC\SQLEXPRESS; Initial Catalog=DemoPos; Integrated Security=True;";

        private static void OpenConnection()
        {
            try
            {
                if (objConnection == null)
                {
                    objConnection=new SqlConnection(ConnectionString);
                    objConnection.Open();
                }
                else
                {
                    if (objConnection.State != System.Data.ConnectionState.Open)
                    {
                        objConnection = new SqlConnection(ConnectionString);
                        objConnection.Open();
                    }
                } 
            }
            catch { }
            
        }
        private static void CloseConnection()
        {
            try
            {
                if (!(objConnection == null))
                {
                    if (objConnection.State == System.Data.ConnectionState.Open)
                    {
                        objConnection.Close();
                        objConnection.Dispose();
                    }
                }
            }
            catch { }
        }

        public static DataTable FillDataTable(string query, DataTable Table)
        {
            try
            {
                OpenConnection();
                objDataAdapter = new SqlDataAdapter(query, objConnection);
                objDataAdapter.Fill(Table);
                objDataAdapter.Dispose();
                CloseConnection();
                return Table;
            }
            catch
            {
                return null;
            }
        }

        public static bool ExecuteInsertQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
    
}
