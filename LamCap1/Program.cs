using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Threading.Tasks;

namespace LamCap1
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var alist = new List<Action>();
                for (int i = 0; i < 10; i++)
                {
                    Action<int> act = x => Console.WriteLine(x);
                    alist.Add(GetAction(i, act));
                }

                alist[0].Invoke();
                alist[1].Invoke();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine($"{progname} Error: {ex.Message}");
            }
        }

        private static Action GetAction(int i, Action<int> a)
        {
            Action act = () => a(i);
            return act;
        }
    }
}
