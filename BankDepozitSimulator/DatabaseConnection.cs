using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankDepozitSimulator
{
    internal class DatabaseConnection
    {
        public SqlConnection connection;
        private const string DATA_SOURCE = "localhost";
        private const string INITIAL_CATALOG = "BankDepositSimulator";
        private const string INTEGRATED_SECURITY = "True";

        private string connectionString = $"Data Source ={DATA_SOURCE}; Initial Catalog = {INITIAL_CATALOG}; Integrated Security = {INTEGRATED_SECURITY};";

        public void connect()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                MessageBox.Show("Database connection successfully!", "Connection successfully", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error!" + ex.Message, "Connection error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
