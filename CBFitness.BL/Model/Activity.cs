using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBFitness.BL.Model
{
    [Serializable]
    public class Activity
    {

        public string Name {get;}

        public int Calories {get;}

        public Activity(string name)
        {
            if(name!= null && !String.IsNullOrWhiteSpace(name))
                Name = name;
           
            else
                throw new ArgumentNullException("Имя не может быть равно null или пустым.",nameof(name));

            
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
