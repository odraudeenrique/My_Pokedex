using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Data
    {


        private readonly SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public Data()
        {
            connection = new SqlConnection("server=(local)\\SQLEXPRESS01; database=My_POKEDEX_DB; integrated security=true ");
            command = new SqlCommand();
        }

        public SqlDataReader Reader
        {
            get { return this.reader; }
        }
        //Este es con querys embebidos

       
        public void SetQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }
        //Este es con stored procedure; Acá capaz convendría cambiar el nombre 
        public void SetProcedure(string storedProcedure)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = storedProcedure;
        }
        public void AddParameters(string name, object valueToAdd)
        {
            command.Parameters.AddWithValue(name, valueToAdd);
        }


        public void OpenConnection()
        {
            command.Connection = connection;
            connection.Open();
        }
        public void CloseConnection()
        {
            connection.Close();
        }

        public void ReadData()
        {
            reader = command.ExecuteReader();
        }

        public void ExecuteQuery()
        {
            command.ExecuteNonQuery();
        }
    }
}
