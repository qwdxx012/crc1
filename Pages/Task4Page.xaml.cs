using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Zadanie8.Pages
{
    public partial class Task4Page : Page
    {
        public Task4Page()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string text = txtInput.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Введите числа через пробел!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string[] parts = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int[] array = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                int value;
                bool isNumber = int.TryParse(parts[i], out value);

                if (!isNumber)
                {
                    MessageBox.Show("Все элементы массива должны быть целыми числами!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                array[i] = value;
            }

            int firstEvenIndex = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    firstEvenIndex = i;
                    break;
                }
            }

            int lastNegativeIndex = -1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] < 0)
                {
                    lastNegativeIndex = i;
                    break;
                }
            }

            if (firstEvenIndex == -1 || lastNegativeIndex == -1)
            {
                txtResult.Text = "В массиве нет чётного или отрицательного элемента, менять местами нечего.";
                return;
            }

            int temp = array[firstEvenIndex];
            array[firstEvenIndex] = array[lastNegativeIndex];
            array[lastNegativeIndex] = temp;

            txtResult.Text = "Результат: " + ArrayToString(array);
        }

        private string ArrayToString(int[] array)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(array[i]);
                if (i < array.Length - 1)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
    }
}
