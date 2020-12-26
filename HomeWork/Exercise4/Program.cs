using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
  class Program
  {
    private const string fileNameForRecursion = "recursiveOutput.txt";
    private const string fileNameForStack = "stackOutput.txt";
    static void Main(string[] args)
    {
      string path = GetValidPath();
      File.WriteAllText(fileNameForRecursion, string.Empty);
      WriteDirecory(path);
    }

    private static string GetValidPath()
    {
      Console.WriteLine("Введите путь");
      string path = Console.ReadLine();
      while (!Directory.Exists(path))
      {
        Console.WriteLine("Такой директории не существует, попробуйте еще раз");
        path = Console.ReadLine();
      }
      return path;
    }

    private static void WriteDirecory(string path)
    {
      List<string> FoldersAndFiles = new List<string>();
      ProcessDirectory(path,FoldersAndFiles,"");
      File.AppendAllLines(fileNameForRecursion, FoldersAndFiles);
    }

    private static void ProcessDirectory(string path, List<string> list, string tabStr)
    {
      list.Add(tabStr + path);
      foreach (string childPath in Directory.EnumerateDirectories(path))
      {
        ProcessDirectory(childPath, list,tabStr+" \t");
      }
      foreach (string childFileName in Directory.GetFiles(path))
      {
        list.Add(tabStr+Path.GetFileName(childFileName));
      }
    }



  }
}
