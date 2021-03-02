using CBFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CBFitness.BL.Controller
{
    [Serializable]
    public class EatingController : SaveLoadController
    {
        private readonly User User;
        /// <summary>
        /// Адоресс сохранения списка приёмов пищи.
        /// </summary>
        private const string EatingFile_Name = "eatings.dat";
        /// <summary>
        /// Адресс сохранения списка продуктов.
        /// </summary>
        private const string FoodFile_Name = "food.dat";


        
        /// <summary>
        /// Список продуктов.
        /// </summary>
        protected List<Food> FoodList { get; private set; }
        /// <summary>
        /// Приём пищи.
        /// </summary>
        public Eating Eating;
        /// <summary>
        /// Список приёмов пищи.
        /// </summary>
        public Dictionary<int,Eating> EatingList { get; }

        
        ///
        public EatingController(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            FoodList = Load<List<Food>>(FoodFile_Name)??new List<Food>();
            EatingList = new Dictionary<int, Eating>();
            
        }

        /// <summary>
        /// Получить список продуктов.
        /// </summary>
        /// <returns></returns>
        private List<Food> GetFood()
        {
            return Load<List<Food>>(FoodFile_Name);
        }
        /// <summary>
        /// Добавить свой продукт в список продуктов.
        /// </summary>
        public void AddProducts(Food food)
        {
            
            var product = FoodList.FirstOrDefault(f => f.Name.Equals(food.Name));
            if(product != null)
            {
                Console.WriteLine("Уже в списке.");
            }
            else
            {
                if(food != null)
                {
                    Console.WriteLine("Добавляем в список ваш продукт");
                    FoodList.Add(food);
                    Save<Food>(FoodFile_Name,FoodList);
                    
                }
                
            }

        }
        /// <summary>
        /// Добавить приём пищи.
        /// </summary>
        /// <param name="id"> Кол-во продуктов. </param>
        public void AddEating(int count)
        {
            Food[] foods = new Food[count];
            for(int i = 0;i<foods.Length;i++)
            {
                foods[i] = new Food();
                Console.WriteLine("Укажите имя продукта :");
                var name = Console.ReadLine();
                Eating = new Eating(this.User);
                var food = GettingFoodFromTheList(name);
                if(food != null)
                {
                    Console.WriteLine("Укажите вес продукта.");
                    Double.TryParse(Console.ReadLine(), out double weight);
                    FoodList.Add(food);
                    Eating.Eat(food, weight);
                    EatingList.Add(EatingList.Count(), Eating);
                    Save();
                }
                
                
            }
         
        }



        public Food FoodRegistration(string name)
        {

            Console.WriteLine("Укажите кол-во белка на 100г.");
            Double.TryParse(Console.ReadLine(), out double proteins);
            Console.WriteLine("Укажите кол-во жиров на 100г.");
            Double.TryParse(Console.ReadLine(), out double fats);
            Console.WriteLine("Укажите кол-во углеводов на 100г.");
            Double.TryParse(Console.ReadLine(), out double carbo);
            Console.WriteLine("Укажите кол-во каллорий на 100г.");
            Double.TryParse(Console.ReadLine(), out double ccal);
            var product = new Food(name, proteins, fats, carbo, ccal);
            if (product != null)
            {
                FoodList.Add(product);
                Save();
                return product;
            }
            return null;

        }



        /// <summary>
        /// Получение бжу и ккал за приём пищи.
        /// </summary>
        /// <param name="id"> Номер приёма пищи. </param>
        public void GetEatingStats(int id)
        {
            var eating = EatingList[id];
            double proteins = 0;
            double fats = 0;
            double carbohydrates = 0;
            double calories = 0;
            if (eating.Foods.Count() != 0)
            {
                foreach(var food in eating.Foods)
                {
                    proteins += food.Key.Proteins * (food.Value / 100);
                    fats += food.Key.Fats * (food.Value / 100);
                    carbohydrates += food.Key.Carbohydrates * (food.Value / 100);
                    calories += food.Key.Calories * (food.Value / 100);
                    
                }
                Console.WriteLine("За {0} приём пищи вы употребили :",id);
                Console.WriteLine("Белки : {0}, Жиры : {1}, Углеводы : {2}, Ккалории {3}.", proteins, fats, carbohydrates, calories);
            }
        }
        /// <summary>
        /// Получение бжу и ккал за день.
        /// </summary>
        public void FoodStatsPDay()
        {

            double proteins = 0;
            double fats = 0;
            double carbohydrates = 0;
            double calories = 0;


            foreach (KeyValuePair<Food,double> food in Eating.Foods )
            {
                proteins += food.Key.Proteins * (food.Value / 100);
                fats += food.Key.Fats * (food.Value / 100);
                carbohydrates += food.Key.Carbohydrates * (food.Value / 100);
                calories += food.Key.Calories * (food.Value / 100);
            }
            Console.WriteLine("Сегодня вы употребили :");
            Console.WriteLine("Белки : {0}, Жиры : {1}, Углеводы : {2}, Ккалории {3}.",proteins,fats,carbohydrates,calories);
            
        }
       
        /// <summary>
        /// Загрузка приёма пищи.
        /// </summary>
        /// <returns></returns>
        public Eating GetEating()
        {
            //TODO: изменить загрузку и выгрузку прёмов пищи.
            return Load <Eating> (EatingFile_Name)?? new Eating(User);
        }

        public void EatingCalculation()
        {
            double proteins = 0;
            double fats = 0;
            double carbohydrates = 0;
            double calories = 0;
            foreach (var food in this.Eating.Foods)
            {
                proteins += food.Key.Proteins * (food.Value / 100);
                fats += food.Key.Fats * (food.Value / 100);
                carbohydrates += food.Key.Carbohydrates * (food.Value / 100);
                calories += food.Key.Calories * (food.Value / 100);
                Console.WriteLine("Белки : {0}, Жиры : {1}, Углеводы : {2}, Ккалории {3}.", proteins, fats, carbohydrates, calories);
            }
        }
        /// <summary>
        /// Получение продукта из списка продуктов.
        /// </summary>
        /// <param name="name"> Имя продукта. </param>
        /// <returns></returns>
        public Food GettingFoodFromTheList(string name)
        {
            if(name != null)
            {
                var product = FoodList.SingleOrDefault(food => food.Name == name);
                if (product != null)
                {
                    return product;
                }
                else
                {
                    

                    product = FoodRegistration(name);
                    FoodList.Add(product);
                    Save();
                    return product;

                }
            }
            return null;
        }

        /// <summary>
        /// Сохранение списков.
        /// </summary>
        public void Save()
        {
            Save<List<Food>>(FoodFile_Name, FoodList);
            Save<List<Eating>>(EatingFile_Name, EatingList);
        }

    }
}
