using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Host 
{
    class Program 
    {
        static void Main( string[] args )
        {
            int hours = 5;
            hours = 10;

            string name = "John";

            // concat
            name = name + " williams";

            // copy
            name = "Hello";

            bool areEqual = name == "Hello";
            bool areNotEqual = name != "Hello";

            // verbatim string - no escape sequences
            string path = @"C:\Temp\test.txt";

            // option 1
            string names = "John" + " william" + " Murphy" + " Charles" + " Henry";

            // option 2
            StringBuilder builder = new StringBuilder();
            builder.Append("John");
            builder.Append(" william");            
            string names2 = builder.ToString();

            // option 3
            string names3 = String.Concat("John", " william", " Murphy", " Charles", " Henry");

            // string formatting
            // John worked 10 hours
            string format1 = name + " worked" + hours.ToString() + " hours";

            string format2 = String.Format("{0} worked for {1} hours", name, hours);
           
        }
    }
}
