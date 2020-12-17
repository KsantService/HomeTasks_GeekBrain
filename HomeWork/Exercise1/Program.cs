using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
  class Program
  {
    static void Main(string[] args)
    {
      int rowCount,columnCount;

      Console.WriteLine("Задайте число строк в матрице, пожалуйста:");
      while (!Int32.TryParse(Console.ReadLine(), out rowCount)||rowCount<=0)
      {
        Console.WriteLine("Задано некорректное значение числа строк. Значение должно быть целым положительным числом");
      }

      Console.WriteLine("Задайте число столбцов в матрице, пожалуйста:");
      while (!Int32.TryParse(Console.ReadLine(), out columnCount)||columnCount<=0)
      {
        Console.WriteLine("Задано некорректное значение числа столбцов. Значение должно быть целым положительным числом");
      }

      Console.WriteLine($"Cтроим случайную матрицу размера {rowCount}x{columnCount}");

      Random random = new Random();
      int[,] matrix = new int[rowCount,columnCount];
      for (int i = 0; i < rowCount; i++)
      {
        for (int j = 0; j < columnCount; j++)
        {
          matrix[i, j] = random.Next(100);
          Console.Write($"{matrix[i,j]}\t");
        }
        Console.WriteLine();
      }

      Console.WriteLine("Диагональные элементы матрицы:");
      int minDim = Math.Min(rowCount, columnCount);
      for (int i = 0; i < minDim; i++)
      {
        Console.Write($"{matrix[i,i]} ");
      }
 
      Console.ReadKey();
    }
  }
}
