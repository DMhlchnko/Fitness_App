using CBFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace CBFitness.BL.Controller

{
    [Serializable]
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : SaveLoadController
    {
        private const string UserFile_Name = "users.dat";

        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public User CurrentUser;
        
        /// <summary>
        /// Пользователи приложения
        /// </summary>
        public List<User> Users { get; private set; }


        /// <summary>
        /// Создание нового контроллера.
        /// </summary>
        /// <param name="userName">  Имя пользователя. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }

            Users = GetUsersData();
            
            var cuser = Users.FirstOrDefault(user => user.Name == userName);
            if (cuser != null)
            {
                CurrentUser = cuser;
                Console.WriteLine("Привет {0}! ", userName);
            }
            else
            {
                Console.WriteLine("Пользователь не найден, регистрируем нового пользователя.");
                CurrentUser = UserRegistration(userName);

            }


            if(userName == "admin")
            {
               
                var dt = DateTime.Now.AddDays(-20);
                CurrentUser = new User("Admin", new Gender("MAN"), dt, 90.0, 190.0);


            }
        }
        public UserController(string userName,Gender gender,DateTime birthdate,double weight,double height)
        {
          
            CurrentUser = UserRegistration(userName, gender, birthdate, weight, height);
            Users = GetUsersData() ?? new List<User>();
            if (CurrentUser != null)
            {
                
                Users.Add(CurrentUser);
                Save();
            }
               
            
            
        }

        public UserController(User user)
        {
             CurrentUser = user;
             Users = GetUsersData();
             Users.Add(CurrentUser);

            Save();

        }

        /// <summary>
        /// Получить список пользователей.
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(UserFile_Name)?? new List<User>();
            
        }

        /// <summary>
        /// Регистрация пользователя.
        /// </summary>
        /// </summary>
        /// <returns></returns>
        public User UserRegistration(string name)
        {
            
            
            Console.WriteLine("Укажите ваш пол. (ж/м)");
            var gender = new Gender(Console.ReadLine());
            
           
            DateTime birthdate;
            while (true)
            {
                Console.WriteLine("Укажите вашу дату рождения. (dd.mm.yy)");
                if (DateTime.TryParse(Console.ReadLine(), out birthdate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения.");
                }
            }
            Console.WriteLine("Укажите свой вес. (кг)");
            double weight;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out weight) && weight <= 200)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный вес.");
                }
            }

            Console.WriteLine("Укажите свой рост. (см)");
            double height;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out height) && height <= 250)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный рост");
                }
            }
            User user = new User(name, gender, birthdate, weight, height);
            Users.Add(user);
            Save();
            
            return user;

        }
        /// <summary>
        /// Регистрация пользователя.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        /// <returns></returns>
        public User UserRegistration (User user)
        {
            if(user != null)
            {
                Users.Add(user);
                Save();
                return user;
            }
            return null;
        }

        /// <summary>
        /// Регистрация пользователя.
        /// </summary>
        /// </summary>
        /// <returns></returns>
        public User UserRegistration(string name,Gender gender,DateTime birthdate,double weight,double height)
        {
            
            var user = new User(name, gender, birthdate, weight, height);
            Users.Add(user);
            Save();
            
            return user;

        }   

       
        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save<List<User>>(UserFile_Name, Users);
           
        }


        
        
    }
}
