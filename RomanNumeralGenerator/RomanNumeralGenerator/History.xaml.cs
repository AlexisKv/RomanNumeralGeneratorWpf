using System;
using System.Collections.Generic;
using System.Windows;


namespace RomanNumeralGenerator
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Window
    {
        private MainWindow _mainWindow;

        
        public History( MainWindow mainWindow)
        {
            InitializeComponent();

            List<string> strList = new List<String>() { "2 , II , 12/22/2022", "1 , I , 12/22/2022", "10 , X , 12/22/2022"};

            _mainWindow = mainWindow;
            
            AllLogs.ItemsSource = strList;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            _mainWindow.Show();
            Close();
        }
        
    }
}
