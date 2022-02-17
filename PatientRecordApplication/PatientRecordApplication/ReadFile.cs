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
    class ReadFile
    {
       // public static string[] fields; 
        public static void ReadSequentialAccessOperation()
        {
            const char DELIM = ',';
            const string FILENAME = "EmployeeData.txt";
            Patientclass emp = new Patientclass();
            FileStream inFile = new FileStream(FILENAME,
               FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            string recordIn;
            string[] fields;
            WriteLine("\n{0,-5}{1,-12}{2,8}\n",
               "Num", "Name", "Salary");
            recordIn = reader.ReadLine();
            while (recordIn != null)
            {
                fields = recordIn.Split(DELIM);
                emp.ID = Convert.ToInt32(fields[0]);
                emp.Name = fields[1];
                emp.Balance = Convert.ToDouble(fields[2]);
                WriteLine("{0,-5}{1,-12}{2,8}",
                   emp.ID, emp.Name, emp.Balance.ToString("C"));
                recordIn = reader.ReadLine();
            }
            reader.Close();
            inFile.Close();
        }
    }
}
