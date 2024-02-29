using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankDepozitSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Login login = new Login();
        DatabaseConnection cnn = new DatabaseConnection();
        public MainWindow()
        {
            InitializeComponent();
            cnn.connect();
            
            login.loginButton.Click += LoginButtonClick;
            main_grid.Children.Add(login);
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            string username = login.usernameTextBox.Text;
            string password = login.passwordTextBox.Password;

            if (username != "" && password != "")
            {
                try
                {
                    string dbUsername = "";
                    string dbPassword = "";
                    string sqlQuery = $"SELECT username, password FROM USERS.ACCOUNTS WHERE username = '{username}'";
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn.connection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        dbUsername = sqlDataReader["username"].ToString();
                        dbPassword = sqlDataReader["password"].ToString();
                    }

                    if (dbUsername == username && dbPassword == password)
                    {
                        main_grid.Children.Clear();

                        Dashboard dashboard = new Dashboard();
                        dashboard.userLabel.Content = username + " " + password;
                        main_grid.Children.Add(dashboard);
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Username and password should not be empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
