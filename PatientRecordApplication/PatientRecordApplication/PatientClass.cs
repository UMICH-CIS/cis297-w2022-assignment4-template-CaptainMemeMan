using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    /// <summary>
    /// The PatientClass would have the variables ID, Name, and Salary which will be used throughtout the program.
    /// </summary>
    [Serializable] public class PatientClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }

}
