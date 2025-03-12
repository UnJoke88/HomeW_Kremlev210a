using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    /// <summary>
    /// Завод
    /// </summary>
    public class Factory : Entity
    {
        /// <summary>
        /// Конструктор для создания завода с заданными значениями.
        /// </summary>
        /// <param name="id">Идентификатор завода</param>
        /// <param name="name">Название завода</param>
        /// <param name="description">Описание завода</param>
        public Factory(Guid id, string name, string description)
            : base(id, name, description) // Вызов конструктора базового класса
        {
        }
    }
}
