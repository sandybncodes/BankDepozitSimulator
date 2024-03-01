using System;
using System.Collections.Generic;
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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        const string DASHBOARD_OPTION = "dashboardOption";
        const string TRADES_OPTION = "tradesOption";
        const string ACCOUNT_OPTION = "accountOption";
        const string STATISTICS_OPTION = "statisticsOption";
        const string SETTINGS_OPTION = "settingsOption";
        const string REPORTS_OPTION = "reportsOption";

        public Dashboard()
        {
            InitializeComponent();

            dashboardFrame dashboardFrame = new dashboardFrame();
            rightMainGrid.Children.Add(dashboardFrame);

            dashboardInitialState();
        }
        private void dashboardInitialState()
        {
            menuToolBarPanel.Width = 50;
            userLabel.Visibility = Visibility.Hidden;
            logoImg.Visibility = Visibility.Hidden;
        }
        private void objectMouseEnter(Grid obj)
        {
            obj.Background = new SolidColorBrush(Color.FromRgb(75, 100, 113));
        }

        private void objectMouseLeave(Grid obj)
        {
            obj.Background = Brushes.Transparent;
        }

        private void MouseEnter(object sender, MouseEventArgs e)
        {   
            if(sender is Grid grid)
            {
                switch (grid.Name)
                {
                    case TRADES_OPTION: objectMouseEnter(tradesOption); break;
                    case ACCOUNT_OPTION: objectMouseEnter(accountOption); break;
                    case STATISTICS_OPTION: objectMouseEnter(statisticsOption); break;
                    case SETTINGS_OPTION: objectMouseEnter(settingsOption); break;
                    case REPORTS_OPTION: objectMouseEnter(reportsOption); break;
                    case DASHBOARD_OPTION: objectMouseEnter(dashboardOption); break;
                }
            }
        }

        private void MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is Grid grid)
            {
                switch (grid.Name)
                {
                    case TRADES_OPTION: objectMouseLeave(tradesOption); break;
                    case ACCOUNT_OPTION: objectMouseLeave(accountOption); break;
                    case STATISTICS_OPTION: objectMouseLeave(statisticsOption); break;
                    case SETTINGS_OPTION: objectMouseLeave(settingsOption); break;
                    case REPORTS_OPTION: objectMouseLeave(reportsOption); break;
                    case DASHBOARD_OPTION: objectMouseLeave(dashboardOption); break;
                }
            }
        }

        private void menuMouseEnter(object sender, MouseEventArgs e)
        {
            menuToolBarPanel.Width = 160;
            userLabel.Visibility = Visibility.Visible;
            logoImg.Visibility = Visibility.Visible;
        }

        private void menuMouseLeave(object sender, MouseEventArgs e)
        {
            dashboardInitialState();
        }

        private void MouseDown(object sender, MouseButtonEventArgs e)
        {
            tradesFrame tradesFrame = new tradesFrame();
            rightMainGrid.Children.Clear();
            rightMainGrid.Children.Add(tradesFrame);
        }

        private void dashboardMouseDown(object sender, MouseButtonEventArgs e)
        {
            dashboardFrame dashboardFrame = new dashboardFrame();
            rightMainGrid.Children.Clear();
            rightMainGrid.Children.Add(dashboardFrame);
        }
    }
}
