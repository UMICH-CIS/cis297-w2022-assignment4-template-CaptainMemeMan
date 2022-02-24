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
    /// This class has two functions, the first fuction would write the user inputs into a file. 
    /// The second function would read back the inputs into the console. 
    /// </summary>
    class ReadingAndOutputFile
    {
        public static PatientClass emp = new PatientClass();
        //Writing data to a Sequential Access text file
        public static void SequentialAccessWriteOperation()
        {
            const int END = 999;
            const string DELIM = ",";
            const string FILENAME = "EmployeeData.txt";
            
            FileStream outFile = new FileStream(FILENAME,
               FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);
            bool passed = false;
            Write("Enter Patient ID or " + END +
               " to quit >> ");
            while (!passed)
            {
                try
                {
                    emp.ID = Convert.ToInt32(ReadLine());
                    passed = true;

                }
                catch (Exception ex)
                {
                    WriteLine("Error: " + ex.Message);
                    Write("Enter Patient ID or " + END + " to quit >> ");
                    emp.ID = Convert.ToInt32(ReadLine());
                    passed = true;
                }
            }

            while (emp.ID != END)
            {
                Write("Enter last name >> ");
                emp.Name = ReadLine();
                Write("Enter salary >> ");
                try
                {
                    emp.Salary = Convert.ToDouble(ReadLine());
                }
                catch (Exception ex)
                {
                    WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    WriteLine("Thank you for writing the Patient Info");
                }
                writer.WriteLine(emp.ID + DELIM + emp.Name +
                   DELIM + emp.Salary);
                Write("Enter next employee number or " +
                   END + " to quit >> ");
                emp.ID = Convert.ToInt32(ReadLine());
            }
            writer.Close();
            outFile.Close();
        }
        //Read data from a Sequential Access File
        public static void ReadSequentialAccessOperation()
        {
            const char DELIM = ',';
            const string FILENAME = "EmployeeData.txt";
            PatientClass emp = new PatientClass();
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
                emp.Salary = Convert.ToDouble(fields[2]);
                WriteLine("{0,-5}{1,-12}{2,8}",
                   emp.ID, emp.Name, emp.Salary.ToString("C"));
                recordIn = reader.ReadLine();
            }
            reader.Close();
            inFile.Close();
        }
    }
}
 