using System;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
namespace Zadanie8.Pages
{
    public partial class Task3Page : Page
    {
        public Task3Page()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string text = txtInput.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Введите координаты точек через пробел!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string[] parts = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
            {
                MessageBox.Show("Введите минимум две точки!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            double[] points = new double[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                double value;
                string normalized = parts[i].Replace(',', '.');
                bool isNumber = double.TryParse(normalized, NumberStyles.Float,
                    CultureInfo.InvariantCulture, out value);

                if (!isNumber)
                {
                    MessageBox.Show("Все координаты должны быть числами!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                points[i] = value;
            }

            double minSum = double.MaxValue;
            double bestPoint = points[0];

            for (int i = 0; i < points.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < points.Length; j++)
                {
                    if (i != j)
                    {
                        sum += Math.Abs(points[i] - points[j]);
                    }
                }

                if (sum < minSum)
                {
                    minSum = sum;
                    bestPoint = points[i];
                }
            }

            txtResult.Text = "Точка с минимальной суммой расстояний: " + bestPoint + ", сумма расстояний: " + minSum;
        }
    }
}
