using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace HomeworkWPF
{
  /*Интерфейс транслятора*/
  public interface IAssembler
  {
    
    void PerformSteps();
    void LoadCoreStatement(ref Core Statement);
  }

  /*Интерфейс комманды*/
  public interface ICommand
  {
    string Defenition();
    void Operate(ref Core CurrentStatement, string parametrs);
  }

  /*Интерфейс информации о команде*/
  public interface ICommandData
  {
    String Operation { get; }
  }

  [Export(typeof(IAssembler))]
  class MyTranslator : IAssembler
  {
    [ImportMany]
    IEnumerable<Lazy<ICommand, ICommandData>> operations;

    public Core CurrentStatement;
   
    /*Обработка команды*/
    public void PerformSteps()
    {
        CommandItem tempCommand = CurrentStatement.Commands[CurrentStatement.CurrentCommand];
        
        int space = tempCommand.Command.IndexOf(' ');
        
        /*Поиск метки*/
        int colon = tempCommand.Command.IndexOf(':');
        string command = "";

        string nameCommand = "";
        string parametrs = "";

          /*Разделение строки на метку и команду*/
          if (colon != -1)
          {
            command = tempCommand.Command.Substring(colon+1);
            command = command.Trim();
            space = command.IndexOf(' ');
          }
          else
          {
            command = tempCommand.Command;
            command = command.Trim();
            space = command.IndexOf(' ');
          }

          /*Разделение команды на название команды и праметры*/
          if (space != -1)
          {
            nameCommand = command.Substring(0, space);
            parametrs = command.Substring(space + 1);
          }
          else
          {
            nameCommand = command;
            parametrs = "";
          }

          /*Поиск команды*/
          foreach (Lazy<ICommand, ICommandData> i in operations)
          {
            if (String.Equals(nameCommand, i.Metadata.Operation, StringComparison.OrdinalIgnoreCase))
            {
              /*Выполнение команды*/
              i.Value.Operate(ref CurrentStatement, parametrs);
              break;
            }
          }
    }

    /*Загрузка текущего состояния ядра*/
    public void LoadCoreStatement(ref Core Statement)
    {
      CurrentStatement = Statement;
      _LoadHelp();
    }

    /*Загрузка справочной информации*/
    private void _LoadHelp()
    {
      string faq = "FAQ\nSupported commands:\n";
      string defenition;
      foreach (Lazy<ICommand, ICommandData> i in operations)
      {
        defenition = i.Value.Defenition();
        faq += defenition + "\n";
      }
      faq += "Copyright by Grigory Ponomarenko (IU8-34 BMSTU)\n";
      CurrentStatement.Help = faq;
    }
  }


  public class Program
  {
    CompositionContainer _container;

    [Import(typeof(IAssembler))]
    public IAssembler assembler;

    public Program(string path)
    {
      /*Создание общего каталога, включающего различные каталоги*/
      var catalog = new AggregateCatalog();
      /*Добавление всех найденных частей в одну сборку в класс Program*/
      catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
      catalog.Catalogs.Add(new DirectoryCatalog(path));

      /*Сздание CompositionContainer с помощью каталога*/
      _container = new CompositionContainer(catalog);

      /*Заполнение контейнера "импортными" объектами*/
      try
      {
        this._container.ComposeParts(this);
      }
      catch (CompositionException compositionException)
      {
        Console.WriteLine(compositionException.ToString());
      }
      
    }
  }

}
