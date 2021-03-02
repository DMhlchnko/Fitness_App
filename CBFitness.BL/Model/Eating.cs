using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBFitness.BL.Model
{
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get; }

        public Dictionary<Food,double> Foods { get; }

        public User User { get; }

        public Eating() { }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.",nameof(user));
            Moment = DateTime.Now;
            Foods = new Dictionary<Food, double>();
 
        }

        

        public void Eat(Food food, double weight)
        {
            
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }

    }
}
