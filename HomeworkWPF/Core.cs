using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace HomeworkWPF
{
  [Serializable]
  public class Core: IPorts, IRegisters, IStack, IFlags
  {
    
    public Core()
    {
      Commands = new List<CommandItem>();
      MicroStack = new Stack<StackItem>();
      CurrentCoreEvent = new CoreEvents();

      InitByZero();

      isDebugging = false;
      _currentCommand = 0;
    }

    /*Список комманд и индекс текущей команды*/
    public List<CommandItem> Commands;
    private int _currentCommand;

    /*Стек*/
    public Stack<StackItem> MicroStack;

    /*Строка подсказки*/
    public string Help;

    /*Класс событий*/
    [NonSerialized]
    public CoreEvents CurrentCoreEvent;

    /*Состояние: запущена ли отладка?*/
    public bool isDebugging;

    /*Инициализация нулями регистров, портов, флагов*/
    /*Очистка стека*/
    public void InitByZero()
    {
      Eax = 0;
      Ebx = 0;
      Ecx = 0;
      Edx = 0;

      Eex = 0;
      Efx = 0;
      Egx = 0;
      Ehx = 0;

      PortA = 0;
      PortB = 0;
      PortC = 0;
      PortD = 0;

      ZF = 0;

      MicroStack.Clear();
      CurrentCoreEvent.SayReloadStack();
    }

    /*Загрузка команд из файла.*/
    public void LoadCommandsFile(string filepath)
    {
      string str;
      Int32 TempAddress = 0xAAA0;

      /*Прочитать документ*/
      using (StreamReader swIn = File.OpenText(filepath))
      {
        while ((str = swIn.ReadLine()) != null)
        {

          Commands.Add(new CommandItem { Address = TempAddress, Command = str });
          TempAddress++;
        }
      }
    }

    
    public int CurrentCommand
    {
      get
      {
        return _currentCommand;
      }
      set
      {
        _currentCommand = value;
        CurrentCoreEvent.SayCoreCurCommandChanged();
      }
    }

    /*Помоещение элемента в стек*/
    public void Push(StackItem item)
    {
      if (MicroStack.Count < 1000)
      {
        MicroStack.Push(item);
        CurrentCoreEvent.SayPushStack();
      }
      else
      {
        throw new Exception("Stack overeflow.");
      }
    }

    /*Извлечение элемента из стека*/
    public StackItem Pop()
    {
      if (MicroStack.Count > 0)
      {
        CurrentCoreEvent.SayPopStack();
        return MicroStack.Pop();
      }
      else
      {
        throw new Exception("Stack is less.");
      }
    }

    /*Свойства регистров EAX-EHX*/
    public Int32 Eax
    { 
      get { return _eax; }
      set 
      {
        _eax = value;
        CurrentCoreEvent.SayRegisterChanged("eax");
      }
    }

    public Int32 Ebx 
    {
      get { return _ebx; }
      set
      {
        _ebx = value;
        CurrentCoreEvent.SayRegisterChanged("ebx");
      }
    }
    
    public Int32 Ecx
    {
      get { return _ecx; }
      set
      {
        _ecx = value;
        CurrentCoreEvent.SayRegisterChanged("ecx");
      }
    }
    public Int32 Edx
    {
      get { return _edx; }
      set
      {
        _edx = value;
        CurrentCoreEvent.SayRegisterChanged("edx");
      }
    }

    public Int32 Eex
    {
      get { return _eex; }
      set
      {
        _eex = value;
        CurrentCoreEvent.SayRegisterChanged("eex");
      }
    }
    public Int32 Efx
    {
      get { return _efx; }
      set
      {
        _efx = value;
        CurrentCoreEvent.SayRegisterChanged("efx");
      }
    }
    public Int32 Egx
    {
      get { return _egx; }
      set
      {
        _egx = value;
        CurrentCoreEvent.SayRegisterChanged("egx");
      }
    }
    public Int32 Ehx
    {
      get { return _ehx; }
      set
      {
        _ehx = value;
        CurrentCoreEvent.SayRegisterChanged("ehx");
      }
    }

    /*Свойства портов A-D*/
    public Int32 PortA
    { 
      get { return _portA; }
      set
      {
        _portA = value;
        CurrentCoreEvent.SayPortChanged("portA");
      }
    }
    public Int32 PortB
    {
      get { return _portB; }
      set
      {
        _portB = value;
        CurrentCoreEvent.SayPortChanged("portB");
      }
    }
    public Int32 PortC
    {
      get { return _portC; }
      set
      {
        _portC = value;
        CurrentCoreEvent.SayPortChanged("portC");
      }
    }
    public Int32 PortD
    { 
      get { return _portD; }
      set
      {
        _portD = value;
        CurrentCoreEvent.SayPortChanged("portD");
      }
    }

    /*Свойство флага ZF*/
    public Int32 ZF
    {
      get { return _zf; }
      set
      {
        _zf = value;
        CurrentCoreEvent.SayZeroFlagChanged();
      }
    }

    /*Получение значения регистра по названию*/
    public int GetRegister(string reg)
    {
      switch (reg)
      {
        case "eax": return Eax;
        case "ebx": return Ebx;
        case "ecx": return Ecx;
        case "edx": return Edx;
        case "eex": return Eex;
        case "efx": return Efx;
        case "egx": return Egx;
        case "ehx": return Ehx;
      }
      throw new Exception("Can't find register");
    }

    /*Установка значения регистра по названию*/
    public int SetRegister(string reg, int value)
    {
      switch (reg)
      {
        case "eax": Eax=value;
                    return 0;
        case "ebx": Ebx = value;
                    return 0;
        case "ecx": Ecx = value;
                    return 0;
        case "edx": Edx = value;
                    return 0;
        case "eex": Eex = value;
                    return 0;
        case "efx": Efx = value;
                    return 0;
        case "egx": Egx = value;
                    return 0;
        case "ehx": Ehx = value;
                    return 0;
      }
      throw new Exception("Can't find register.");
    }

    /*Получение значения порта по названию*/
    public int GetPort(string port)
    {
      switch (port)
      {
        case "portA": return PortA;
        case "portB": return PortB;
        case "portC": return PortC;
        case "portD": return PortD;
      }
      throw new Exception("Can't find port.");
    }

    /*Установка значения порта по названию*/
    public int SetPort(string port, int value)
    {
      switch (port)
      {
        case "portA": PortA = value;
          return 0;
        case "portB": PortB = value;
          return 0;
        case "portC": PortC = value;
          return 0;
        case "portD": PortD = value;
          return 0;
      }
      throw new Exception("Can't find port.");
    }

    private Int32 _eax;
    private Int32 _ebx;
    private Int32 _ecx;
    private Int32 _edx;

    private Int32 _eex;
    private Int32 _efx;
    private Int32 _egx;
    private Int32 _ehx;

    private Int32 _portA;
    private Int32 _portB;
    private Int32 _portC;
    private Int32 _portD;

    private Int32 _zf;
  }

  /*Класс событий ядра*/
  public class CoreEvents
  {
    
    public delegate void CoreRegisterChanged(string register);
    public delegate void CorePortChanged(string register);
    public delegate void CoreStackChanged();
    public delegate void CoreFlagChanged();
    public delegate void CoreCurCommandChanged();

    /*Сообщение о том, что значение регистра было изменено.*/
    public event CoreRegisterChanged RegisterChanged;
    public void SayRegisterChanged(string register)
    {
      if (IfEventsLoaded == true)
      {
        RegisterChanged(register);
      }
    }

    /*Сообщение о том, что значение порта было изменено.*/
    public event CorePortChanged PortChanged;
    public void SayPortChanged(string port)
    {
      if (IfEventsLoaded == true)
      {
        PortChanged(port);
      }
    }

    /*Сообщение о том, что в стек был помещен элемент.*/
    public event CoreStackChanged PushStack;
    public void SayPushStack()
    {
      if (IfEventsLoaded == true)
      {
        PushStack();
      }
    }

    /*Сообщение о том, что из стека был извлечен элемент.*/
    public event CoreStackChanged PopStack;
    public void SayPopStack()
    {
      if (IfEventsLoaded == true)
      {
        PopStack();
      }
    }

    /*Сообщение о том, что надо целиком перезагрузить стек*/
    public event CoreStackChanged ReloadStack;
    public void SayReloadStack()
    {
      if (IfEventsLoaded == true)
      {
        ReloadStack();
      }
    }

    /*Сообщение о том, что значение ZF (флаг нуля) было изменено.*/
    public event CoreFlagChanged ZeroFlagChanged;
    public void SayZeroFlagChanged()
    {
      if (IfEventsLoaded == true)
      {
        ZeroFlagChanged();
      }
    }

    /*Сообщение о том, что индекс текущей команды был изменен.*/
    public event CoreCurCommandChanged CurCommandChanged;
    public void SayCoreCurCommandChanged()
    {
      if (IfEventsLoaded == true)
      {
        CurCommandChanged();
      }
    }

    public bool IfEventsLoaded = false;
  }
  
  /*Интерфейс регистров*/
  public interface IRegisters
  {
    Int32 Eax { get; set; }
    Int32 Ebx { get; set; }
    Int32 Ecx { get; set; }
    Int32 Edx { get; set; }

    Int32 Eex { get; set; }
    Int32 Efx { get; set; }
    Int32 Egx { get; set; }
    Int32 Ehx { get; set; }
  }

  /*Интерфейс портов*/
  public interface IPorts
  {
    Int32 PortA { get; set; }
    Int32 PortB { get; set; }
    Int32 PortC { get; set; }
    Int32 PortD { get; set; }
  }

  /*Интерфейс флагов*/
  public interface IFlags
  {
    Int32 ZF { get; set; }
  }

  /*Интерфейс стека*/
  public interface IStack
  {
    void Push(StackItem item);
    StackItem Pop();
  }

  /*Элемент списка команд: адрес и значение*/
  [Serializable]
  public class CommandItem
  {
    public int Address { get; set; }
    public string Command { get; set; }

  }

  /*Элемент стека: флаг адреса и значение*/
  [Serializable]
  public class StackItem
  {
    public int Data { get; set; }
    public bool Address { get; set; }

  }

}

