using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node
    {
        private string name, job;
        private DateTime birthDay;
        private double numOfSalary;//hệ số lương
        public Node next;

        //khoi tao cho head va tail
        public Node(){ }

        public Node(string name, string job, DateTime birthDay, double numOfSalary)
        {
            this.Name = name;
            this.Job = job;
            this.BirthDay = birthDay;
            this.NumOfSalary = numOfSalary;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Job
        {
            get { return job; }
            set { job = value; }
        }

        public DateTime BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }

        public double NumOfSalary
        {
            get { return numOfSalary; }
            set { numOfSalary = value; }
        }
    }
}
