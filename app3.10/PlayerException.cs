using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app3._10
{
    /// <summary>
    /// Пользовательское исключение для описания ошибок в действиях пользователей
    /// </summary>
    [Serializable]
    class PlayerException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PlayerException() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Пользовательское сообщение об ошибке</param>
        public PlayerException(string message) : base(message) { }
    }
}
