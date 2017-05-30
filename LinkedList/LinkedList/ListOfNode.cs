using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class ListOfNode
    {
        private Node head;
        private Node tail;//k dùng

        public Node Head
        {
            get
            {
                return head;
            }

            set
            {
                head = value;
            }
        }

        //khởi tạo list
        public ListOfNode()
        {
            this.Head = this.tail = null;
        }

        //truyền dữ liệu 2 node
        private void sendDataOfNode(Node from, Node to)
        {
            to.Name = from.Name;
            to.BirthDay = from.BirthDay;
            to.Job = from.Job;
            to.NumOfSalary = from.NumOfSalary;
        }

        public void addHead(Node node)
        {
            Node toAdd = new Node();
            sendDataOfNode(node, toAdd);
            toAdd.next = Head;
            Head = toAdd;
        }

        public void addTail(Node node)
        {
            if (Head == null)
            {
                Head = new Node();
                sendDataOfNode(node, Head);
                Head.next = null;
            }
            else
            {
                Node toAdd = new Node();
                sendDataOfNode(node, toAdd);
                Node current = Head;
                while (current.next != null)
                    current = current.next;
                current.next = toAdd;
            }
        }

        private int countNode()
        {
            Node current = Head;
            int count = 0;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }

        private int posOfNode(Node n)
        {
            int pos = 0;
            Node cur = Head;
            while (cur != null)
            {
                if (cur == n) return pos;
                pos++;
                cur = cur.next;
            }
            return -1;
        }

        //chèn node vào vị trí position
        public void insertNodeInPos(Node node, int position)
        {
            if (position > countNode() || position < 0) return;
            Node newNode = new Node();
            sendDataOfNode(node, newNode);
            newNode.next = null;

            if (position == 0)
            {
                addHead(newNode);
                return;
            }

            Node previous = null;
            Node current = head;
            int i = 0;
            while (current != null && i < position)
            {
                previous = current;
                current = current.next;
                i++;
            }
            newNode.next = previous.next;
            previous.next = newNode;
        }


        //hàm test in ra node vi tri pos
        public void printNodeByPos(int pos)
        {
            if (Head != null)
            {
                int count = 0;
                Node current = head;
                while (current != null)
                {
                    if (count == pos)
                    {
                        string s = current.BirthDay.ToString("dd/MM/yyyy");
                        Console.WriteLine(current.Name + " " + current.Job + " " + s + " " + current.NumOfSalary);
                        break;
                    }
                    count++;
                    current = current.next;
                }

            }
            else { Console.WriteLine("Danh sach rong!"); }
        }


        public bool fileTxtIsEmpty()
        {
            if (Head != null)
            {
                int count = 0;
                Node current = Head;
                while (current != null)
                {
                    count++;
                    current = current.next;
                }
                if (count != 0) return false;
            }
            else
            {
                Console.WriteLine("================================================================");
                Console.WriteLine("\t\t\t>> File rong! <<");
                Console.WriteLine("================================================================");
                return true;
            }
            return false;
        }

        public void showList(string test = null)
        {
            Console.WriteLine("====================== HIEN THI DANH SACH ======================");
            if (test != null) Console.WriteLine("\n" + test + "\n");
            if (this.Head != null)
            {
                Node current = Head;
                while (current != null)
                {
                    string s = current.BirthDay.ToString("dd/MM/yyyy");
                    Console.WriteLine(current.Name + " " + current.Job + " " + s + " " + current.NumOfSalary);
                    current = current.next;
                }
            }
            else { Console.WriteLine("Danh sach rong!"); }
            Console.WriteLine("================================================================");
        }

        /// <summary>
        /// dùng cho delete, show node xóa ra
        /// </summary>
        /// <param name="n">node có dk xóa</param>
        /// <param name="count">ref change số lượn xóa</param>
        private void showOneNodeForDelete(Node n, ref int count)
        {
            string s = n.BirthDay.ToString("dd/MM/yyyy");
            Console.WriteLine(n.Name + " " + n.Job + " " + s + " " + n.NumOfSalary);
            count++;
        }


        private void swap(Node temp1, Node temp2)
        {
            Node temp = new Node();
            sendDataOfNode(temp1, temp);
            sendDataOfNode(temp2, temp1);
            sendDataOfNode(temp, temp2);
        }

        #region - sort (status) _ 0 tăng dần; 1 giảm dần -
        public void sortByBirthDay(int status)
        {
            Node node1 = Head;
            while (node1 != null)
            {
                Node node2 = node1.next;
                while (node2 != null)
                {
                    if (status == 0)
                    {
                        if (DateTime.Compare(node1.BirthDay, node2.BirthDay) > 0)
                            swap(node1, node2);
                    }
                    else
                    {
                        if (DateTime.Compare(node1.BirthDay, node2.BirthDay) < 0)
                            swap(node1, node2);
                    }
                    node2 = node2.next;
                }
                node1 = node1.next;
            }
        }

        public void sortByNumOfSalary(int status)
        {
            Node node1 = Head;
            while (node1 != null)
            {
                Node node2 = node1.next;
                while (node2 != null)
                {
                    if (status == 0)
                    {
                        if (node1.NumOfSalary > node2.NumOfSalary)
                            swap(node1, node2);
                    }
                    else
                    {
                        if (node1.NumOfSalary < node2.NumOfSalary)
                            swap(node1, node2);
                    }
                    node2 = node2.next;
                }
                node1 = node1.next;
            }
        }

        public void sortByJob(int status)
        {
            Node node1 = Head;
            while (node1 != null)
            {
                Node node2 = node1.next;
                while (node2 != null)
                {
                    if (status == 0)
                    {
                        if (node1.Job.ToLower().CompareTo(node2.Job.ToLower()) > 0)
                            swap(node1, node2);
                    }
                    else
                    {
                        if (node1.Job.ToLower().CompareTo(node2.Job.ToLower()) < 0)
                            swap(node1, node2);
                    }
                    node2 = node2.next;
                }
                node1 = node1.next;
            }
        }
        #endregion

        /// <summary>
        /// chèn một nhân viên vào danh sách theo đúng thứ tự với tiêu chí của câu 2
        /// </summary>
        /// <param name="node"></param>
        /// <param name="sortByWhat">1: birth, 2: numSalary, 3: job</param>
        /// <param name="status">0: tang dan, 1: giam dan</param>
        public void insertNodeBySort(Node node, int sortByWhat, int status)
        {
            int pos, runPos = 0;
            switch (sortByWhat)
            {
                case 1:
                    Node testNode = Head;
                    while (testNode != null)
                    {
                        if (status == 0)
                        {
                            if (DateTime.Compare(node.BirthDay, testNode.BirthDay) < 0) break;
                        }
                        else
                        {
                            if (DateTime.Compare(node.BirthDay, testNode.BirthDay) > 0) break;
                        }
                        runPos++;
                        testNode = testNode.next;
                    }
                    pos = runPos;
                    break;

                case 2:
                    Node testNode1 = Head;
                    while (testNode1 != null)
                    {
                        if (status == 0)
                        {
                            if (node.NumOfSalary < testNode1.NumOfSalary) break;
                        }
                        else
                        {
                            if (node.NumOfSalary > testNode1.NumOfSalary) break;
                        }
                        runPos++;
                        testNode1 = testNode1.next;
                    }
                    pos = runPos;
                    break;

                case 3:
                    Node testNode2 = Head;
                    while (testNode2 != null)
                    {
                        if (status == 0)
                        {
                            if (node.Job.ToLower().CompareTo(testNode2.Job.ToLower()) < 0) break;
                        }
                        else
                        {
                            if (node.Job.ToLower().CompareTo(testNode2.Job.ToLower()) > 0) break;
                        }
                        runPos++;
                        testNode2 = testNode2.next;
                    }
                    pos = runPos;
                    break;
                default: return;
            }
            insertNodeInPos(node, pos);
        }






        /// <summary>
        /// làm theo ví dụ, xóa năm hoặc họ tên
        /// </summary>
        /// <param name="key"></param>
        public void delete_byKeyPress(string key)
        {
            if (countNode() != 0)
            {
                Node runNode = Head;
                int count = 0;

                if (FunctionConstant.IsNumber(key))
                {
                    int y = int.Parse(key);
                    while (runNode.next != null)
                    {
                        if (head.BirthDay.Year == y)
                        {
                            showOneNodeForDelete(head, ref count);
                            head = head.next;
                        }

                        if (runNode.next.BirthDay.Year == y)
                        {
                            if (posOfNode(runNode) != -1) showOneNodeForDelete(runNode.next, ref count);
                            runNode.next = runNode.next.next; // xóa node
                        }
                        else runNode = runNode.next;
                    }
                }
                else
                {
                    while (runNode.next != null)
                    {
                        if (head.Name.Contains(key))
                        {
                            showOneNodeForDelete(head, ref count);
                            head = head.next;
                        }

                        if (runNode.next.Name.Contains(key))
                        {
                            if (posOfNode(runNode) != -1) showOneNodeForDelete(runNode.next, ref count);
                            runNode.next = runNode.next.next; // xóa node
                        }
                        else runNode = runNode.next;
                    }
                }


                if (count == 0)
                    Console.WriteLine("\nKhong co tu khoa nay");
                else
                {
                    Console.WriteLine("\nCo {0} nhan vien bi xoa", count);
                    showList("CAC NHAN VIEN CON LAI");
                }
            }
            else
            {
                Console.WriteLine("\n\n==> Danh sach rong!!!");
            }
        }


        #region - câu 5 - tìm kiếm - 

        private static int timesShowResult = 0; //biến xem có show kết quả search k

        private void showOneNode(Node node, int pos)
        {
            string s = node.BirthDay.ToString("dd/MM/yyyy");
            Console.WriteLine("Vi tri thu " + (pos + 1).ToString() + ": " + node.Name + " " + node.Job + " " + s + " " + node.NumOfSalary);
        }

        private void showErrorFindStaff()
        {
            Console.WriteLine("\n>> Khong co nhan vien co tu khoa nay!");
        }

        private void showTitleResult(string id, string key)
        {
            Console.WriteLine("\n==> Nhan vien co {0} thoa tu khoa <{1}>: \n", id, key);
        }

        public void findStaff(string key)
        {
            if (FunctionConstant.IsNumber(key))
            {
                int number = Convert.ToInt32(key);
                if (checkFindNumSalary(number)) findByNumSalary(number);
                if (checkFindYearOfBD(number)) findByBirthDay(key, number);
            }
            if (key.Contains("/") /*|| key.Contains("-")*/) findByBirthDay(key);
            else
            {
                string keyLower = key.ToLower();
                if (checkFindName(keyLower)) findByName(keyLower);
                if (checkFindJob(keyLower)) findByJob(keyLower);
            }

            if (timesShowResult == 0) showErrorFindStaff();
        }

        private void findByNumSalary(int num)
        {
            int countStaffNumSala = 0;
            showTitleResult("HE SO LUONG", num.ToString());
            Node current = head;
            while (current != null)
            {
                if (current.NumOfSalary == num)
                {
                    showOneNode(current, countStaffNumSala);
                    timesShowResult++;
                }
                countStaffNumSala++;
                current = current.next;
            }
        }

        private void findByBirthDay(string key, int num = 0)
        {
            if (num != 0) //thì tìm theo năm sinh
            {
                Node temp = head;
                int countStaffYearOfDate = 0;
                showTitleResult("NAM SINH", num.ToString());
                while (temp != null)
                {
                    if (num == temp.BirthDay.Year)
                    {
                        timesShowResult++;
                        showOneNode(temp, countStaffYearOfDate);
                    }
                    countStaffYearOfDate++;
                    temp = temp.next;
                }
                return;
            }
            string[] keySplit = key.Split(new char[] { '/', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            if (keySplit.Length == 3)
            {
                for (int i = 0; i < 3; i++)
                    if (FunctionConstant.IsNumber(keySplit[i])) count++;
                if (count == 3)
                {
                    int day = int.Parse(keySplit[0]);
                    int month = int.Parse(keySplit[1]);
                    int year = int.Parse(keySplit[2]);
                    Node temp = head;

                    DateTime date = new DateTime(year, month, day);
                    if (checkFindBirthDay(date))
                    {
                        int countStaffDate = 0;
                        showTitleResult("NGAY THANG NAM SINH", key);
                        while (temp != null)
                        {
                            if (DateTime.Compare(temp.BirthDay, date) == 0)
                            {
                                timesShowResult++;
                                showOneNode(temp, countStaffDate);
                            }
                            countStaffDate++;
                            temp = temp.next;
                        }
                    }
                }
            }
        }

        private void findByName(string key)
        {
            int countStaffName = 0;
            showTitleResult("HO TEN", key);
            Node current = head;
            while (current != null)
            {
                string name = current.Name.ToLower();
                if (name.Contains(key))
                {
                    timesShowResult++;
                    showOneNode(current, countStaffName);
                }
                countStaffName++;
                current = current.next;
            }
        }

        private void findByJob(string key)
        {
            int countStaffJob = 0;
            showTitleResult("CHUC VU", key);
            Node current = head;
            while (current != null)
            {
                string name = current.Job.ToLower();
                if (name.Contains(key))
                {
                    timesShowResult++;
                    showOneNode(current, countStaffJob);
                }
                countStaffJob++;
                current = current.next;
            }
        }


        #region - các hàm check xem có staff nào giống từ khóa k -
        private bool checkFindBirthDay(DateTime date)
        {
            Node current = head;
            while (current != null)
            {
                if (DateTime.Compare(current.BirthDay, date) == 0) return true;
                current = current.next;
            }
            return false;
        }

        private bool checkFindName(string key)
        {
            Node current = head;
            while (current != null)
            {
                string name = current.Name.ToLower();
                if (name.Contains(key)) return true;
                current = current.next;
            }
            return false;
        }

        private bool checkFindJob(string key)
        {
            Node current = head;
            while (current != null)
            {
                string job = current.Job.ToLower();
                if (job.Contains(key)) return true;
                current = current.next;
            }
            return false;
        }

        private bool checkFindNumSalary(int num)
        {
            Node current = head;
            while (current != null)
            {
                if (num == current.NumOfSalary) return true;
                current = current.next;
            }
            return false;
        }

        private bool checkFindYearOfBD(int num)
        {
            Node current = head;
            while (current != null)
            {
                if (num == current.BirthDay.Year) return true;
                current = current.next;
            }
            return false;
        }

        #endregion

        #endregion


    }
}

