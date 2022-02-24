using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace PatientRecordApplication
{
    /// <summary>
    /// This would be the main cs file that would run the program and have the userdefined exception class. 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ReadingAndOutputFile.SequentialAccessWriteOperation();
            ReadingAndOutputFile.ReadSequentialAccessOperation();
            PatientID.FindPatientID();
            MinSalary.FindMinSalary();
        }
     
    }
    public class IDNotThereException : Exception
    {
        public IDNotThereException(string message) : base(message)
        {

        }
    }
}