using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
  class Program
  {
    static void Main(string[] args)
    {
      string dirName = "Exercise 1";
      string fileName = "output.txt";

      string workDirectory = Directory.GetCurrentDirectory();
      string outputDirectory = Path.Combine(workDirectory, dirName);
      Directory.CreateDirectory(outputDirectory);

      Console.WriteLine("Введите произвольный набор данных");
      string input = Console.ReadLine(); ;
      File.WriteAllText(Path.Combine(outputDirectory,fileName),input);
    }
  }
}
