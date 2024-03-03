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
    /// Interaction logic for tradesFrame.xaml
    /// </summary>
    public partial class tradesFrame : UserControl
    {
        DatabaseConnection cnn = new DatabaseConnection();
        public tradesFrame()
        {
            InitializeComponent();
            cnn.connect();
            selectTrades();
        }

        // TEST VALUES
        /*private const string TEST_DEPOSIT_TYPE = "Alegro";
        private const string TEST_CURRENCY = "DOLLAR";
        private const double TEST_INVESTED_AMT = 1845.23;
        private const double TEST_RATE_PCT = 3.40;
        private const double TEST_CHARGED_PCT = 78.67;
        private const double TEST_CHARGED_AMT = 23.45;
        private const double TEST_PROFIT_AMT = 126.78;
        private const string TEST_REIVEST = "NO";*/

        private Thickness COLUMNS_MARGIN = new Thickness(0, 15, 30, 0);
        private SolidColorBrush COLUMN_NAME_FOREGROUND = new SolidColorBrush(Color.FromRgb(18, 162, 177));

        private void singleTradeSettings(StackPanel stackPanel, Label column, Label value)
        {
            stackPanel.Orientation = Orientation.Vertical;
            stackPanel.Margin = COLUMNS_MARGIN;

            column.FontSize = 20;
            column.Foreground = COLUMN_NAME_FOREGROUND;

            value.FontSize = 15;
            value.Foreground = Brushes.White;

            stackPanel.Children.Add(column);
            stackPanel.Children.Add(value);
        }

        private void selectTrades()
        {
            User user = new User();

            tradesToolBarPanel.Children.Clear();
            double contentHeight = 0;
            int count = 0;

            int dbTradeID = 0;
            string dbDepositType = "";
            string dbCurrency = "";
            double dbInvestedAmt = 0.00;
            double dbRatePCT = 0.00;
            double dbChargedPCT = 0.00;
            double dbProfitAMT = 0.00;
            double dbChargedAMT = 0.00;
            string dbReinvest = "";

            try
            {
                string sqlQuery = $"EXEC selectTrades @userSSN = '{User.userSSN}', @userAccountID = {User.accountID}, @bankAccountID = {User.bankAccountID};";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, cnn.connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    dbTradeID = int.Parse(sqlDataReader["trade_id"].ToString());
                    dbDepositType = sqlDataReader["deposit_type"].ToString();
                    dbCurrency = sqlDataReader["currency"].ToString();
                    dbInvestedAmt = double.Parse(sqlDataReader["invested_amt"].ToString());
                    dbRatePCT = double.Parse(sqlDataReader["annual_rate_pct"].ToString());
                    dbChargedPCT = double.Parse(sqlDataReader["annual_charged_pct"].ToString());
                    dbProfitAMT = double.Parse(sqlDataReader["annual_profit_amt"].ToString());
                    dbChargedAMT = double.Parse(sqlDataReader["annual_charged_amt"].ToString());
                    dbReinvest = sqlDataReader["reinvest"].ToString();

                    Border marginBorder = new Border();
                    marginBorder.Padding = new Thickness(5, 5, 5, 5);
                    marginBorder.Background = new SolidColorBrush(Color.FromRgb(52, 62, 74));
                    marginBorder.Margin = new Thickness(5, 5, 5, 5);
                    marginBorder.CornerRadius = new CornerRadius(5, 5, 5, 5);

                    StackPanel grid = new StackPanel();
                    grid.Orientation = Orientation.Vertical;

                    StackPanel firstRowGrid = new StackPanel();
                    firstRowGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
                    firstRowGrid.VerticalAlignment = VerticalAlignment.Top;
                    firstRowGrid.Height = 50;
                    firstRowGrid.Orientation = Orientation.Horizontal;

                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = 10;
                    ellipse.Height = 10;
                    ellipse.Fill = Brushes.Green;
                    ellipse.HorizontalAlignment = HorizontalAlignment.Left;
                    ellipse.Margin = new Thickness(10, 0, 0, 0);

                    Label titleLable = new Label();
                    titleLable.Content = dbTradeID;
                    titleLable.FontSize = 25;
                    titleLable.Foreground = Brushes.White;
                    titleLable.VerticalContentAlignment = VerticalAlignment.Center;

                    firstRowGrid.Children.Add(ellipse);
                    firstRowGrid.Children.Add(titleLable);

                    Rectangle rectangle = new Rectangle();
                    rectangle.Height = 1;
                    rectangle.Fill = Brushes.WhiteSmoke; //new SolidColorBrush(Color.FromRgb(42, 51, 60));
                    rectangle.VerticalAlignment = VerticalAlignment.Top;
                    rectangle.HorizontalAlignment = HorizontalAlignment.Stretch;

                    StackPanel tradesColumnsPanel = new StackPanel();
                    tradesColumnsPanel.Orientation = Orientation.Horizontal;

                    // ADD TRADE'S COLUMNS - EACH COLUMN WILL BE CREATED AS A StackPanel AND WILL CONTAIN THE COLUMN NAME AND VALUE

                    // DEPOSIT ---------------------------------------------------
                    StackPanel depositColumn = new StackPanel();

                    Label DEPOSIT_TYPE_COLUMN = new Label();
                    DEPOSIT_TYPE_COLUMN.Content = "Deposit Type";

                    Label DEPOSIT_TYPE_VALUE = new Label();
                    DEPOSIT_TYPE_VALUE.Content = dbDepositType;

                    singleTradeSettings(depositColumn, DEPOSIT_TYPE_COLUMN, DEPOSIT_TYPE_VALUE);

                    // CURRENCY ---------------------------------------------------
                    StackPanel currencyColumn = new StackPanel();

                    Label CURRENCY_COLUMN = new Label();
                    CURRENCY_COLUMN.Content = "Currency";

                    Label CURRENCY_VALUE = new Label();
                    CURRENCY_VALUE.Content = dbCurrency;

                    singleTradeSettings(currencyColumn, CURRENCY_COLUMN, CURRENCY_VALUE);


                    // INVESTED_AMT ---------------------------------------------------
                    StackPanel investedAmtColumn = new StackPanel();

                    Label INVESTED_AMT_COLUMN = new Label();
                    INVESTED_AMT_COLUMN.Content = "Invested Amount";

                    Label INVESTED_AMT_VALUE = new Label();
                    INVESTED_AMT_VALUE.Content = dbInvestedAmt;

                    singleTradeSettings(investedAmtColumn, INVESTED_AMT_COLUMN, INVESTED_AMT_VALUE);

                    // RATE PCT ---------------------------------------------------
                    StackPanel ratePctColumn = new StackPanel();

                    Label RATE_PCT_COLUMN = new Label();
                    RATE_PCT_COLUMN.Content = "Rate %";

                    Label RATE_PCT_VALUE = new Label();
                    RATE_PCT_VALUE.Content = dbRatePCT + " %";

                    singleTradeSettings(ratePctColumn, RATE_PCT_COLUMN, RATE_PCT_VALUE);


                    // CHARGED PCT ---------------------------------------------------

                    StackPanel chargedPctColumn = new StackPanel();

                    Label CHARGED_PCT_COLUMN = new Label();
                    CHARGED_PCT_COLUMN.Content = "Charged %";

                    Label CHARGED_PCT_VALUE = new Label();
                    CHARGED_PCT_VALUE.Content = dbChargedPCT + " %";

                    singleTradeSettings(chargedPctColumn, CHARGED_PCT_COLUMN, CHARGED_PCT_VALUE);

                    // CHARGED AMT ---------------------------------------------------
                    StackPanel chargedAmtColumn = new StackPanel();

                    Label CHARGED_AMT_COLUMN = new Label();
                    CHARGED_AMT_COLUMN.Content = "Charged Amount";

                    Label CHARGED_AMT_VALUE = new Label();
                    CHARGED_AMT_VALUE.Content = dbChargedAMT;

                    singleTradeSettings(chargedAmtColumn, CHARGED_AMT_COLUMN, CHARGED_AMT_VALUE);

                    // PROFIT AMT ---------------------------------------------------
                    StackPanel profitAmtColumn = new StackPanel();

                    Label PROFIT_AMT_COLUMN = new Label();
                    PROFIT_AMT_COLUMN.Content = "Profit Amount";

                    Label PROFIT_AMT_VALUE = new Label();
                    PROFIT_AMT_VALUE.Content = dbProfitAMT;

                    singleTradeSettings(profitAmtColumn, PROFIT_AMT_COLUMN, PROFIT_AMT_VALUE);

                    // REINVEST ---------------------------------------------------
                    StackPanel reinvestColumn = new StackPanel();

                    Label REINVEST_COLUMN = new Label();
                    REINVEST_COLUMN.Content = "Reinvest";

                    Label REINVEST_VALUE = new Label();
                    REINVEST_VALUE.Content = dbReinvest;

                    singleTradeSettings(reinvestColumn, REINVEST_COLUMN, REINVEST_VALUE);


                    //----------------------------------------------------------------
                    tradesColumnsPanel.Children.Add(depositColumn);
                    tradesColumnsPanel.Children.Add(currencyColumn);
                    tradesColumnsPanel.Children.Add(investedAmtColumn);
                    tradesColumnsPanel.Children.Add(ratePctColumn);
                    tradesColumnsPanel.Children.Add(chargedPctColumn);
                    tradesColumnsPanel.Children.Add(chargedAmtColumn);
                    tradesColumnsPanel.Children.Add(profitAmtColumn);
                    tradesColumnsPanel.Children.Add(reinvestColumn);

                    grid.Children.Add(firstRowGrid);
                    grid.Children.Add(rectangle);
                    grid.Children.Add(tradesColumnsPanel);

                    marginBorder.Child = grid;

                    tradesToolBarPanel.Children.Add(marginBorder);

                    contentHeight = marginBorder.Height;
                    count++;
                }
                //tradesToolBarPanel.Height = count * contentHeight + count * 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            /*MessageBox.Show($"Trades selected successfully! \nCount = {count}\nUser = {User.username}, {User.accountID}, {User.bankAccountID}");*/
            tradesToolBarPanel.Height = count * contentHeight + count * 10;
        }
    }
}
