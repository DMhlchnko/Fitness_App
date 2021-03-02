using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CBFitness.BL.Controller
{
    [Serializable]
    public abstract class SaveLoadController
    {

        protected T Load<T>(string filename)
        {

            var Formatter = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                
                if (fs.Length > 0 && Formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                return default(T);

            }
                
        }
        protected void Save<T>(string filename, object item)
        {
            var Formatter = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Formatter.Serialize(fs, item);
            }
        }
        

    }


    
}
