using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBFitness.BL.Model
{
    /// <summary>
    ///  Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        ///  Имя.
        /// </summary>
        /// <param name="name"></param>
        public string Name { get; }

        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name"> Имя пола </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }
            while (true)
            {
                if (name.ToUpper() == "М" || name.ToUpper() == "Ж")
                {
                    Name = name;
                    break;
                }
                else
                {
                    Console.WriteLine("Неверно указан пол, повторите попытку.");
                    name = Console.ReadLine();
                }
            }
            
           
            

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
