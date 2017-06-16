using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class FunctionConstant
    {
        public static bool IsNumber(string pValue)
        {
            if (pValue == "") return false;
            foreach (Char c in pValue)
                if (!Char.IsDigit(c))
                    return false;
            return true;
        }

        public static string titleShowList(int sortByWhat, int status)
        {
            string name = "=> Theo: ";
            switch (sortByWhat)
            {
                case 1: name += "NGAY THANG NAM SINH "; break;
                case 2: name += "HE SO LUONG "; break;
                case 3: name += "CHUC VU "; break;
            }
            switch (status)
            {
                case 0: name += "TANG DAN"; break;
                case 1: name += "GIAM DAN"; break;
            }
            return name;
        }

        public static void dataDefault(ListOfNode list)
        {
            Console.WriteLine("\n\nHIEN THI BO DU LIEU CO SAN:");
            Node n = new Node("Nguyen Van Anh", "Giam Doc", new DateTime(1982, 04, 21), 3);
            Node n1 = new Node("Nguyen Thi Lan", "Thu Ky", new DateTime(1997, 04, 4), 1.75);
            Node n2 = new Node("Tran Hoan Kiem", "Quan Ly Du An", new DateTime(1985, 01, 24), 2.2);
            Node n3 = new Node("Dinh Tien Dung", "IT", new DateTime(1996, 02, 22), 7);
            Node n4 = new Node("Luc Bang Nhan", "Tester", new DateTime(1996, 12, 14), 2);
            Node n5 = new Node("Ly Nguyen", "Bao Ve", new DateTime(1990, 07, 7), 1.5);
            Node n6 = new Node("Nguyen Van Quan", "Bao Ve", new DateTime(1990, 07, 25), 1.3);
            list.insertNodeInPos(n, 0);
            list.insertNodeInPos(n1, 1);
            list.insertNodeInPos(n2, 2);
            list.insertNodeInPos(n3, 3);
            list.insertNodeInPos(n4, 4);
            list.insertNodeInPos(n5, 5);
            list.insertNodeInPos(n6, 6);
        }

        public static bool readFileText(ListOfNode list)
        {
            try
            {
                Node test;
                using (StreamReader sr = new StreamReader("QLNV.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] str = line.Split(new char[] { '\t' }, StringSplitOptions.None);
                        string name = str[0];
                        string job = str[1];
                        DateTime birth = DateTime.Parse(str[2]);
                        double numSala = double.Parse(str[3]);
                        test = new Node(name, job, birth, numSala);
                        list.addTail(test);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Khong the doc du lieu tu file da cho: ");
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public static void writeFileText(ListOfNode list)
        {
            Node temp = list.Head;
            string fileName = string.Format(@"{0}", "QLNV.txt");
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                while (temp != null)
                {
                    string s = temp.Name + "\t" + temp.Job + "\t" + temp.BirthDay.ToString("MM/dd/yyyy") + "\t" + temp.NumOfSalary;
                    sw.WriteLine(s);
                    temp = temp.next;
                }
                sw.Flush();
            }
        }
    }
}
