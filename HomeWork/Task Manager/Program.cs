using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager
{
  class Program
  {
    static void Main(string[] args)
    {
      bool goOn = true;
      while (goOn)
      {
        GetAllProcesses();
        ShowMenu();
        goOn = ExecuteCommand();
      }
    }

    private static void GetAllProcesses()
    {
      Process[] allProcesses = Process.GetProcesses();
      Console.Clear();
      Console.Write($"№  Имя процесса ");
      Console.SetCursorPosition(50, 0);
      Console.Write("Id процесса");
      int rowNum = 1;
      foreach (Process proc in allProcesses)
      {
        Console.SetCursorPosition(0, rowNum);
        Console.Write($"{rowNum}. {proc.ProcessName}");
        Console.SetCursorPosition(50, rowNum++);
        Console.Write(proc.Id);
      }
      Console.WriteLine();
    }

    private static void KillProcessById()
    {
      Console.WriteLine("Введите Id процесса, который нужно завершить");
      string idString = Console.ReadLine();
      int id;
      while (!int.TryParse(idString, out id))
      {
        Console.WriteLine("Некорректный ввод, ведите целое число");
        idString = Console.ReadLine();
      }

      Process proc = null;
      try
      {
        proc = Process.GetProcessById(id);
        proc.Kill();
        Console.WriteLine($"Процесс {proc.ProcessName} с id {proc.Id} завершен");
      }
      catch (ArgumentException)
      {
        Console.WriteLine("Процесс с указанным Id не выполняется, возможно истек срок действия идентификатора");
      }
      catch (InvalidOperationException)
      {
        Console.WriteLine("Процесс не был запущен");
      }
      catch(Exception ex)
      {
        Console.WriteLine($"Произошла ошибка: {ex.Message}");
      }
      finally
      {
        proc?.Dispose();
      }
      Console.ReadLine();
    }

    private static void KillProcessesbyName()
    {
      Console.WriteLine("Введите имя процессов, которые нужно завершить");
      string name = Console.ReadLine();
      while (string.IsNullOrWhiteSpace(name))
      {
        Console.WriteLine("Имя процесса не может быть пустым, введите корректное имя");
        name = Console.ReadLine();
      }
      Process[] processes = null;
      try
      {
        processes = Process.GetProcessesByName(name);
        if (processes.Length==0)
        {
          Console.WriteLine("Процессов стаким именем не запущено");
        }
        foreach (Process proc in processes)
        {
          try
          {
            proc.Kill();
            Console.WriteLine($"Завершен процесс {proc.ProcessName} c id {proc.Id}");
          }
          catch (InvalidOperationException)
          {
            Console.WriteLine($"С процессом с id {proc.Id} никакой процесс не связан");
          }
          finally
          {
            proc?.Dispose();
          }
        }
      }
      catch (Exception e)
      {
        Console.WriteLine("Произошла ошибка: " + e.Message);
      }
      Console.ReadLine();
    }

    private static void ShowMenu()
    {
      Console.WriteLine(@"Выберите действие и нажмите соответствующую клавишу:
r  -  обновить список процессов
k  -  завершить процесс по указанному Id
d  -  завершить процессы с указанным именем
e  -  выход");
    }

    private static bool ExecuteCommand()
    {
      char cmd = Console.ReadKey().KeyChar;
      Console.WriteLine();
      switch (cmd)
      {
        case 'r':
          GetAllProcesses();
          return true;
        case 'k':
          KillProcessById();
          return true;
        case 'd':
          KillProcessesbyName();
          return true;
        case 'e':
          return false;
        default:
          Console.WriteLine("Вы ввели несуществующую команду");
          Console.ReadLine();
          return true;
      }
    }
  }
}
