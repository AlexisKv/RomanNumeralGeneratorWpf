using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using RomanNumeral.Core.Services;

namespace RomanNumeralGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRomanNumeralGenerator _romanNumeralGenerator;

        public MainWindow()
        {
            
        }
        
        public MainWindow(
            IRomanNumeralGenerator romanNumeralGenerator)
        {
            InitializeComponent();

            _romanNumeralGenerator = romanNumeralGenerator;

            DoubleAnimation generateBtnAnimation = new DoubleAnimation();
            generateBtnAnimation.From = 150;
            generateBtnAnimation.To = 450;
            generateBtnAnimation.Duration = TimeSpan.FromSeconds(3);
            GenerateBtn.BeginAnimation(Button.WidthProperty, generateBtnAnimation);

        }
        

        private void History_click(object sender, RoutedEventArgs e)
        {
            History history = new History(this);
            history.Show();
            this.Visibility = Visibility.Hidden;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            int num = Convert.ToInt32(NumberToConvert.Text);


            if (num < 1 || num > 3999)
            {
                NumberToConvert.Background = Brushes.LightPink;
                MessageBox.Show("Out of range \nAccept only 1 - 3999 numbers");
                answer.Text = "";
            }

            else
            {
                NumberToConvert.Background = Brushes.White;
                string str = _romanNumeralGenerator.Generate(num);
                answer.Text = str;

            }

        }
        
    }
}
