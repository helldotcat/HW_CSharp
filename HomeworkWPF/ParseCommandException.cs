using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkWPF
{
  /*Исключение "Невозможно обработать комманду"*/
  [Serializable]
  public class ParseCommandException: ApplicationException
  {
    public ParseCommandException() { }
        public ParseCommandException(string message) : base(message) { }
        public ParseCommandException(CommandItem ErrorCommandItem)
          : base("Cant perform command " + ErrorCommandItem.Command +
            " on adress " + ErrorCommandItem.Address.ToString("X")) { }
        public ParseCommandException(string message, Exception ex) : base(message) { }
        // Конструктор для обработки сериализации типа
        protected ParseCommandException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext contex)
            : base(info, contex) { }
  }
}
