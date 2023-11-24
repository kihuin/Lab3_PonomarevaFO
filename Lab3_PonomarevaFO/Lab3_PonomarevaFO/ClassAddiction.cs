using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_PonomarevaFO
{
    public interface IDataTransfer
    {
       public void Send(string data);
 
    }

    public class ClassAddiction : IDataTransfer
    {
        public IDataTransfer DataTransfer { get; set; }

        public void Send(string data)
        {
            // Имитация передачи данных на email-сервер
            Console.WriteLine($"Отправка данных на email-сервер: {data}");
           
        }
    }
}
