using System;
using System.Text.RegularExpressions;

namespace ListOFlists
{
    class Program
    {
        static void Main(string[] args)
        {
            string End="ON", zn;
            do
            {
                Console.WriteLine("Введите, пожалуйста, свой список списков: ");
                string line = Console.ReadLine();
                Regex reg = new Regex("^[a-z](,[a-z])*(;[a-z](,[a-z])*)*$");
                if (reg.IsMatch(line))
                {
                    Regex r = new Regex("[;]*[a-z](,[a-z])*[;]*");
                    MatchCollection matches = r.Matches(line);
                    Console.WriteLine("В вашем списке " + matches.Count + " списка");
                    foreach (Match match in matches)
                        Console.WriteLine(Regex.Replace(match.Value,
                            ";",//что меняю
                            ""));//на что меняю
                }
                else
                {
                    Console.WriteLine("К сожалению, но вы ввели список списков не в соответствующем формате");
                    Console.WriteLine("Ошибка может быть в содержании цифр или других символов (кроме букв , комы и точки с запятой) в вашом списке ");
                    Console.WriteLine("Также ошибку может вызвать полное отсутствие символов");
                }
                Console.WriteLine("Понравилось, хотите продолжить?");
                Console.WriteLine("Для завершения программы задайте ей номер  - название (из букв)");
                zn= Console.ReadLine();
                Regex refinal = new Regex(@"^\d+-[a-z]+$");
                if (refinal.IsMatch(zn)) End = "STOP";

            } while (End != "STOP");
            Console.WriteLine("Спасибо, хороший выбор");
        }
    }
}
