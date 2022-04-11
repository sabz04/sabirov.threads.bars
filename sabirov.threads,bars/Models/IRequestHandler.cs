using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sabirov.threads_bars.Models
{
    public interface IRequestHandler
    {

        /// <summary>
        /// Обработать запрос.
        /// </summary>
        /// <param name="message">Сообщение.</param>
        /// <param name="arguments">Аргументы запроса.</param>
        /// <returns>Результат выполнения запроса.</returns>
        string HandleRequest(string message, string[] arguments);
    }
}
