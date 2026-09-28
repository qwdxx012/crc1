using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Zadanie8.Pages
{
    public partial class Task5Page : Page
    {
        private Random random = new Random();

        public Task5Page()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            int rows, columns;
            bool rowsOk = int.TryParse(txtRows.Text, out rows);
            bool columnsOk = int.TryParse(txtColumns.Text, out columns);

            if (!rowsOk || !columnsOk)
            {
                MessageBox.Show("Число строк и столбцов должно быть целым числом!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (rows < 1 || columns < 1 || rows > 20 || columns > 20)
            {
                MessageBox.Show("Число строк и столбцов должно быть от 1 до 20!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int[,] array = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = random.Next(-10, 11);
                }
            }

            int[] flatArray = new int[rows * columns];
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    flatArray[index] = array[i, j];
                    index++;
                }
            }

            // Сортировка по возрастанию простым методом пузырька
            int[] ascendingArray = (int[])flatArray.Clone();
            BubbleSortAscending(ascendingArray);

            // Сортировка по убыванию
            int[] descendingArray = (int[])flatArray.Clone();
            BubbleSortDescending(descendingArray);

            // Поиск максимума и минимума
            int max = flatArray[0];
            int min = flatArray[0];
            for (int i = 1; i < flatArray.Length; i++)
            {
                if (flatArray[i] > max) max = flatArray[i];
                if (flatArray[i] < min) min = flatArray[i];
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Исходный массив:");
            sb.AppendLine(MatrixToString(array, rows, columns));

            sb.AppendLine("Отсортирован по возрастанию:");
            sb.AppendLine(FlatArrayToMatrixString(ascendingArray, rows, columns));

            sb.AppendLine("Отсортирован по убыванию:");
            sb.AppendLine(FlatArrayToMatrixString(descendingArray, rows, columns));

            sb.AppendLine("Максимальный элемент: " + max);
            sb.AppendLine("Минимальный элемент: " + min);

            txtResult.Text = sb.ToString();
        }

        // Сортировка пузырьком по возрастанию
        private void BubbleSortAscending(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        // Сортировка пузырьком по убыванию
        private void BubbleSortDescending(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        // Выводит двумерный массив в виде текстовой таблицы
        private string MatrixToString(int[,] array, int rows, int columns)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sb.Append(array[i, j].ToString().PadLeft(4));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        // Выводит одномерный (отсортированный) массив в виде таблицы rows x columns
        private string FlatArrayToMatrixString(int[] flatArray, int rows, int columns)
        {
            StringBuilder sb = new StringBuilder();
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sb.Append(flatArray[index].ToString().PadLeft(4));
                    index++;
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
