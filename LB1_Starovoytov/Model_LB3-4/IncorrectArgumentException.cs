using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_LB3_4
{
    /// <summary>
    /// Исключение, генерируемое при передаче некорректных аргументов 
    /// в свойства или методы.
    /// </summary>
    public class IncorrectArgumentException : ArgumentException
    {
        //TODO: remove

        /// <summary>
        /// Инициализирует новый экземпляр исключения 
        /// <see cref="IncorrectArgumentException"/>.
        /// </summary>
        public IncorrectArgumentException()
        {
        }

        //TODO: remove

        /// <summary>
        /// Инициализирует новый экземпляр исключения 
        /// <see cref="IncorrectArgumentException"/>
        /// с указанным сообщением об ошибке.
        /// </summary>
        /// <param name="message">
        /// Сообщение, описывающее причину возникновения исключения.
        /// </param>
        public IncorrectArgumentException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр исключения 
        /// <see cref="IncorrectArgumentException"/>
        /// с указанным сообщением об ошибке и именем параметра, 
        /// вызвавшего исключение.
        /// </summary>
        /// <param name="paramName">
        /// Имя параметра, значение которого является некорректным.
        /// </param>
        /// <param name="message">
        /// Сообщение, описывающее причину возникновения исключения.
        /// </param>
        public IncorrectArgumentException(string paramName, string message)
            : base(message, paramName)
        {
        }

        //TODO: remove
        /// <summary>
        /// Инициализирует новый экземпляр исключения 
        /// <see cref="IncorrectArgumentException"/>
        /// с указанным сообщением об ошибке и внутренним исключением,
        /// являющимся причиной текущего исключения.
        /// </summary>
        /// <param name="message">
        /// Сообщение, описывающее причину возникновения исключения.
        /// </param>
        /// <param name="innerException">
        /// Исключение, вызвавшее текущее исключение.
        /// </param>
        public IncorrectArgumentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
