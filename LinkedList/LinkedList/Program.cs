using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        /*Nguyễn Thanh Huy - CN14A - 1451120025
          Nguyễn Quý Tùng - CN14A - 1451120064*/

        static void Main(string[] args)
        {
            Solution solution = new Solution();
            bool sort = false;
            label:
            Console.WriteLine("\n\n********************* MENU *********************");
            Console.WriteLine("\t 0: Hien Thi Danh Sach");
            Console.WriteLine("\t 1: Doc File");
            Console.WriteLine("\t 2: Sap Xep");
            Console.WriteLine("\t 3: Chen Nhan Vien Theo Sap Xep");
            Console.WriteLine("\t 4: Xoa Nhan Vien Lien Quan Tu Khoa");
            Console.WriteLine("\t 5: Tim Kiem Nhan Vien");
            Console.WriteLine("\t 6: Ghi File");
            Console.WriteLine("\t 7: Xoa Man Hinh");
            Console.WriteLine("\t 8: Dung Chuong Trinh");
            Console.WriteLine("************************************************\n\n");
            Console.Write("\t====> Chon Chuc Nang: ");
            string chucNang = Console.ReadLine();
            if (FunctionConstant.IsNumber(chucNang))
            {
                int s = int.Parse(chucNang);
                switch (s)
                {
                    case 0: solution.showList_0(); goto label;
                    case 1: solution.read_1(); goto label;
                    case 2: solution.sort_2(); sort = true; goto label;
                    case 3: if (sort) solution.insert_3(); else Console.WriteLine("\n\n\t<> Chua sap xep!!!"); goto label;
                    case 4: solution.delete_4(); goto label;
                    case 5: solution.find_5(); goto label;
                    case 6: solution.writeFile_6(); goto label;
                    case 7: System.Console.Clear(); goto label;
                    case 8: Console.ReadKey(); break;
                    default: Console.WriteLine("Khong co chuc nang nay!!!"); goto label;
                }
            }
            else
            {
                Console.WriteLine("Khong co chuc nang nay!!!"); goto label;
            }
        }
    }
}
