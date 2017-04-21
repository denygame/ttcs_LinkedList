using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("\t\t\t\t==> THUC TAP CO SO! <==");
            Console.WriteLine("\t\t\t Nguyen Thanh Huy _ 1451120025 _ CN14A");
            Console.WriteLine("\t\t\t Nguyen Quy Tung _ 1451120062 _ CN14A");
            Console.WriteLine("------------------------------------------------------------------------------------------");*/
            Solution solution = new Solution();
            solution.read_1();
            solution.sort_2();
            solution.insert_3();
            solution.delete_4();
            solution.find_5();
            solution.writeFile_6();
            Console.ReadKey();
        }
    }
}
