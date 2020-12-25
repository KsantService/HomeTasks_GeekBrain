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
    private const string fileName = "output.txt";
    static void Main(string[] args)
    {
     Console.WriteLine("Введите путь");
     string path = Console.ReadLine();
     while (!Directory.Exists(path))
     {
       Console.WriteLine("Такой директории не существует, попробуйте еще раз");
       path = Console.ReadLine();
     }
     File.WriteAllText(fileName,String.Empty);
     WriteDirecory(path);
    }

    private static void WriteDirecory(string path)
    {
      File.AppendAllText(fileName,path+"\n");
      
      foreach( string childPath in Directory.EnumerateDirectories(path))
      {
        WriteDirecory(childPath);
      }
      foreach (string childFileName in Directory.GetFiles(path))
      {
        File.AppendAllText(fileName, Path.Combine(path,fileName)+"\n");
      }
      
    }
    
  }
}
