using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; }

        //DateTime nowDate = DateTime.Today;
        //int age = nowDate.Year - BirthDate.Year;
        //if(BirthDate > nowDate.AddYears(-age)) age--;
       
        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthdate"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public User(string name, Gender gender, DateTime birthdate, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя не может быть пустым.", nameof(name));

            if (gender == null)
                throw new ArgumentNullException("Укажите гендер.", nameof(gender));

            if (birthdate < DateTime.Parse("01.01.1900") || birthdate >= DateTime.Now)
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthdate));

            if (weight <= 0 || weight >= 150)
                throw new ArgumentException("Указан некорректный вес.", nameof(weight));

            if (height <= 0)
                throw new ArgumentException("Указан некорректный рост.", nameof(height));
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthdate;
            Weight = weight;
            Height = height;

        }
        public User()
        {
            
        }
        
        
        

        public override string ToString()
        {
            return $"Имя пользователя : {Name}, Пол : {Gender}, Возраст : {Age} Вес : {Weight}, Рост : {Height}";
        }

    }
}
