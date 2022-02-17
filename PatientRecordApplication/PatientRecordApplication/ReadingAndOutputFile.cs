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
    //Serializable Demonstration
    /// <summary>
    /// writes Person class objects to a file and later reads them 
    /// from the file into the program
    /// </summary>
    class ReadingAndOutputFile
    {
        public static Patientclass emp = new Patientclass();
        public static void SerializableDemonstration()
        {

            const int END = 999;
            const string FILENAME = "EmployeeData.txt";
           // Patientclass emp = new Patientclass();
            FileStream outFile = new FileStream(FILENAME,
               FileMode.Create, FileAccess.Write);
            BinaryFormatter bFormatter = new BinaryFormatter();
            Write("Enter Patient ID or " + END +
               " to quit >> ");
            emp.ID = Convert.ToInt32(ReadLine());
            while (emp.ID != END)
            {
                Write("Enter last name >> ");
                emp.Name = ReadLine();
                Write("Enter Patient Balance >> ");
                emp.Balance = Convert.ToDouble(ReadLine());
                bFormatter.Serialize(outFile, emp);
                Write("Enter Patient ID or " + END +
                   " to quit >> ");
                emp.ID = Convert.ToInt32(ReadLine());
            }
            outFile.Close();
            FileStream inFile = new FileStream(FILENAME,
               FileMode.Open, FileAccess.Read);
            WriteLine("\n{0,-5}{1,-12}{2,8}\n",
               "Num", "Name", "Salary");
            while (inFile.Position < inFile.Length)
            {
                emp = (Patientclass)bFormatter.Deserialize(inFile);
                WriteLine("{0,-5}{1,-12}{2,8}",
                   emp.ID, emp.Name, emp.Balance.ToString("C"));
            }

            inFile.Close();
        }
    }
}
