using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
  public class AddComand:Comand
  {
    public AddComand()
    {
      type = ComandType.Add;
      requestString = "Введите название задания";
    }

    public override void SetParam(string param)
    {
      SetStringParam(param);
    }

    public override bool ValidateParam(string param)
    {
      if (string.IsNullOrWhiteSpace(param))
      {
        Console.WriteLine("Название должно быть не пустым");
        return false;
      }
      return true;
    }

    public override bool Execute(ToDoList list)
    {
      list.AddTask(stringParam);
      return true;
    }
  }
}
