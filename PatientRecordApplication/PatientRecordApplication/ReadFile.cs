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
        //repeatedly searches a file to produce 
        //lists of employees who meet a minimum salary requirement
      public  static void FindEmployees()
        {
            const char DELIM = ',';
            const int END = 999;
            const string FILENAME = "Data.ser";
            Patientclass emp = new Patientclass();
            FileStream inFile = new FileStream(FILENAME,
               FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            string recordIn;
            string[] fields;
            double minSalary;
            Write("Enter the Patient ID to find or " +
               END + " to quit >> ");
            minSalary = Convert.ToDouble(Console.ReadLine());
            while (minSalary != END)
            {
                WriteLine("\n{0,-5}{1,-12}{2,8}\n",
                   "Num", "Name", "Salary");
                inFile.Seek(0, SeekOrigin.Begin);
                recordIn = reader.ReadLine();
                while (recordIn != null)
                {
                    fields = recordIn.Split(DELIM);
                    emp.ID = Convert.ToInt32(fields[0]);
                    emp.Name = fields[1];
                    emp.Balance = Convert.ToDouble(fields[2]);
                    if (emp.ID >= minSalary)
                        WriteLine("{0,-5}{1,-12}{2,8}", emp.ID,
                           emp.Name, emp.Balance.ToString("C"));
                    recordIn = reader.ReadLine();
                }
                Write("\nEnter minimum salary to find or " +
                   END + " to quit >> ");
                minSalary = Convert.ToDouble(Console.ReadLine());
            }
            reader.Close();  // Error occurs if
            inFile.Close(); //these two statements are reversed
        }

        public class IDNotThereException : Exception
        {
            public IDNotThereException(string message): base(message)
            {

            }
        }
    }
}

