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
        

        static void Main(string[] args)
        {

        }
    }
}
