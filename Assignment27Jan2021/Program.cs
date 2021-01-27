using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment27Jan2021
{
    class Program
    {
         
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the DOB in format 04 May 1998");
            string val = Console.ReadLine();

            DateTime dob = Convert.ToDateTime(val);   // 04 May 1998
            DateTime PresentYear = DateTime.Now;
            TimeSpan ts = PresentYear - dob;
            DateTime Age = DateTime.MinValue.AddDays(ts.Days);
            // Console.WriteLine(Age.Year-1);

            FileStream fs = new FileStream(@"CalAge.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, Age.Year-1);

            fs.Seek(0, SeekOrigin.Begin);

            int res = (int)formatter.Deserialize(fs); //unboxing
            Console.WriteLine("Age is: " + res);
            Console.WriteLine();
        }
    }
}
