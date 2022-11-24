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
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\n Record in the list are : \n");
                Node currentNode;
                currentNode = LAST.next;
                for (currentNode = LAST; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.studentNumber + " " + currentNode.studentName + "\n");
                Console.WriteLine();
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is :\n\n" + LAST.next.studentNumber + " " + LAST.next.studentName);
        }

        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all records in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. Display the first record in the list");
                    Console.WriteLine("6. Exit\n");
                    Console.WriteLine("Enter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("Enter the roll number of the student" + "whose record is to be deleted: ");
                                int StudentNum = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.deleteNode(StudentNum) == false)
                                    Console.WriteLine("record not found");
                                else
                                    Console.WriteLine("Record with roll number" + StudentNum + "deleted\n");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.studentNumber);
                                    Console.WriteLine("\nName: " + curr.studentName);
                                }
                            }
                            break;
                        case '5':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }
}
