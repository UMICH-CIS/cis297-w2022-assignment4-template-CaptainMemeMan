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
    class MinSalary
    {
        /// <summary>
        /// This class reads the file and outputs the userdefined minimum Patient Salary into the console. 
        /// </summary>
        public static void FindMinSalary()
        {
            const char DELIM = ',';
            const int END = 999;
            const string FILENAME = "EmployeeData.txt";
            PatientClass emp = new PatientClass();
            FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            string recordIn;
            string[] fields;
            double minSalary;
            Write("Enter minimum salary to find or " +
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
                    emp.Salary = Convert.ToDouble(fields[2]);
                    if (emp.Salary >= minSalary)
                        WriteLine("{0,-5}{1,-12}{2,8}", emp.ID,
                           emp.Name, emp.Salary.ToString("C"));
                    else
                    {
                        try
                        {
                            if (emp.Salary >= minSalary)
                            {
                                Write("\nEnter minimum salary to find or " +
                                END + " to quit >> ");
                                minSalary = Convert.ToInt32(Console.ReadLine());
                            }
                            else 
                            {
                                throw (new IDNotThereException("Salry are not found in the system"));
                            }
                        }
                        catch (IDNotThereException ex)
                        {
                            Console.WriteLine(ex.Message.ToString());
                        }
                    }
                    recordIn = reader.ReadLine();
                }


                Write("\nEnter minimum salary to find or " +
                   END + " to quit >> ");
                minSalary = Convert.ToDouble(Console.ReadLine());
            }
            reader.Close();  // Error occurs if
            inFile.Close(); //these two statements are reversed
        }
    }
}

