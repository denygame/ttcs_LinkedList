using System;
using System.Collections.Generic;
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
    }
}
