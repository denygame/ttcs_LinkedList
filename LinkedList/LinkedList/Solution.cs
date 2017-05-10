using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Solution
    {
        private ListOfNode list;
        private int sortByWhat; // 1: birthday, 2: numSalary, 3: job
        private int status;  // 0: tang dan, 1: giam dan

        public ListOfNode List
        {
            get { return list; }
            set { list = value; }
        }

        public Solution()
        {
            this.List = new ListOfNode();
        }

        private Node inputDataNode_3()
        {
            string name, job, day, month, year, numSala;
            int d, m, y;
            double num;

            Console.WriteLine("\n </> Cau 3: Nhap nhan vien can chen!\n");
            Console.Write("=> Nhap ho ten: ");
            name = Console.ReadLine();
            Console.Write("=> Nhap chuc vu: ");
            job = Console.ReadLine();
            Console.WriteLine("=> Nhap ngay thang nam sinh");

            label_day:
            Console.Write("\t + Nhap ngay: ");
            day = Console.ReadLine();
            if (FunctionConstant.IsNumber(day))
            {
                d = int.Parse(day);
                if (d > 31)
                {
                    Console.Write("Nhap ngay khong dung!");
                    goto label_day;
                }
            }
            else { Console.Write("Nhap sai, chi nhap so!\t"); goto label_day; }

            label_month:
            Console.Write("\t + Nhap thang: ");
            month = Console.ReadLine();
            if (FunctionConstant.IsNumber(month))
            {
                m = int.Parse(month);
                if (m > 12)
                {
                    Console.Write("Nhap thang khong dung!");
                    goto label_month;
                }
            }
            else { Console.Write("Nhap sai, chi nhap so!\t"); goto label_month; }

            label_year:
            Console.Write("\t + Nhap nam: ");
            year = Console.ReadLine();
            if (FunctionConstant.IsNumber(year)) y = int.Parse(year);
            else { Console.Write("Nhap sai, chi nhap so!\t"); goto label_year; }

            label_num:
            Console.Write("=> Nhap he so luong: ");
            numSala = Console.ReadLine();
            try { num = Convert.ToDouble(numSala); } catch { Console.Write("Nhap sai, chi nhap so!\t"); goto label_num; }

            return new Node(name, job, new DateTime(y, m, d), num);
        }

        private int show_choseSort_2(string str)
        {
            int n;
            Console.WriteLine("Sap xep {0} theo thu tu?", str);
            Console.WriteLine("\t 0: Tang dan");
            Console.WriteLine("\t 1: Giam dan\n");
            label:
            Console.Write("\t => Ban chon: ");
            string test = Console.ReadLine();
            if (FunctionConstant.IsNumber(test))
            {
                n = int.Parse(test);
                switch (n)
                {
                    case 0: return 0;
                    case 1: return 1;
                    default: Console.Write("Chi nhap 0, 1"); goto label;
                }
            }
            else { Console.Write("Nhap sai, chi nhap so!"); goto label; }
        }


        public void showList_0()
        {
            list.showList();
        }

        public void read_1()
        {
            Console.Write("\n </> Cau 1: Doc file text QLNV.txt.\n\n");
            if (!FunctionConstant.readFileText(list))
                FunctionConstant.dataDefalt(list);
            if (list.fileTxtIsEmpty()) FunctionConstant.dataDefalt(list);
            list.showList();
        }

        public void sort_2()
        {
            Console.WriteLine("\n </> Cau 2: Nhap vao tieu chi sap xep:\n\n1.Ngay thang nam sinh.\n2.He so luong.\n3.Chuc vu.");

            label:
            Console.Write("\n=>Tieu chi:");

            string t = Console.ReadLine();
            if (FunctionConstant.IsNumber(t))
            {
                sortByWhat = int.Parse(t);

                switch (sortByWhat)
                {
                    case 1: status = show_choseSort_2("ngay thang nam sinh"); List.sortByBirthDay(status); break;
                    case 2: status = show_choseSort_2("he so luong"); List.sortByNumOfSalary(status); break;
                    case 3: status = show_choseSort_2("chuc vu"); List.sortByJob(status); break;
                    default: Console.WriteLine("Nhap khong dung tieu chi!"); goto label;
                }
            }
            else { Console.WriteLine("Nhap sai, chi nhap so!"); goto label; }
            list.showList(FunctionConstant.titleShowList(sortByWhat, status));
        }

        public void insert_3()
        {
            Node insert_Node = inputDataNode_3();
            list.insertNodeBySort(insert_Node, sortByWhat, status);
            list.showList("THEM NV THEO TIEU CHI: " + FunctionConstant.titleShowList(sortByWhat, status));
        }

        public void delete_4()
        {
            Console.WriteLine("\n </> Cau 4: Nhap tu khoa <Ho ten va Nam sinh> xoa nhan vien");
            Console.Write("=> Tu Khoa: ");
            list.delete_byKeyPress(Console.ReadLine());
        }
        
        public void find_5()
        {
            Console.WriteLine("\n </> Cau 5: Nhap tu khoa <Ho ten, Chuc vu, Nam sinh, He so luong, Ngay thang nam sinh (theo dang dd/MM/yyyy)> tim nhan vien");
            Console.Write("=> Tu Khoa: ");
            list.findStaff(Console.ReadLine());
        }

        public void writeFile_6()
        {
            Console.Write("\n </> Cau 6: Ghi file text.\n\n");
            FunctionConstant.writeFileText(list);
            Console.WriteLine("==> Chuong trinh da luu danh sach nhan vien ra file QLNV.txt (o thu muc bin)");
        }
    }
}
