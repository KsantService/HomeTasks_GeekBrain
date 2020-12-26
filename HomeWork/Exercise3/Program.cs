using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
  class Program
  {
    static void Main(string[] args)
    {
      string dirName = "Exercise 3";
      string fileName = "output.bin";

      string workDirectory = Directory.GetCurrentDirectory();
      string outputDirectory = Path.Combine(workDirectory, dirName);
      Directory.CreateDirectory(outputDirectory);

      Console.WriteLine($"Введите, пожалуйста, произвольный набор чисел от 0 до 255 разделенных пробелом:");
      byte[] numbers;
      while (!TryGetValidInput(Console.ReadLine(), out numbers))
      {
        Console.WriteLine("Попробуйте еще раз");
      }
      File.WriteAllBytes(Path.Combine(outputDirectory, fileName), numbers);
    }

    private static bool TryGetValidInput(string input, out byte[] validated)
    {
      validated = null;
      if (string.IsNullOrWhiteSpace(input))
      {
        Console.WriteLine("");
        return false;
      }

      string[] splitInput = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
      if (splitInput.Length == 0)
      {
        return false;
      }

      validated = new byte[splitInput.Length];
      for (int i = 0; i < splitInput.Length; i++)
      {
        if (!byte.TryParse(splitInput[i], out byte currentByte))
        {
          return false;
        }

        validated[i] = currentByte;
      }

      return true;
    }
  }
}
