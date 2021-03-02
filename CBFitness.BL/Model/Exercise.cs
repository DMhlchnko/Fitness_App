using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBFitness.BL.Model
{
    [Serializable]
    public class Exercise
    {
        
        public DateTime Start { get;}

        public DateTime Finish { get;}

        public Activity Activity { get;}
       
        public User User { get;}

        public Exercise(DateTime st,DateTime fin,Activity ac,User us)
        {
            Start = st;
            Finish = fin;
            Activity = ac;
            User = us;
        }
    }

    
}
