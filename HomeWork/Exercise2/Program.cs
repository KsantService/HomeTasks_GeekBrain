using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
  class Program
  {
    static void Main(string[] args)
    {
      string dirName = "Exercise 2";
      string fileName = "sartup.txt";

      string workDirectory = Directory.GetCurrentDirectory();
      string outputDirectory = Path.Combine(workDirectory, dirName);
      Directory.CreateDirectory(outputDirectory);

      string input = DateTime.Now.ToShortTimeString(); ;
      File.AppendAllLines(Path.Combine(outputDirectory,fileName),new [] {input});
    }

  }
}
