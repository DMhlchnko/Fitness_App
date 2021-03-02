using CBFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBFitness.BL.Model
{
    [Serializable]
    public class Food : SaveLoadController
    {
        /// <summary>
        /// Имя продукта.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Кол-во белка на 100г продукта.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Кол-во жиров на 100г продукта.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Кол-во углеводов на 100г продукта.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Каллорийность на 100г продукта.
        /// </summary>
        public double Calories { get; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; }

       


        private double CaloriesInOneGram { get { return Calories / 100.0; } }
        private double ProteinsInOneGram { get { return Proteins / 100.0; } }
        private double FatsInOneGram { get { return Fats / 100.0; } }
        private double CarbohydratesInOneGram { get { return Carbohydrates / 100.0; } }

        public Food()
        {
            
        }

        public Food(string name) :this (name,0,0,0,0)
        {
            //TODO: сделать проверку
            Name = name;

        }

        public Food(string name,double proteins,double fats,double carbohydrates,double calories)
        {
            //TODO: сделать проверку
            Name = name;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Calories = calories;
            
        }
        /// <summary>
        /// Регистрация продукта.
        /// </summary>
        /// <param name="name"> Имя продукта. </param>
        /// <returns></returns>
        
        public override string ToString()
        {
            return $"Название продукта: {Name}, Белки: {Proteins}, Жиры: {Fats}, Углеводы: {Carbohydrates}, Каллорийность: {Calories}";
        }

    }
}
