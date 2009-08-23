using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace NutationList
{
    class Program
    {
        static void Main(string[] args)
        {
            const string f = "nutateList.txt";
            const string f2 = "nutateList.out";


            // 2
            // Use using StreamReader for disposing.
            using (StreamReader r = new StreamReader(f))
            {
                using (StreamWriter o = new StreamWriter(f2))
                {
                    // 3
                    // Use while != null pattern for loop
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        char[] separators = new char[] { ',' };

                        string[] parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                        int ai = int.Parse(parts[0]);
                        int bi = int.Parse(parts[1]);
                        int ci = int.Parse(parts[2]);
                        int di = int.Parse(parts[3]);
                        int ei = int.Parse(parts[4]);
                        double Si = double.Parse(parts[5]);
                        double Si1 = double.Parse(parts[6]);
                        double Ci = double.Parse(parts[7]);
                        double Ci1 = double.Parse(parts[8]);

                        o.WriteLine("\t\t\tnew coeff({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}), ",
                            ai, bi, ci, di, ei, Si, 0.1 * Si1, Ci, 0.1 * Ci1);

                    }
                }
            }

        }
    }
}
