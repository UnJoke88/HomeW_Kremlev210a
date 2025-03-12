using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    /// <summary>
    /// Базовый класс c общими свойствами.
    /// </summary>
    public class Entity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Конструктор для создания сущности с заданными значениями.
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <param name="name">Название сущности</param>
        /// <param name="description">Описание сущности</param>
        public Entity(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
