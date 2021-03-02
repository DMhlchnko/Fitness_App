using CBFitness.BL.Controller;
using CBFitness.BL.Model;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("CBFitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Introdusing", culture));
            Console.WriteLine(resourceManager.GetString("Login", culture));
            var username = Console.ReadLine();
            UserController user = new UserController(username);
            
            EatingController eating = new EatingController(user.CurrentUser);
            var exercisecontroller = new ExerciseController(user.CurrentUser);

            Console.WriteLine("Клавиши управления :");
            Console.WriteLine("A - ввести продукт.\nE - ввести упражнение.\nQ - выход");
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("\nУкажите кол-во продуктов");
                        int.TryParse(Console.ReadLine(), out int count);
                        eating.AddEating(count);
                        Console.WriteLine("Продукт успешно добавлен");
                        break;
                    case ConsoleKey.E:
                        Console.WriteLine("Введите название упражнения.");
                        var name = Console.ReadLine();
                        var act = exercisecontroller.ActivityRegistration(name);
                        Console.WriteLine("Укажите время начала упражнения");
                        DateTime.TryParse(Console.ReadLine(), out DateTime start);
                        Console.WriteLine("Укажите время окончания упражнения");
                        DateTime.TryParse(Console.ReadLine(), out DateTime finish);
                        exercisecontroller.Add(act, start, finish);
                        Console.WriteLine("Упражнение успешно добавлено.");
                        break;
                    case ConsoleKey.Q:
                        break;
                }

            }




            Console.ReadLine();









        }
    }
}
