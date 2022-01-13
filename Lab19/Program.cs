using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    internal class Program
    {

//1.    Модель компьютера  характеризуется кодом  и названием  марки компьютера, типом  процессора,  частотой работы  процессора,
//объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством
//экземпляров, имеющихся в наличии.Создать список, содержащий 6-10 записей с различным набором значений характеристик.
//Определить:
//- все компьютеры с указанным процессором.Название процессора запросить у пользователя;
//- все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
//- вывести весь список, отсортированный по увеличению стоимости;
//- вывести весь список, сгруппированный по типу процессора;
//- найти самый дорогой и самый бюджетный компьютер;
//- есть ли хотя бы один компьютер в количестве не менее 30 штук?
        static void Main(string[] args)
        {
            List <Comp> comps = new List <Comp>()
            {
                new Comp(){Id=676897, Name="DELL", CPUType="Intel Core i3", CPUfreq=3.6 , RAM=8, Memory=512, VideoMemory=4, Price=49980.00M, Quantity=5},
                new Comp(){Id=6764597, Name="MSI", CPUType="Intel Core i5", CPUfreq=3.6 , RAM=8, Memory=1024, VideoMemory=8, Price=79980.00M, Quantity=10},
                new Comp(){Id=45476897, Name="MSI", CPUType="Intel Core i3", CPUfreq=2.6 , RAM=4, Memory=512, VideoMemory=4, Price=54980.00M, Quantity=45},
                new Comp(){Id=67646497, Name="Sony", CPUType="Intel Core i3", CPUfreq=2.4 , RAM=8, Memory=512, VideoMemory=2, Price=47480.00M, Quantity=2},
                new Comp(){Id=675697, Name="HP", CPUType="Intel Core i7", CPUfreq=3.6 , RAM=16, Memory=2048, VideoMemory=4, Price=109980.00M, Quantity=32},
                new Comp(){Id=234576897, Name="HP", CPUType="Intel Core i5", CPUfreq=3.6 , RAM=8, Memory=512, VideoMemory=4, Price=84000.00M, Quantity=4},
                new Comp(){Id=433424, Name="DELL", CPUType="Intel Core i7", CPUfreq=3.6 , RAM=16, Memory=1024, VideoMemory=8, Price=94590.00M, Quantity=5},
                new Comp(){Id=3437, Name="HP", CPUType="Intel Core i5", CPUfreq=3.2 , RAM=8, Memory=512, VideoMemory=4, Price=88980.00M, Quantity=9},
                new Comp(){Id=876897, Name="HP", CPUType="Intel Core i9", CPUfreq=3.6 , RAM=16, Memory=2048, VideoMemory=8, Price=124490.00M, Quantity=2},
            };
            #region Выборка по процессору
            Console.Write("Введите название процессора: ");
            string CPUreq=Console.ReadLine().ToLower();

            List<Comp> compsCPU = comps
                .Where(c => c.CPUType.ToLower() == CPUreq)
                .ToList();
            if (compsCPU.Count == 0)
            {
                Console.WriteLine("\nКомпьютеров с таким процессором нет");
            }
            else
            {
                Console.WriteLine("\nКомпьютеры с процессором {0}:", CPUreq);
                foreach (Comp comp in compsCPU)
                {
                    Console.WriteLine("{0,10}  {1,10}", comp.Id, comp.Name);
                }
            }
            #endregion
            
            #region Выборка по ОЗУ
            Console.Write("\nВведите минимальный объем оперативной памяти в Гб: ");
            string RAMmin = Console.ReadLine();
            if (int.TryParse(RAMmin, out int result))

            { List<Comp> compsRAM = comps
                 .Where(c => c.RAM >= result)
                 .ToList();
                if (compsRAM.Count == 0)
                {
                    Console.WriteLine("\nКомпьютеров с ОЗУ, не ниже {0}Гб нет", result);
                }
                else
                {
                    Console.WriteLine("\nКомпьютеры с ОЗУ не менее {0}Гб:", result);
                    foreach (Comp comp in compsRAM)
                    {
                        Console.WriteLine("{0,10}   {1,10}", comp.Id, comp.Name);
                    }
                }
            }
            else
            {
                Console.WriteLine("\nНекорректный ввод");
            }
            #endregion

            #region Сортировка по увеличению стоимости

            IEnumerable <Comp> compsRangedByPrice = comps
                .OrderBy(c => c.Price);
           
            Console.WriteLine("\nСортировка по возрастанию стоимости:");
            foreach (Comp comp in compsRangedByPrice)
            {
                Console.WriteLine("{0,10}   {1,10}    {2,10} у.е.", comp.Id, comp.Name, comp.Price);
            }

            #endregion

            #region Группировка по типу процессора

            var compsGroupByCPU = comps
                  .GroupBy(p => p.CPUType);

            Console.WriteLine("\nГруппировка по типу процессора:");

            foreach (var groupItem in compsGroupByCPU)
            {    
            Console.WriteLine();
                foreach (Comp comp in groupItem)
                {
                    Console.WriteLine($"{ comp.CPUType,10}  {comp.Id,10 } { comp.Name,10}" );
                }
                    
             }

            #endregion

            #region Самый дорогой и самый бюджетный компьютер
            Console.WriteLine("\nСамый бюджетный компьютер: ID={0}, {1}, {2} у.е.", compsRangedByPrice.First().Id, compsRangedByPrice.First().Name, compsRangedByPrice.First().Price);
            Console.WriteLine("Самый дорогой компьютер: ID={0}, {1}, {2} у.е.", compsRangedByPrice.Last().Id, compsRangedByPrice.Last().Name, compsRangedByPrice.Last().Price);
            #endregion

            #region Есть ли хотя бы один в количестве не менее 30 штук
            List<Comp> comps30 = comps
                .Where(c => c.Quantity >= 30)
                .ToList();
            if (comps30.Count > 0)
            {
                Console.WriteLine("\nДа, есть компьютеры более 30 штук, вот они:\n");
                foreach (Comp comp in comps30)
                {
                    Console.WriteLine($"ID={comp.Id}, производитель: {comp.Name}");
                }
            }
            else
            {
                Console.WriteLine("Компьютеров более 30 штук нет");
            }
            #endregion

            Console.ReadKey();
        }
    }
    class Comp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPUType { get; set; }
        public double CPUfreq { get; set; }
        public int RAM { get; set; }
        public int Memory { get; set; }
        public int VideoMemory { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
