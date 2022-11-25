using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3_122
{

    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }

    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }

        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = LAST.next; current != LAST; previous= current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                {
                    return (true);
                }
            }
            if (rollNo == LAST.rollNumber)
            {
                return true;
            }
            else
            {
                return (false);
            }
        }

        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        public void traverse()
        {
            if (listEmpty())
            {
                Console.WriteLine("\nList empty");
            }
            else
            {
                Console.WriteLine("\nRecords in the list are: \n");
                Node currentNode;
                currentNode = LAST.next;
                while(currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + " " + currentNode.name);
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + " " + LAST.name);
            }
        }

        public void firstNode()
        {
            if (listEmpty())
            {
                Console.WriteLine("\nList empty");
            }
            else
            {
                Console.Write("\n The first record in the list is: \n\n" + LAST.next.rollNumber + " " + LAST.next.name);
            }
        }

        public void addNode()
        {
            int nim;
            String nm;
            Console.Write("\nEnter the roll number of the student : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student: ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = nim;
            newnode.name = nm;
            //untuk pengcekan apakah nim bisa di input ke akhir list
            if (LAST.next == null || nim <= LAST.next.rollNumber)
            {
                if ((LAST.next != null) && (nim == LAST.next.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll number not allowed\n");
                    return;
                }
                newnode.next = LAST.next;
                LAST.next = newnode;
                LAST = newnode;
                return;
            }

            Node previous, current;
            previous = LAST.next;
            current = LAST.next;

            while ((current != null) && (nim >= current.rollNumber))
            {
                if (nim == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll number not allowed\n");
                    return;
                }
                previous = current;
                current = current.next;
            }

            newnode.next = LAST.next;
            LAST.next = newnode;
        }

        public bool delNode(int nim)
        {
            Node previous, current;
            previous = current = null;
            //
            if (Search(nim, ref previous, ref current) == false)
            {
                return false;
            }
            if (current == LAST.next)
            {
                LAST.next = current.next;
            }
            
            
            return true;
        }
    }
class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
