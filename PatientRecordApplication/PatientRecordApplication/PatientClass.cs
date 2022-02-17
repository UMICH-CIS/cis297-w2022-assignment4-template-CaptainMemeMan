using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecordApplication
{
    [Serializable] public class Patientclass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
