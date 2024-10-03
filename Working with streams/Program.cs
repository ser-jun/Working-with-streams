using System;
using System.Threading;
namespace Lab_4
{
    internal class Program
    {
        #region variables
        static int[,] matrix;
        static int rows;
        static int cols;
        static int[] sumElemInRows;
        static int[] sumElemInCols;
        static int sum;
        #endregion
        delegate void Start();

        static void Main(string[] args)
        {
            Console.WriteLine("Введите количества строк ");
            rows = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбоцов ");
            cols = int.Parse(Console.ReadLine());


            void InicilisationMatrix()
            {
                Random random = new Random();
                matrix = new int[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {

                        matrix[i, j] = random.Next(1, 10);
                    }
                }
            }
            void ShowMatrix()
            {

                Console.WriteLine("Матрица\n");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine("\n");
                }



            }
            void SumElemInRows()
            {
                sumElemInRows = new int[rows];
                for (int i = 0; i < rows; i++)
                {
                    sum = 0;
                    for (int j = 0; j < cols; j++)
                    {
                        sum += matrix[i, j];
                    }
                    sumElemInRows[i] = sum;
                }
            }
            void SumElemInCols()
            {
                sumElemInCols = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    sum = 0;
                    for (int i = 0; i < rows; i++)
                    {
                        sum += matrix[i, j];
                    }
                    sumElemInCols[j] = sum;
                }
            }
            void ShowSumRowsAndCols()
            {
                Console.Write("Сумма элементов столбца ");
                for (int i = 0; i < cols; i++) { Console.Write(sumElemInCols[i] + " "); }
                Console.Write("\nСумма элементов строки ");
                for (int i = 0; i < rows; i++) { Console.Write(sumElemInRows[i] + " "); }
            }
            #region initilizationAndDelegate
            sumElemInCols = new int[cols];
            sumElemInRows = new int[rows];
            Start start = InicilisationMatrix;
            start += ShowMatrix;
            Thread threadSumElemInRows = new Thread(SumElemInRows);
            Thread threadSumElemInCols = new Thread(SumElemInCols);
            #endregion 
            start();
            threadSumElemInRows.Start();
            threadSumElemInCols.Start();
            threadSumElemInRows.Join();
            threadSumElemInCols.Join();
            ShowSumRowsAndCols();
        }
    }
}
