using System;
using System.Windows;
using System.Windows.Controls;

namespace Zadanie8.Pages
{
    public partial class Task2Page : Page
    {
        public Task2Page()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string text = txtInput.Text;

            if (string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("Введите строку, состоящую из слов!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 0)
            {
                MessageBox.Show("Не удалось найти ни одного слова!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string longestWord = words[0];
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length > longestWord.Length)
                {
                    longestWord = words[i];
                }
            }

            txtResult.Text = "Самое длинное слово: \"" + longestWord + "\", длина: " + longestWord.Length;
        }
    }
}
