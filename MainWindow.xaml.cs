using System.Windows;
using Zadanie8.Pages;

namespace Zadanie8
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTask1_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new Task1Page());
        }

        private void btnTask2_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new Task2Page());
        }

        private void btnTask3_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new Task3Page());
        }

        private void btnTask4_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new Task4Page());
        }

        private void btnTask5_Click(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new Task5Page());
        }
    }
}
