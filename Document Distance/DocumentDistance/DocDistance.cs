using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DocumentDistance
{
    class DocDistance
    {
        // ***************
        // DON'T CHANGE CLASS OR FUNCTION NAME
        // YOU CAN ADD FUNCTIONS IF YOU NEED TO
        // ***************
        /// <summary>
        /// Write an efficient algorithm to calculate the distance between two documents
        /// </summary>
        /// <param name="doc1FilePath">File path of 1st document</param>
        /// <param name="doc2FilePath">File path of 2nd document</param>
        /// <returns>The angle (in degree) between the 2 documents</returns>
        public static string taketxt(string docPath)
        {
            string f = "";
            f = File.ReadAllText(docPath);
            return f;
        }

        public static double CalculateDistance(string doc1FilePath, string doc2FilePath)
        {
            Regex regex = new Regex("[^A-Za-z0-9]");
            long sumation_Ds = 0, D1 = 0, D2 = 0, makam;
            double Gazrmakam;
            doc1FilePath = doc1FilePath.Replace('\'', '\\');
            doc2FilePath = doc2FilePath.Replace('\'', '\\');
            // TODO comment the following line THEN fill your code here
            IDictionary<string, long> d1 = new Dictionary<string, long>();
            IDictionary<string, long> d2 = new Dictionary<string, long>();

            string f1 = taketxt(doc1FilePath);
            string f2 = taketxt(doc2FilePath);

            f1 = regex.Replace(f1, "#").ToLower();
            f2 = regex.Replace(f2, "#").ToLower();
            f1 = f1 + "#";
            f2 = f2 + "#";
            // Console.WriteLine(f1);
            // Console.WriteLine(f2);
            string x = "";
            for (long i = 0; i < f1.Length; i++)
            {

                if (f1[i] != '#')
                {
                    x += f1[i];
                }
                else
                {
                    if (x == "#"|| x == "")
                        continue;
                    if (d1.ContainsKey(x))
                    {
                        d1[x] += 1;
                    }
                    else if(!d1.ContainsKey(x)&& f1[i].Equals('#'))
                    {
                        d1.Add(x, 1);
                    }
                    x = "";
                }
            }
            x = "";
            for (long j = 0; j < f2.Length; j++)
            {

                if (f2[j] != '#')
                {
                    x += f2[j];
                }
                else
                {
                    if (x == "#" || x == "")
                        continue;
                    if (d2.ContainsKey(x))
                    {
                        d2[x] += 1;
                    }
                    else if (!d2.ContainsKey(x) && f2[j].Equals('#'))
                    {
                        
                        d2.Add(x, 1);
                    }
                    x = "";
                }
            }
            foreach (string it in d1.Keys)
            {
                if (d2.ContainsKey(it))
                {
                    sumation_Ds += d1[it] * d2[it];
                }

            }
            foreach (long s in d1.Values)
            {
                D1 += s*s;
            }
            foreach (long s in d2.Values)
            {
                D2 += s * s;
            }
            makam = D1 * D2;
            Gazrmakam = Math.Sqrt(makam);
            double dis = Math.Acos(sumation_Ds / Gazrmakam);
            dis = (dis * 180) / Math.PI;

            return dis;

        }
    }
}