namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservoirs = GetReservoirs();
            var factoryEquipments = GetFactoryEquipments();
            var factories = GetFactories();

            /// Вывод количества объектов
            Console.WriteLine($"Количество резервуаров: {reservoirs.Length}, оборудования: {factoryEquipments.Length}");

            /// Вывод списка всех резервуаров с информацией об оборудовании и заводах
            Console.WriteLine("Список всех резервуаров:");
            foreach (var reservoir in reservoirs)
            {
                var factoryEquipment = FindFactoryEquipment(factoryEquipments, reservoirs, reservoir.Name);
                var factory = FindFactory(factories, factoryEquipment);
                Console.WriteLine($"Резервуар: {reservoir.Name}, Объем: {reservoir.Volume}/{reservoir.MaxVolume}, Описание: {reservoir.Description}, " + $"Оборудование: {factoryEquipment.Name} ({factoryEquipment.Description}), Завод: {factory.Name} ({factory.Description})");
            }

            /// Вывод общего объема всех резервуаров
            var totalVolume = GetTotalVolume(reservoirs);
            Console.WriteLine($"\nОбщий объем резервуаров: {totalVolume}");

            /// Цикл с командами 
            while (true)
            {
                Console.Write("\nВыберите действие (1: поиск по имени, 2: общий объем, 3: все записи, 0: выход): ");
                if (!int.TryParse(Console.ReadLine(), out int command))
                {
                    Console.WriteLine("Пожалуйста, введите число (0-3).");
                    continue;
                }

                switch (command)
                {
                    case 0:
                        Console.WriteLine("Поиск завершен.");
                        return; // Выход из программы

                    case 1:
                        Console.Write("Введите название резервуара для поиска: ");
                        string searchName = Console.ReadLine();
                        var foundFactoryEquipment = FindFactoryEquipment(factoryEquipments, reservoirs, searchName);
                        if (foundFactoryEquipment != null)
                        {
                            var factory = FindFactory(factories, foundFactoryEquipment);
                            Console.WriteLine($"Резервуар {searchName} принадлежит оборудованию {foundFactoryEquipment.Name} и заводу {factory.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"Резервуар {searchName} не найден");
                        }
                        break;

                    case 2:
                        Console.WriteLine($"Общий объем резервуаров: {GetTotalVolume(reservoirs)}");
                        break;

                    case 3:
                        Console.WriteLine("Список всех резервуаров:");
                        foreach (var reservoir in reservoirs)
                        {
                            var factoryEquipment = FindFactoryEquipment(factoryEquipments, reservoirs, reservoir.Name);
                            var factory = FindFactory(factories, factoryEquipment);
                            Console.WriteLine($"Резервуар: {reservoir.Name}, Объем: {reservoir.Volume}/{reservoir.MaxVolume}, Описание: {reservoir.Description}, " +
                                              $"Оборудование: {factoryEquipment.Name} ({factoryEquipment.Description}), Завод: {factory.Name} ({factory.Description})");
                        }
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Введите число от 0 до 3.");
                        break;
                }
            }
        }

        /// <summary>
        /// Возвращает массив резервуаров с данными из таблицы.
        /// </summary>
        public static Reservoir[] GetReservoirs()
        {
            //ID для резервуаров
            Guid reservoir1Id = Guid.Parse("a1111111-1111-1111-1111-111111111111");
            Guid reservoir2Id = Guid.Parse("a2222222-2222-2222-2222-222222222222");
            Guid reservoir3Id = Guid.Parse("a3333333-3333-3333-3333-333333333333");
            Guid reservoir4Id = Guid.Parse("a4444444-4444-4444-4444-444444444444");
            Guid reservoir5Id = Guid.Parse("a5555555-5555-5555-5555-555555555555");
            Guid reservoir6Id = Guid.Parse("a6666666-6666-6666-6666-666666666666");
            Guid reservoir7Id = Guid.Parse("a7777777-7777-7777-7777-777777777777"); // Новый объект

            //ID для оборудования
            Guid unit1Id = Guid.Parse("b1111111-1111-1111-1111-111111111111");
            Guid unit2Id = Guid.Parse("b2222222-2222-2222-2222-222222222222");
            Guid unit3Id = Guid.Parse("b3333333-3333-3333-3333-333333333333");

            return new Reservoir[]
            {
            new Reservoir(reservoir1Id, "Резервуар 1", "Надземный - вертикальный", 1500, 2000, unit1Id),
            new Reservoir(reservoir2Id, "Резервуар 2", "Надземный - горизонтальный", 2500, 3000, unit1Id),
            new Reservoir(reservoir3Id, "Дополнительный резервуар 24", "Надземный - горизонтальный", 3000, 3000, unit2Id),
            new Reservoir(reservoir4Id, "Резервуар 35", "Надземный - вертикальный", 3000, 3000, unit2Id),
            new Reservoir(reservoir5Id, "Резервуар 47", "Подземный - двустенный", 4000, 5000, unit2Id),
            new Reservoir(reservoir6Id, "Резервуар 256", "Подводный", 500, 500, unit3Id),
            new Reservoir(reservoir7Id, "Резервуар 999", "Надземный - вертикальный", 6000, 5000, unit3Id) // Превышение MaxVolume
            };
        }

        /// <summary>
        /// Возвращает массив оборудования завода с данными из таблицы.
        /// </summary>
        public static FactoryEquipment[] GetFactoryEquipments()
        {
            Guid unit1Id = Guid.Parse("b1111111-1111-1111-1111-111111111111");
            Guid unit2Id = Guid.Parse("b2222222-2222-2222-2222-222222222222");
            Guid unit3Id = Guid.Parse("b3333333-3333-3333-3333-333333333333");

            // Простые Guid для заводов
            Guid factory1Id = Guid.Parse("c1111111-1111-1111-1111-111111111111");
            Guid factory2Id = Guid.Parse("c2222222-2222-2222-2222-222222222222");

            return new FactoryEquipment[]
            {
            new FactoryEquipment(unit1Id, "ГДУ-2", "Газофракционирующая установка", factory1Id),
            new FactoryEquipment(unit2Id, "АБТ-6", "Атмосферно-вакуумная трубчатка", factory1Id),
            new FactoryEquipment(unit3Id, "АБТ-10", "Атмосферно-вакуумная трубчатка", factory2Id)
            };
        }

        /// <summary>
        /// Возвращает массив заводов с данными из таблицы.
        /// </summary>
        public static Factory[] GetFactories()
        {
            Guid factory1Id = Guid.Parse("c1111111-1111-1111-1111-111111111111");
            Guid factory2Id = Guid.Parse("c2222222-2222-2222-2222-222222222222");

            return new Factory[]
            {
            new Factory(factory1Id, "НТЗ№1", "Первый нефтеперерабатывающий завод"),
            new Factory(factory2Id, "НТЗ№2", "Второй нефтеперерабатывающий завод")
            };
        }

        /// <summary>
        /// Находит оборудование завода, связанное с резервуаром по его имени.
        /// </summary>
        /// <param name="factoryEquipments">Массив оборудования</param>
        /// <param name="reservoirs">Массив резервуаров</param>
        /// <param name="reservoirName">Имя искомого резервуара</param>
        /// <returns>Найденное оборудование или null, если резервуар не найден</returns>
        public static FactoryEquipment FindFactoryEquipment(FactoryEquipment[] factoryEquipments, Reservoir[] reservoirs, string reservoirName)
        {
            Reservoir foundReservoir = null;
            foreach (var reservoir in reservoirs)
            {
                if (reservoir.Name == reservoirName)
                {
                    foundReservoir = reservoir;
                    break;
                }
            }

            if (foundReservoir == null)
                return null;

            foreach (var equipment in factoryEquipments)
            {
                if (equipment.Id == foundReservoir.UnitId)
                    return equipment;
            }
            return null; // На случай, если оборудование не найдено
        }

        /// <summary>
        /// Находит завод, связанный с указанным оборудованием.
        /// </summary>
        /// <param name="factories">Массив заводов</param>
        /// <param name="factoryEquipment">Оборудование завода</param>
        /// <returns>Найденный завод или null, если оборудование не указано</returns>
        public static Factory FindFactory(Factory[] factories, FactoryEquipment factoryEquipment)
        {
            if (factoryEquipment == null)
                return null;

            foreach (var factory in factories)
            {
                if (factory.Id == factoryEquipment.FactoryId)
                    return factory;
            }
            return null; // На случай, если завод не найден
        }

        /// <summary>
        /// Вычисляет суммарный объем всех резервуаров.
        /// </summary>
        /// <param name="reservoirs">Массив резервуаров</param>
        /// <returns>Общий объем</returns>
        public static int GetTotalVolume(Reservoir[] reservoirs)
        {
            int total = 0;
            foreach (var reservoir in reservoirs)
            {
                total += reservoir.Volume;
            }
            return total;
        }
    }
}