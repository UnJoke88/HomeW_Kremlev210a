using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    /// <summary>
    /// Установка
    /// </summary>
    public class FactoryEquipment : Entity
    {
        public Guid FactoryId { get; private set; }

        /// <summary>
        /// Конструктор для создания оборудования с заданными значениями.
        /// </summary>
        /// <param name="id">Идентификатор оборудования</param>
        /// <param name="name">Название оборудования</param>
        /// <param name="description">Описание оборудования</param>
        /// <param name="factoryId">Идентификатор завода</param>
        public FactoryEquipment(Guid id, string name, string description, Guid factoryId)
            : base(id, name, description) // Вызов конструктора базового класса
        {
            FactoryId = factoryId;
        }
    }
}
