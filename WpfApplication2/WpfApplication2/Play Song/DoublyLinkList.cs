using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persion_Assistant08.Play_Song
{
    class DoublyLinkedList<T>:IEnumerable<T>,IEnumerator<T>
    {

        //Properties
        public int Size { get; private set; }
        private Node Header { get; set; }
        private Node Trailer { get; set; }

        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        //Constructor
        public DoublyLinkedList()
        {
            Size = 0;
            Header = new Node(default, null, null);
            Trailer = new Node(default, Header, null);
            Header.Next = Trailer;
        }

        //Methods
        public bool IsEmpty()
        {
            return (Size == 0);
        }

        public T First()
        {
            if (IsEmpty())
            {
                return default;
            }
            return Header.Next.Element;
        }

        public T Last()
        {
            if (IsEmpty())
            {
                return default;
            }
            return Trailer.Prev.Element;
        }

        private void AddBetween(T element, Node predecessor, Node successor)
        {
            Node newest = new Node(element, predecessor, successor);
            predecessor.Next = newest;
            successor.Prev = newest;
            Size++;
        }

        private T Remove(Node node)
        {
            Node predecessor = node.Prev;
            Node successor = node.Next;
            predecessor.Next = successor;
            successor.Prev = predecessor;
            Size--;
            return node.Element;
        }

        public void AddFirst(T element)
        {
            AddBetween(element, Header, Header.Next);
        }

        public void AddLast(T element)
        {
            AddBetween(element, Trailer.Prev, Trailer);
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                return default;
            }
            return Remove(Header.Next);
        }

        public T RemoveLast()
        {
            if (IsEmpty())
            {
                return default;
            }
            return Remove(Trailer.Prev);
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
        //public T[] ToArray()
        //{
        //    T[] result = new T[Size];
        //    int i = 0;
        //    Node Temp = new Node(Header.Next.Element, Header, Header.Next.Next);
        //    while (Temp!=Trailer)
        //    {
        //        result[i] = Temp.Element;
        //        i++;
        //        Temp = Temp.Next;
        //    }
        //    return result;
        //}

        public IEnumerator<T> GetEnumerator()
        {
            Node node = Header.Next;
            while (node!=Trailer)
            {
                yield return node.Element  ;
                System.Windows.Forms.MessageBox.Show(node.Element.ToString());
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Node node = Header.Next;
            while (node != Trailer)
            {
                yield return node.Element as Song;
                System.Windows.Forms.MessageBox.Show(node.Element.ToString());
                node = node.Next;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
