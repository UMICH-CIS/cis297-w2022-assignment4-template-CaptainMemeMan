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
        //lists of employees who meet a minimum salary requirement
        public static void FindEmployees()
        {
            const char DELIM = ',';
            const int END = 999;
            const string FILENAME = "Data.ser";
            Patientclass emp = new Patientclass();
            FileStream inFile = new FileStream(FILENAME,
               FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            BinaryFormatter bFormatter = new BinaryFormatter();
            string recordIn;
            int IDforPatient;
            Write("Enter Patient ID to find them or " +
               END + " to quit >> ");
            IDforPatient = Convert.ToInt32(Console.ReadLine());
            
                    while (IDforPatient != END)
                    {
                        WriteLine("\n{0,-5}{1,-12}{2,8}\n",
                           "Num", "Name", "Salary");
                      try
                          {
                             emp = (Patientclass)bFormatter.Deserialize(inFile);
                             inFile.Seek(0, SeekOrigin.Begin);
                    //if (IDforPatient != END)
                    //   {
                    //     emp = (Patientclass)bFormatter.Deserialize(inFile);
                    //     inFile.Seek(0, SeekOrigin.Begin);
                    //   }
                    //else
                    //   {
                    //     throw (new IDNotThereException("ID Not in the System"));
                    //   }
                         }   
                      catch (Exception ex)
                          {
                            Console.WriteLine(ex.Message.ToString()); 
                          }
                        recordIn = reader.ReadLine();
                        while (recordIn != null)
                        {
                            if (emp.ID >= IDforPatient)
                                WriteLine("{0,-5}{1,-12}{2,8}", emp.ID,
                                   emp.Name, emp.Balance.ToString("C"));
                            recordIn = reader.ReadLine();
                        }
                        Write("\nEnter Patient ID to find them or " +
                           END + " to quit >> ");
                        IDforPatient = Convert.ToInt32(Console.ReadLine());
                    }
             
            
            //while (IDforPatient != END)
            //{
            //    WriteLine("\n{0,-5}{1,-12}{2,8}\n",
            //       "Num", "Name", "Salary");
            //    inFile.Seek(0, SeekOrigin.Begin);
            //    recordIn = reader.ReadLine();
            //    while (recordIn != null)
            //    {
            //        fields = recordIn.Split(DELIM);
            //        emp.ID = Convert.ToInt32(fields[0]);
            //        emp.Name = fields[1];
            //        emp.Balance = Convert.ToDouble(fields[2]);
            //        if (emp.ID >= IDforPatient)
            //            WriteLine("{0,-5}{1,-12}{2,8}", emp.ID,
            //               emp.Name, emp.Balance.ToString("C"));
            //        recordIn = reader.ReadLine();
            //    }
            //    Write("\nEnter Patient ID to find them or " +
            //       END + " to quit >> ");
            //    IDforPatient = Convert.ToInt32(Console.ReadLine());
            //}
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

