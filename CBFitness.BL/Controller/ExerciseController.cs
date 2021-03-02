using CBFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;


namespace CBFitness.BL.Controller
{
    public class ExerciseController :SaveLoadController
    {
        private readonly string Ex_Filename = "exercises.dat";
        private readonly string Ac_Filename = "activities.dat";

        private readonly User User;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User us)
        {
            User = us ?? throw new ArgumentNullException(nameof(us));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity,DateTime begin,DateTime end)
        {

            var ac = Activities.FirstOrDefault(a => a.Name == activity.Name);
            if(activity != null)
            {
                var ex = new Exercise(begin, end, ac, User);
                Exercises.Add(ex);
            }
            else
            {
                Activities.Add(activity);
                var ex = new Exercise(begin, end, activity,User);
                Exercises.Add(ex);
            }
            Save();
        }

        public List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(Ac_Filename) ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(Ex_Filename) ?? new List<Exercise>();
        }

        public Activity ActivityRegistration(string name)
        {
            return new Activity(name);
        }

        private void Save()
        {
            Save<List<Exercise>>(Ex_Filename, Exercises);
            Save<List<Activity>>(Ac_Filename, Activities);
        }
    }
}
