using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace lab_1.utils
{
    #nullable enable
    public class LinkedList<T> : List<T>
    {
        private int size = 0;
        private Node<T>? head = null;
        private Node<T>? tail = null;


        public void AddFirst(T t)
        {
            Node<T> newNode = new Node<T>(t, head);
            head = newNode;
            if(size == 0)
                tail = newNode;
            size++;
            
        }

        public void AddLast(T t)
        {
            Node<T> newNode = new Node<T>(t);
            if (head == null)
                head = newNode;
            else
                tail.Next = newNode;
            
            tail = newNode;
            size++;
        }

        public void Add(T t)
        {
            AddLast(t);
        }

        public void Add(int position, T t)
        {
            if(position > size || position < 0)
                throw new IndexOutOfRangeException("Size: " + size + ", Position: " + position);

            Node<T> newNode = new Node<T>(t);

            if(position == 0)
            {
                AddFirst(t);
            }
            else if(position == size)
            {
                AddLast(t);
            }
            else
            {
                Node<T> pointer = head;
                for (int i = 0; i < position-1; i++)
                {
                    pointer = pointer.Next;
                }

                newNode.Next = pointer.Next;
                pointer.Next = newNode;
                size++;
            }
        }

        public bool Remove(T t)
        {
            Node<T> current = head;
            Node<T> previous = null;
            bool result = false;
            while (current != null)
            {
                if (current.Value.Equals(t))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }

                    size--;
                    result = true;
                }

                previous = current;
                current = current.Next;
            }

            return result;
        }

        public void Remove(int position)
        {
            if(position >= size || position < 0)
                throw new IndexOutOfRangeException("Size: " + size + ", Position: " + position);
            if(position == 0)
            {
                head = head.Next;
                size--;
                return;
            }

            Node<T> pointer = head;
            
            for (int i = 0; i < position-1; i++)
            { 
                pointer = pointer.Next;
            }

            size--;
            if (size == position)
            {
                pointer.Next = null;
                tail = pointer;
            }
            else
            {
                pointer.Next = pointer.Next.Next;
            }


        }

        public bool Contains(T obj)
        {
            foreach (T t in this)
            {
                if (t.Equals(obj))
                    return true;
            }

            return false;
        }

        public T Get(int position)
        {
            if(position >= size || position < 0)
                throw new IndexOutOfRangeException("Size: " + size + ", Position: " + position);
            if (position == (size - 1))
                return tail.Value;
            int i = 0;
            foreach (T value in this)
            {
                if (i == position)
                    return value;
                i++;
            }
            throw new IndexOutOfRangeException("Size: " + size + ", Position: " + position);
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Clean()
        {
            size = 0;
            head = null;
            tail = null;
        }

        public void Reverse()
        {
            if(size == 0)
                return;
            
            Node<T> pointer = head;
            Node<T> newTail = head;
            
            while (head != tail)
            {
                pointer = head;
                head = head.Next;
                pointer.Next = tail.Next;
                tail.Next = pointer;
            }

            head = tail;
            tail = newTail;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("LinkedList(size=").Append(size)
                .Append(")[");
            sb.Append(string.Join(", ", this));
            sb.Append(']');
            return sb.ToString();
        }

        private class Node<T>
        {
            internal Node<T>? Next { get; set; } = null;
            internal T Value { get; set; }

            internal Node(T t)
            {
                Value = t;
            }

            internal Node(T t, Node<T> next) : this(t)
            {
                Next = next;
            }

        }

        
    }
}