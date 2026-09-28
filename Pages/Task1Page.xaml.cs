using System;
using System.Windows;
using System.Windows.Controls;

namespace Zadanie8.Pages
{
    public partial class Task1Page : Page
    {
        public Task1Page()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int number;
            bool isNumber = int.TryParse(txtNumber.Text, out number);

            if (!isNumber)
            {
                MessageBox.Show("Введите целое число!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (number < -999 || number > 999)
            {
                MessageBox.Show("Число должно быть в диапазоне от -999 до 999!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            txtResult.Text = GetNumberDescription(number);
        }

        private string GetNumberDescription(int number)
        {
            if (number == 0)
            {
                return "нулевое число";
            }

            string sign;
            if (number > 0)
            {
                sign = "положительное";
            }
            else
            {
                sign = "отрицательное";
            }

            int digitsCount = Math.Abs(number).ToString().Length;
            string digitsWord;

            if (digitsCount == 1)
            {
                digitsWord = "однозначное";
            }
            else if (digitsCount == 2)
            {
                digitsWord = "двузначное";
            }
            else
            {
                digitsWord = "трёхзначное";
            }

            return sign + " " + digitsWord + " число";
        }
    }
}
