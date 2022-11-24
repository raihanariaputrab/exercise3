using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise3
{
    class Node
    {
        /*create Nodes for the circular nexted list*/
        public int studentNumber;
        public string studentName;
        public Node next;
    }
    class CircularList
    {
        Node LAST;
        public CircularList()
        {
            LAST = null;
        }
        
        public void addNode()
        {
            int nim;
            string nama;
            Console.WriteLine("\nMasukkan nomor mahasiswa : ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukkan nama mahasiswa : ");
            nama = Console.ReadLine();
            Node newNode = new Node();
            newNode.studentNumber = nim;
            newNode.studentName = nama;

            if (LAST == null || nim <= LAST.studentNumber)
            {
                if ((LAST != null) && (nim == LAST.studentNumber))
                {
                    Console.WriteLine("\nNomor mahasiswa tidak diijinkan\n");
                    return;
                }
                newNode.next = LAST;
                LAST = newNode;
                return;
            }
            Node previous, current;
            previous = LAST;
            current = LAST;
            while ((current != null) && (nim >= current.studentNumber))
            {
                if (nim == current.studentNumber)
                {
                    Console.WriteLine("\nNomer mahasiswa sama tidak diijinkan\n");
                    return;
                }
                previous = current;
                current = current.next;
            }
            
            newNode.next = current;
            previous.next = newNode;
        }
        public bool deleteNode(int studentNum)
        {
            Node previous, current;
            previous = current = null;
            if (Search(studentNum, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == LAST)
                LAST = LAST.next;
            return true;
        }
        public bool Search(int studentNum, ref Node previous, ref Node current)
        {
            previous = current;
            while ((current != null) && (studentNum != current.studentNumber))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {

        }
    }
}
