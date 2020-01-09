using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persion_Assistant08.Play_Song
{
    class DoublyLinkList<T>:DoublyLinkedList<T>
    {
        //Properties
        public new int Size { get; private set; }
        private Node Tail { get; set; }

        //Constructor
        public DoublyLinkList()
        {
            Size = 0;
        }

        //Methods
        public new bool IsEmpty()
        {
            return (Size == 0);
        }

        public new T First()
        {
            if (IsEmpty())
            {
                return default;
            }
            return Tail.Next.Element;
        }

        public new T  Last()
        {
            if (IsEmpty())
            {
                return default;
            }
            return Tail.Element;
        }

        public new void AddFirst(T element)
        {
            if (IsEmpty())
            {
                Tail = new Node(element, null,null );
                Tail.Next = Tail;
                Size++;
            }
            else
            {
                Node newest = new Node(element, Tail.Next,Tail.Prev);
                Tail.Next = newest;
                Size++;
            }
        }

        public new void AddLast(T element)
        {
            AddFirst(element);
            Tail = Tail.Next;
        }

        public new T RemoveFirst()
        {
            if (IsEmpty())
            {
                return default;
            }
            Node head = Tail.Next;
            if (head == Tail)
            {
                Tail = null;
            }
            else
            {
                Tail.Next = head.Next;
            }
            Size--;
            return head.Element;
        }

        public void Rotate()
        {
            if (Tail != null)
            {
                Tail = Tail.Next;
            }
        }

        //Node innerClass
        class Node
        {
            public T Element { get; private set; }
            public Node Prev { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node prev, Node next)
            {
                Element = element;
                Prev = prev;
                Next = next;
            }
        }

    }
}
