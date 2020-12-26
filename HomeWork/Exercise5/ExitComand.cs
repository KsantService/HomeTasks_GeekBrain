using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
  class ExitComand:Comand
  {
    public ExitComand(string param)
    {
      type = ComandType.Exit;
      stringParam = param;
    }

    public override string ReadParam()
    {
      return String.Empty;
    }
    
    public override void SetParam(string param)
    {
    }

    public override bool ValidateParam(string param)
    {
      return true;
    }

    public override bool Execute(ToDoList list)
    {
      list.Save(stringParam);
      return false;
    }
  }
}
