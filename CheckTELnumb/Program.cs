using System;
using System.Text.RegularExpressions;

namespace CheckTELnumb
{
    class Program
    {
        static void Main(string[] args)
        {
            string End = "ON", zn;
            do
            {
                
                Console.WriteLine("Введите, пожалуйста, свою строку ");
                string line = Console.ReadLine();
                Regex reg = new Regex(@"(\(\+27\)|\d)\d{2}-\d{3}-\d{4}");
                if ( reg.IsMatch(line))
                {
                    MatchCollection matches1 = reg.Matches(line);
                    Console.WriteLine("В телефонной книге было найдено ");
                    Console.WriteLine(matches1.Count + "  Номеров формата ххх-ххх-хххх и (+24)хх-ххх-хххх");
                    foreach (Match match in matches1)
                        Console.WriteLine(match.Value);
                }
                else
                {
                    Console.WriteLine("К сожалению, но в вашей строке не было найдено ни одного совпадения");
                    Console.WriteLine("Попробуйте ещё раз)");
                }
                Console.WriteLine("Понравилось, хотите продолжить?");
                Console.WriteLine("Для завершения программы задайте ей номер  - название (из маленьких букв)");
                zn = Console.ReadLine();
                Regex refinal = new Regex(@"^\d+-[a-z]+$");
                if (refinal.IsMatch(zn)) End = "STOP";

            } while (End != "STOP");
            Console.WriteLine("Спасибо, хороший выбор");
        }
    }
}
