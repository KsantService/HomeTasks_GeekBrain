using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exercise5
{
  public class ToDoList
  {
    public  List<ToDo> Tasks { get; set; }

    public ToDoList()
    {
      Tasks = new List<ToDo>();
    }

    private bool ValidateNumber(int number)
    {
      if (number <= 0 || number > Tasks.Count)
      {
        Console.WriteLine($"Нет задачи с номером {number}");
        Console.ReadKey();
        return false;
      }

      return true;
    }

    public void AddTask(string title)
    {
      if (string.IsNullOrWhiteSpace(title))
      {
        Console.WriteLine("Нельзя создать пустую задачу");
        return;
      }
      Tasks.Add(new ToDo(title));
    }

    public void RemoveTask(int number)
    {
      if (ValidateNumber(number))
      {
        Tasks.RemoveAt(number - 1);
      }
    }

    public void SetLikeDone(int number)
    {
      if (ValidateNumber(number))
      {
        Tasks[number-1].CheckLikeDone();
      }
    }

    public void Show()
    {
      if (Tasks.Count == 0)
      {
        Console.WriteLine("Список задач пуст");
        return;
      }
      Console.WriteLine("Список задач");
      for (int i = 0; i < Tasks.Count; i++)
      {
        Console.WriteLine($"{i+1}.\t{Tasks[i]}");
      }
    }

    public void Save(string fileName)
    {
      string json = JsonSerializer.Serialize(this);
      File.WriteAllText(fileName, json);
    }
  }
}
