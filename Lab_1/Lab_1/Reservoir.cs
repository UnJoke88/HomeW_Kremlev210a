using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    /// <summary>
    /// Резервуар
    /// </summary>
    public class Reservoir : Entity
    {
        private int volume; // Приватное поле для хранения текущего объема

        /// <summary>
        /// Текущий объем резервуара
        /// </summary>
        public int Volume
        {
            get => volume;
            set
            {
                if (value > MaxVolume)
                {
                    Console.WriteLine($"Ошибка: Объем ({value}) превышает максимальный объем ({MaxVolume}) для резервуара {Name}. Установлен максимальный объем.");
                    volume = MaxVolume;
                }
                else
                {
                    volume = value;
                }
            }
        }
        public int MaxVolume { get; private set; }
        public Guid UnitId { get; private set; }

        /// <summary>
        /// Конструктор для создания резервуара.
        /// </summary>
        /// <param name="id">Идентификатор резервуара</param>
        /// <param name="name">Название резервуара</param>
        /// <param name="description">Описание резервуара</param>
        /// <param name="volume">Текущий объем резервуара</param>
        /// <param name="maxVolume">Максимальный объем резервуара</param>
        /// <param name="unitId">Идентификатор оборудования завода</param>
        public Reservoir(Guid id, string name, string description, int volume, int maxVolume, Guid unitId)
            : base(id, name, description)
        {
            MaxVolume = maxVolume;
            UnitId = unitId;
            Volume = volume; // Используем сеттер для проверки при инициализации
        }
    }
}
