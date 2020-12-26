using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
  public class DeleteComand:Comand
  {
    public DeleteComand()
    {
      type = ComandType.Delete;
      requestString = "Введите номер задания";
    }
    public override void SetParam(string param)
    {
      SetIntParam(Int32.Parse(param));
    }

    public override bool ValidateParam(string param)
    {
      if (!uint.TryParse(param, out uint o))
      {
        Console.WriteLine("Номер должен быть положительным числом");
        return false;
      }
      return true;
    }

    public override bool Execute(ToDoList list)
    {
      list.RemoveTask(intParam);
      return true;
    }
  }
}
