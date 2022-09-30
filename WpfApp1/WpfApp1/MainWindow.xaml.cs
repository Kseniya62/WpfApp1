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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[,] matrix;
        private void CreateFill_Click(object sender, RoutedEventArgs e)
        {
            int SizeN = Convert.ToInt32(n.Text);
            int SizeM = Convert.ToInt32(m.Text);
            matrix = new int[SizeN, SizeM];
            Random rnd = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(50);
            DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            int[] mas = new int[matrix.GetLength(0)];
            int maxElement = matrix[0, 0], minElement = matrix[0, 0];
            int indexMax = 0, indexMin = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxElement) { maxElement = matrix[i, j]; indexMax = i; }
                    if (matrix[i, j] < minElement) { minElement = matrix[i, j]; indexMin = i; }
                }

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //        if (i == indexMax) mas[i] = matrix[i, j];

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //        if (i == indexMax) matrix[i, j] = matrix[indexMin, j];

            //for (int i = 0; i < matrix.GetLength(0); i++)
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //        if (i == indexMin) matrix[i, j] = mas[i];
            int c;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                c = matrix[indexMax,j];
                matrix[indexMax,j]= matrix[indexMin,j];
                matrix[indexMin,j]= c;
            }
            max.Text = maxElement.ToString();
            min.Text = minElement.ToString();
            strMax.Text = indexMax.ToString();
            strMin.Text = indexMin.ToString();
            DataGrid.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
        }
    }
}
