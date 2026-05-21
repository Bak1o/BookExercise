using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExercise.CustomDataStructures
{
    internal class DoublyLinkedList<T>
    {
       private class Node
        {
            public T Item;
            
            
            public Node? Next;
            public Node? Previous;
            public Node(T element)
            {
                Item = element;
                

            }
            

        }
        private Node? _head;
        private Node? _tail;
        private int _count;
        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        public void InsertionSort()
        {
            InsertionSort(Comparer<T>.Default);
        }
        private void InsertionSort(IComparer<T> comparer)
        {
            if (_head == null || _head.Next == null)
                return;

            Node? currentNode = _head.Next;

            while (currentNode != null)
            {
                Node? next = currentNode.Next;

                Node? previousNode = currentNode.Previous;

                while (previousNode != null &&
                       comparer.Compare(currentNode.Item, previousNode.Item) < 0)
                {
                    previousNode = previousNode.Previous;
                }

                // Already in correct place
                if (previousNode == currentNode.Previous)
                {
                    currentNode = next;
                    continue;
                }

                Detach(currentNode);

                if (previousNode == null)
                {
                    InsertAtHead(currentNode);
                }
                else
                {
                    InsertAfter(previousNode, currentNode);
                }

                currentNode = next;
            }
        }

        private void Detach(Node node)
        {
            Node? oldPrevious = node.Previous;
            Node? oldNext = node.Next;

            // If node was head
            if (oldPrevious == null)
            {
                _head = oldNext;
            }
            else
            {
                oldPrevious.Next = oldNext;
            }

            // If node was tail
            if (oldNext == null)
            {
                _tail = oldPrevious;
            }
            else
            {
                oldNext.Previous = oldPrevious;
            }

            node.Next = null;
            node.Previous = null;
        }
        private void InsertAtHead(Node node)
        {
            node.Previous = null;
            node.Next = _head;

            if (_head != null)
            {
                _head.Previous = node;
            }
            else
            {
                _tail = node;
            }

            _head = node;
        }
        private void InsertAfter(Node previousNode, Node node)
        {
            Node? newNext = previousNode.Next;

            node.Previous = previousNode;
            node.Next = newNext;

            previousNode.Next = node;

            if (newNext != null)
            {
                newNext.Previous = node;
            }
            else
            {
                _tail = node;
            }
        }




        public void Add(T element)
        {

            Node newNode = new Node(element);

            if (_head == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                newNode.Previous = _tail;
                _tail.Next = newNode;
                _tail = newNode;
            }

            _count++;
        }
        public T RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new ArgumentOutOfRangeException($" Invalid index : {index}");
            int currentIndex = 0;
            Node currentNode = _head;
            while (currentIndex < index)
            {
                currentNode = currentNode.Next;
                currentIndex++;
            }
            RemoveNode(currentNode);
            return currentNode.Item;


        }
        private void RemoveNode(Node node)
        {
            _count--;

            if (node.Previous == null)
            {
                _head = node.Next;
                if (_head != null)
                    _head.Previous = null;
            }
            else
            {
                node.Previous.Next = node.Next;
            }

            if (node.Next == null)
            {
                _tail = node.Previous;
                if (_tail != null)
                    _tail.Next = null;
            }
            else
            {
                node.Next.Previous = node.Previous;
            }                                                                                                                



        }
        public int Remove(T item)
        {
            int index = 0;
            Node currentNode = _head;
            while (currentNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(item,currentNode.Item))
                {
                    break;
                }
                currentNode = currentNode.Next;
                index++;
            }
            if (currentNode != null)
            {
                RemoveNode(currentNode);
                return index;

            }
            return -1;
        }
        public int IndexOf(T item)
        {
            int index = 0;
            Node currentNode = _head;
            while (currentNode != null)
            {
                if (EqualityComparer<T>.Default.Equals(item,currentNode.Item))
                {
                    return index;
                }

                
                currentNode = currentNode.Next;
                index++;
            }
            return -1;
        }
        public bool Contains(T item)
        {
            int index = IndexOf(item);
            return index >= 0;
        }
        public void Sort()
        {
            if (_head == null || _tail == null)
                return;
            Node sorted = null;
            Node current = _head;
            while (current != null)
            {
                Node next = current.Next;
                current.Next = null;
                current.Previous = null;
                sorted = InsertSorted(sorted, current);
                current = next;

            }
            _head = sorted;
            Node temp = _head;
            while(temp.Next != null)
            {
                temp = temp.Next;
            }
            _tail = temp;


        }
        // Fix for CS1061, CS1525, CS1002 in InsertSorted method
        private Node InsertSorted(Node head, Node node)
        {
            // Ensure T implements IComparable<T>
            if (!(node.Item is IComparable<T>))
                throw new InvalidOperationException("Type T must implement IComparable<T> to use Sort.");

            var comparer = Comparer<T>.Default;

            if (head == null || comparer.Compare(node.Item, head.Item) < 0)
            {
                node.Next = head;
                if (head != null)
                    head.Previous = node;
                node.Previous = null;
                return node;
            }

            Node current = head;
            while (current.Next != null && comparer.Compare(node.Item, current.Next.Item) > 0)
            {
                current = current.Next;
            }

            node.Next = current.Next;
            if (current.Next != null)
                current.Next.Previous = node;
            current.Next = node;
            node.Previous = current;

            return head;
        }
        public int Count
        { 
            get 
            { 
                return _count;
            }
        }
        public void Print()
        {
            if (_head == null)
                throw new InvalidOperationException("List is empty");
            
            Node currentNode = _head;
            Console.Write($" {currentNode.Item}");
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                Console.Write($" {currentNode.Item}");

            }
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException($" invalid index{index}");
                
                Node currentNode = _head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.Next;
                }
                return currentNode.Item;
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException($" invalid index{index}");
                Node currentNode = _head;
                for (int i = 0; i < index;i++)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Item = value;

            }

        }
    }
}
