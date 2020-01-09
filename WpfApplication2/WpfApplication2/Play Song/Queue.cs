using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persion_Assistant08.Play_Song
{
    class Queue<T>
    {
        DoublyLinkedList<T> DoublyLinkedList = new DoublyLinkedList<T>();
        public int Size()
        {
            return DoublyLinkedList.Size;
        }
        public T Dequeue()
        {
            return DoublyLinkedList.RemoveFirst();

        }

        public void Enqueue(T e)
        {
            DoublyLinkedList.AddLast(e);
        }

        public T First()
        {
            return DoublyLinkedList.First();
        }

        public bool IsEmpty()
        {
            return DoublyLinkedList.IsEmpty();
        }
       
    }
}
