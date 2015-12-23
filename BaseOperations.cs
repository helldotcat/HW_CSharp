using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace BaseOperations
{
  /*Команда суммирования целочисленная*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "add")]
  public class Add : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "add <a>, <b>: " +
                         "<a> = <a> + <b>";
    public string Defenition()
    {
      return defenition;
    }

    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        int comma = parametrs.IndexOf(',');
        string left = parametrs.Substring(0, comma);
        string right = parametrs.Substring(comma + 1);
        right = right.Trim();

        int rightValue = 0;
        int result = 0;

        /*Проверка: если правый операнд -- число, то получаем значение,
        если правый операнд -- регистр, то получаем значение из регистра.*/
        int ifRightHasCount = right.IndexOfAny(new char[] { '1','2','3','4','5',
                                               '6','7','8','9','0'});
        if (ifRightHasCount == -1)
        {
          if (right.Length == 3 && right[0] == 'e' && right[2] == 'x')
          {
            for (char c = 'a'; c < 'i'; c++)
            {
              if (right[1] == c)
              {
                rightValue = CurrentStatement.GetRegister(right);
                c = 'i';
              }
            }
          }
        }
        else
        {
          rightValue = int.Parse(right);
        }

        if (left.Length == 3 && left[0] == 'e' && left[2] == 'x')
        {
          for (char c = 'a'; c < 'i'; c++)
          {
            if (left[1] == c)
            {
              /*Находим значение левого операнда (регистра).*/
              result = CurrentStatement.GetRegister(left) + rightValue;
              /*Помещаем результат выполнения операции в регистор.*/
              CurrentStatement.SetRegister(left, result);
              return;
            }
          }
        }
      }
      throw new HomeworkWPF.ParseCommandException(CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }
  }

  /*Команда вычитания целочисленная*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "sub")]
  class Sub : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "sub <a>, <b>: " +
                         "<a> = <a> - <b>";
    public string Defenition()
    {
      return defenition;
    }
    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        int comma = parametrs.IndexOf(',');
        string left = parametrs.Substring(0, comma);
        string right = parametrs.Substring(comma + 1);
        right = right.Trim();

        int rightValue = 0;
        int result = 0;
        /*Проверка: если правый операнд -- число, то получаем значение,
        если правый операнд -- регистр, то получаем значение из регистра.*/
        int ifRightHasCount = right.IndexOfAny(new char[] { '1','2','3','4','5',
                                               '6','7','8','9','0'});
        if (ifRightHasCount == -1)
        {
          if (right.Length == 3 && right[0] == 'e' && right[2] == 'x')
          {
            for (char c = 'a'; c < 'i'; c++)
            {
              if (right[1] == c)
              {
                rightValue = CurrentStatement.GetRegister(right);
                c = 'i';
              }
            }
          }
        }
        else
        {
          rightValue = int.Parse(right);
        }

        if (left.Length == 3 && left[0] == 'e' && left[2] == 'x')
        {
          for (char c = 'a'; c < 'i'; c++)
          {
            if (left[1] == c)
            {
              /*Находим значение левого операнда (регистра).*/
              result = CurrentStatement.GetRegister(left) - rightValue;
              /*Помещаем результат выполнения операции в регистор.*/
              CurrentStatement.SetRegister(left, result);
              return;
            }
          }
        }
      }
      throw new HomeworkWPF.ParseCommandException(
                CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }

  }

  /*Команда умножения целочисленная*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "mul")]
  public class Mul : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "mul <a>, <b>: " +
                         "<a> = <a> * <b>";
    public string Defenition()
    {
      return defenition;
    }
    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        int comma = parametrs.IndexOf(',');
        string left = parametrs.Substring(0, comma);
        string right = parametrs.Substring(comma + 1);
        right = right.Trim();

        int rightValue = 0;
        int result = 0;

        /*Проверка: если правый операнд -- число, то получаем значение,
        если правый операнд -- регистр, то получаем значение из регистра.*/
        int ifRightHasCount = right.IndexOfAny(new char[] { '1','2','3','4','5',
                                               '6','7','8','9','0'});
        if (ifRightHasCount == -1)
        {
          if (right.Length == 3 && right[0] == 'e' && right[2] == 'x')
          {
            for (char c = 'a'; c < 'i'; c++)
            {
              if (right[1] == c)
              {
                rightValue = CurrentStatement.GetRegister(right);
                c = 'i';
              }
            }
          }
        }
        else
        {
          rightValue = int.Parse(right);
        }

        if (left.Length == 3 && left[0] == 'e' && left[2] == 'x')
        {
          for (char c = 'a'; c < 'i'; c++)
          {
            if (left[1] == c)
            {
              /*Находим значение левого операнда (регистра).*/
              result = CurrentStatement.GetRegister(left) * rightValue;
              /*Помещаем результат выполнения операции в регистор.*/
              CurrentStatement.SetRegister(left, result);
              return;
            }
          }
        }
      }
      throw new HomeworkWPF.ParseCommandException(
          CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }
  }

  /*Команда деления целочисленная*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "div")]
  public class Div : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "div <a>, <b>: " +
                         "<a> = <a> / <b>";
    public string Defenition()
    {
      return defenition;
    }
    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        int comma = parametrs.IndexOf(',');
        string left = parametrs.Substring(0, comma);
        string right = parametrs.Substring(comma + 1);
        right = right.Trim();

        int rightValue = 0;
        int result = 0;

        /*Проверка: если правый операнд -- число, то получаем значение,
        если правый операнд -- регистр, то получаем значение из регистра.*/
        int ifRightHasCount = right.IndexOfAny(new char[] { '1','2','3','4','5',
                                                '6','7','8','9','0'});
        if (ifRightHasCount == -1)
        {
          if (right.Length == 3 && right[0] == 'e' && right[2] == 'x')
          {
            for (char c = 'a'; c < 'i'; c++)
            {
              if (right[1] == c)
              {
                rightValue = CurrentStatement.GetRegister(right);
                c = 'i';
              }
            }
          }
        }
        else
        {
          rightValue = int.Parse(right);
        }

        if (left.Length == 3 && left[0] == 'e' && left[2] == 'x')
        {
          for (char c = 'a'; c < 'i'; c++)
          {
            if (left[1] == c)
            {
              /*Находим значение левого операнда (регистра).*/
              result = CurrentStatement.GetRegister(left) / rightValue;
              /*Помещаем результат выполнения операции в регистор.*/
              CurrentStatement.SetRegister(left, result);
              return;
            }
          }
        }
      }
      throw new HomeworkWPF.ParseCommandException(
                CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }
  }

  /*Команда помещения значения в стек*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "in")]
  public class In : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "in <portX>, <a>: " +
                         "<portX> = <a>";
    public string Defenition()
    {
      return defenition;
    }
    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        int comma = parametrs.IndexOf(',');
        string left = parametrs.Substring(0, comma);
        string right = parametrs.Substring(comma + 1);
        right = right.Trim();

        int rightValue = 0;
        int result = 0;

        /*Проверка: если правый операнд -- число, то получаем значение,
        если правый операнд -- регистр, то получаем значение из регистра.*/
        int ifRightHasCount = right.IndexOfAny(new char[] { '1','2','3','4','5',
                                                '6','7','8','9','0'});
        if (ifRightHasCount == -1)
        {
          if (right.Length == 3 && right[0] == 'e' && right[2] == 'x')
          {
            for (char c = 'a'; c < 'i'; c++)
            {
              if (right[1] == c)
              {
                rightValue = CurrentStatement.GetRegister(right);
                c = 'i';
              }
            }
          }
        }
        else
        {
          rightValue = int.Parse(right);
        }

        if (left.Length == 5 && left.Contains("port"))
        {
          for (char c = 'A'; c < 'E'; c++)
          {
            if (left[4] == c)
            {
              /*Записываем значение в порт (левый операнд).*/
              result = rightValue;
              CurrentStatement.SetPort(left, result);
              return;
            }
          }
        }
      }
      throw new HomeworkWPF.ParseCommandException(
                CurrentStatement.Commands[CurrentStatement.CurrentCommand]);

    }
  }

  /*Команда получения значения из стека*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "out")]
  public class Out : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "out <a>, <portX>: " +
                         "<a> = <portX>";
    public string Defenition()
    {
      return defenition;
    }
    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        int comma = parametrs.IndexOf(',');
        string left = parametrs.Substring(0, comma);
        string right = parametrs.Substring(comma + 1);
        right = right.Trim();

        int rightValue = 0;
        int result = 0;

        /*Проверка: если правый операнд -- порт, то получаем его значение,
        иначе исключение.*/
        int ifRightHasCount = right.IndexOfAny(new char[] { '1','2','3','4','5',
                                                '6','7','8','9','0'});
        if (ifRightHasCount == -1)
        {
          if (right.Length == 5 && right.Contains("port"))
          {
            for (char c = 'A'; c < 'E'; c++)
            {
              if (right[4] == c)
              {
                /*Считываем значение из порта (правый операнд).*/
                rightValue = CurrentStatement.GetPort(right);
                c = 'E';
              }
            }
          }
        }
        else
        {
          throw new HomeworkWPF.ParseCommandException(
                    CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
        }

        if (left.Length == 3 && left[0] == 'e' && left[2] == 'x')
        {
          for (char c = 'a'; c < 'i'; c++)
          {
            if (left[1] == c)
            {
              /*Записываем значение в регистр (левый операнд).*/
              result = rightValue;
              CurrentStatement.SetRegister(left, result);
              return;
            }
          }
        }
      }
      throw new HomeworkWPF.ParseCommandException(
                CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }
  }

  /*Команда установки значения в регистр*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "mov")]
  public class Mov : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "mov <a>, <b>: " +
                         "<a> = <b>";
    public string Defenition()
    {
      return defenition;
    }
    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        int comma = parametrs.IndexOf(',');
        string left = parametrs.Substring(0, comma);
        string right = parametrs.Substring(comma + 1);
        right = right.Trim();

        int rightValue = 0;
        int result = 0;

        /*Проверка: если правый операнд -- число, то получаем значение,
        если правый операнд -- регистр, то получаем значение из регистра.*/
        int ifRightHasCount = right.IndexOfAny(new char[] { '1','2','3','4','5',
                                                '6','7','8','9','0'});
        if (ifRightHasCount == -1)
        {
          if (right.Length == 3 && right[0] == 'e' && right[2] == 'x')
          {
            for (char c = 'a'; c < 'i'; c++)
            {
              if (right[1] == c)
              {
                rightValue = CurrentStatement.GetRegister(right);
                c = 'i';
              }
            }
          }
        }
        else
        {
          rightValue = int.Parse(right);
        }

        if (left.Length == 3 && left[0] == 'e' && left[2] == 'x')
        {
          for (char c = 'a'; c < 'i'; c++)
          {
            if (left[1] == c)
            {
              /*Записываем значение в регистр (левый операнд).*/
              result = rightValue;
              CurrentStatement.SetRegister(left, result);
              return;
            }
          }
        }
      }
      throw new HomeworkWPF.ParseCommandException(CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }
  }

  /*Команда вызова подпрограммы*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "call")]
  public class Call : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "Call <met>: " +
                         "Call a program on <met>";
    public string Defenition()
    {
      return defenition;
    }
    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        string destination = parametrs.Trim();
        int address = 0;

        int count = 0;

        /*Проверка: если операнд -- адрес, то получаем значение,
        если операнд -- метка, то получаем адрес метки.*/
        if (destination[destination.Count() - 1] == 'h')
        {
          address = Int32.Parse(destination, System.Globalization.NumberStyles.HexNumber);
        }
        else
        {
          foreach (HomeworkWPF.CommandItem i in CurrentStatement.Commands)
          {
            if (i.Command.Contains(parametrs + ":") == true)
            {
              address = i.Address;
            }
          }
        }

        /*Помещаем в стек адрес возврата*/
        foreach (HomeworkWPF.CommandItem i in CurrentStatement.Commands)
        {
          if (i.Address == address)
          {
            CurrentStatement.Push(new HomeworkWPF.StackItem
            {
              Data = CurrentStatement.Commands[CurrentStatement.CurrentCommand].Address,
              Address = true
            });
            CurrentStatement.CurrentCommand = count - 1;
            return;
          }
          count++;
        }

      }
      throw new HomeworkWPF.ParseCommandException(CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }
  }

  /*Команда возврата из подпрограммы*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "ret")]
  public class Ret : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "ret: " +
                         "Go back";
    public string Defenition()
    {
      return defenition;
    }
    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs == "")
      {
        int address = 0;

        HomeworkWPF.StackItem item = null;

        int count = 0;

        /*Ищем в стеке адрес возврата.*/
        while (address == 0 && CurrentStatement.MicroStack.Count > 0)
        {
          item = CurrentStatement.Pop();
          if (item.Address == true)
          {
            address = item.Data;
          }
        }

        /*Переходим по адресу. Меняем индекс обрабатываемой команды.*/
        foreach (HomeworkWPF.CommandItem i in CurrentStatement.Commands)
        {
          if (i.Address == address)
          {
            CurrentStatement.CurrentCommand = count;
            return;
          }
          count++;
        }
      }
      throw new HomeworkWPF.ParseCommandException(CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }
  }

  /*Команда цикла*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "loop")]
  public class Loop : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "loop <met>: " +
                         "Return to <met> while ecx > 0";
    public string Defenition()
    {
      return defenition;
    }
    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        CurrentStatement.Ecx = CurrentStatement.Ecx - 1;
        /*Проверка: если ecx > 0, то переходим по метке,
        иначе переходим на следующуюю команду.*/
        if (CurrentStatement.Ecx > 0)
        {
          string destination = parametrs.Trim();
          int address = 0;

          int count = 0;

          /*Проверка: если операнд -- адрес, то получаем значение,
          если операнд -- метка, то получаем адрес метки.*/
          if (destination[destination.Count() - 1] == 'h')
          {
            address = Int32.Parse(destination, System.Globalization.NumberStyles.HexNumber);
          }
          else
          {
            foreach (HomeworkWPF.CommandItem i in CurrentStatement.Commands)
            {
              if (i.Command.Contains(destination + ":") == true)
              {
                address = i.Address;
              }
            }
          }

          /*Переходим по адресу. Меняем индекс текущей команды.*/
          foreach (HomeworkWPF.CommandItem i in CurrentStatement.Commands)
          {
            if (i.Address == address)
            {
              CurrentStatement.CurrentCommand = count - 1;
              return;
            }
            count++;
          }
        }
        else
        {
          return;
        }
      }
      throw new HomeworkWPF.ParseCommandException(CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }
  }

  /*Команда безусловного перехода по метке*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "jmp")]
  public class Jamp : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "Jmp <met>: " +
                         "Go to <met>";
    public string Defenition()
    {
      return defenition;
    }

    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        string destination = parametrs.Trim();
        int address = 0;

        int count = 0;

        /*Проверка: если операнд -- адрес, то получаем значение,
          если операнд -- метка, то получаем адрес метки.*/
        if (destination[destination.Count() - 1] == 'h')
        {
          address = Int32.Parse(destination, System.Globalization.NumberStyles.HexNumber);
        }
        else
        {
          foreach (HomeworkWPF.CommandItem i in CurrentStatement.Commands)
          {
            if (i.Command.Contains(parametrs + ":") == true)
            {
              address = i.Address;
            }
          }
        }

        foreach (HomeworkWPF.CommandItem i in CurrentStatement.Commands)
        {
          if (i.Address == address)
          {
            CurrentStatement.CurrentCommand = count - 1;
            return;
          }
          count++;
        }

      }
      throw new HomeworkWPF.ParseCommandException(CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }
  }

  /*Команда условного перехода (переход, если ZF == 0)*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "jz")]
  public class Jz : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "Jz <met>: " +
                         "Go to <met> if Zero Flag is 0";
    public string Defenition()
    {
      return defenition;
    }

    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        /*Проверка: если ZF == 0, то переходим по метке,
        иначе переходим на следующуюю команду.*/
        if (CurrentStatement.ZF == 0)
        {
          string destination = parametrs.Trim();
          int address = 0;

          int count = 0;

          /*Проверка: если операнд -- адрес, то получаем значение,
          если операнд -- метка, то получаем адрес метки.*/
          if (destination[destination.Count() - 1] == 'h')
          {
            address = Int32.Parse(destination, System.Globalization.NumberStyles.HexNumber);
          }
          else
          {
            foreach (HomeworkWPF.CommandItem i in CurrentStatement.Commands)
            {
              if (i.Command.Contains(parametrs + ":") == true)
              {
                address = i.Address;
                break;
              }
            }
          }

          /*Переходим на команду по адресу.*/
          foreach (HomeworkWPF.CommandItem i in CurrentStatement.Commands)
          {
            if (i.Address == address)
            {
              CurrentStatement.CurrentCommand = count - 1;
              return;
            }
            count++;
          }

        }
        else
        {
          return;
        }
      }
      throw new HomeworkWPF.ParseCommandException(CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }
  }

  /*Команда сравнения. Если a >= b, то ZF=1, иначе ZF=0.*/
  [Export(typeof(HomeworkWPF.ICommand))]
  [ExportMetadata("Operation", "cmp")]
  public class Cmp : HomeworkWPF.ICommand
  {
    /*Описание*/
    private string defenition = "cmp <a>, <b> " +
                         "If <a> >= <b>, ZF = 1.";
    public string Defenition()
    {
      return defenition;
    }

    /*Операция*/
    public void Operate(ref HomeworkWPF.Core CurrentStatement, string parametrs)
    {
      if (parametrs != "")
      {
        int comma = parametrs.IndexOf(',');
        string left = parametrs.Substring(0, comma);
        string right = parametrs.Substring(comma + 1);
        right = right.Trim();

        int leftValue = 0;
        int rightValue = 0;

        /*Проверка: если правый операнд -- число, то получаем значение,
        если правый операнд -- регистр, то получаем значение из регистра.*/
        int ifRightHasCount = right.IndexOfAny(new char[] { '1','2','3','4','5',
                                               '6','7','8','9','0'});

        if (ifRightHasCount == -1)
        {
          if (right.Length == 3 && right[0] == 'e' && right[2] == 'x')
          {
            for (char c = 'a'; c < 'i'; c++)
            {
              if (right[1] == c)
              {
                rightValue = CurrentStatement.GetRegister(right);
                c = 'i';
              }
            }
          }
        }
        else
        {
          rightValue = int.Parse(right);
        }

        /*Проверка: если левый операнд -- число, то получаем значение,
        если левый операнд -- регистр, то получаем значение из регистра.*/
        int ifLeftHasCount = left.IndexOfAny(new char[] { '1','2','3','4','5',
                                               '6','7','8','9','0'});

        if (ifLeftHasCount == -1)
        {
          if (left.Length == 3 && left[0] == 'e' && left[2] == 'x')
          {
            for (char c = 'a'; c < 'i'; c++)
            {
              if (left[1] == c)
              {
                leftValue = CurrentStatement.GetRegister(left);
                c = 'i';
              }
            }
          }
        }
        else
        {
          leftValue = int.Parse(left);
        }
        
        /*Сравнение: если a >= b, то ZF=1, иначе ZF=0.*/
        if (leftValue >= rightValue)
        {
          CurrentStatement.ZF = 1;
        }
        else
        {
          CurrentStatement.ZF = 0;
        }
        return;
      }
      throw new HomeworkWPF.ParseCommandException(CurrentStatement.Commands[CurrentStatement.CurrentCommand]);
    }
  }
} 
