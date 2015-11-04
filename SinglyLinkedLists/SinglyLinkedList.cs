using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            first = new SinglyLinkedListNode(values[0].ToString());
            int i = 1;
            while (i < values.Length)
            {
                AddLast(values[i].ToString());
                i += 1;
            }                 
        }

        private SinglyLinkedListNode first;

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { return ElementAt(i); }
            set { NodeAt(i).Value = value; }
        }

        public void AddAfter(string existingValue, string value)
        {
            SinglyLinkedListNode node = first;
            while (node.Value != existingValue && node != null)
            {
                node = node.Next;
                if (node == null)
                {
                    throw new ArgumentException();
                }
            }
            if (node.IsLast())
            {
                AddLast(value);
                return;
            }
            SinglyLinkedListNode insertedNode = new SinglyLinkedListNode(value);
            insertedNode.Next = node.Next;
            node.Next = insertedNode;           
        }

        public void AddFirst(string value)
        {
            SinglyLinkedListNode node = first;
            first = new SinglyLinkedListNode(value);
            first.Next = node;         
        }

        public void AddLast(string value)
        {
            if (first == null)
            {
                first = new SinglyLinkedListNode(value);                
            }
            else
            {
                SinglyLinkedListNode node = first;
                while(!node.IsLast())
                {
                    node = node.Next;
                }
                node.Next = new SinglyLinkedListNode(value);
            }
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            if (first == null)
            {
                return 0;
            }
            SinglyLinkedListNode node = first;
            int i = 1;
            while (node.Next != null)
            {
                node = node.Next;
                i += 1;
            }
            return i;
        }

        public string ElementAt(int index)
        {
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index < 0)
            {
                return "bacon";
            }
            else
            {
                SinglyLinkedListNode node = first;
                int i = 0;
                while (i <= index)
                {                    
                    if (i == index)
                    {                        
                        break;
                    }
                    if (node.Next == null)
                    {
                         throw new ArgumentOutOfRangeException();
                    }
                    node = node.Next;
                    i += 1;                    
                }                
                return node.Value;
            }         
        }

        public SinglyLinkedListNode NodeAt(int index)
        {
            if (this.First() == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                SinglyLinkedListNode node = first;
                int i = 0;
                while (i <= index)
                {
                    if (i == index)
                    {
                        break;
                    }
                    if (node.Next == null)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    node = node.Next;
                    i += 1;
                }
                return node;
            }
        }

        public string First()
        {
            if (first == null)
            {
                return null;
            }
            else
            {
                return first.Value;
            }
        }

        public int IndexOf(string value)
        {
            if (this.First() == null)
            {
                return -1;
            }
            else
            {
                SinglyLinkedListNode node = first;
                int i = 0;
                while (i <= Count())
                {
                    if (node.Value.ToString() == value)
                    {
                        break;
                    }
                    if (node.Next == null)
                    {
                        return -1;
                    }
                    node = node.Next;
                    i += 1;
                }
                return i;
            }

        }

        public bool IsSorted()
        {
            if(Count() == 0)
            {
                return true;
            }
            SinglyLinkedListNode left = first;
            SinglyLinkedListNode right = first.Next;
            while (right != null)
            {

                if (left > right)
                {
                    return false;
                }
                left = right;
                right = left.Next;
            }
            return true;
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        public string Last()
        {
            SinglyLinkedListNode node = first;
            if (first == null)
            {
                return null;
            }
            else
            {
                int i = 0;
                while (node.Next != null)
                {
                    if (node.Next == null)
                    {
                        break;
                    }                   
                    node = node.Next;
                    i += 1;
                }
                return node.Value;
            }
        }

        public void Remove(string value)
        {
            SinglyLinkedListNode node = first;
            if (First() == value)
            {
                first = first.Next;
            }
            while (node.Value != value)
            {
                if (node.Next == null)
                {
                    break;
                }
                if (node.Next.ToString() == value)
                {
                    node.Next = node.Next.Next;
                    break;
                }                
                node = node.Next;
            }
        }

        public void Sort()
        {
            if (Count() == 0)
            {
                return;
            }            
            SinglyLinkedListNode left = first;
            SinglyLinkedListNode right = first.Next;
            bool swapOccured = false;
            while (right != null)
            {

                if (left > right)
                {
                    string value = left.Value;
                    left.Value = right.Value;
                    right.Value = value;
                    swapOccured = true;
                }
                left = right;
                right = left.Next;
            }
            if (swapOccured)
            {
                Sort();
            }

        }

        public string[] ToArray()
        {
            string[] arrayString = new string[Count()];
            int i = 0;
            while (i < Count())
            {
                arrayString[i] = ElementAt(i);
                i += 1;
            }
            return arrayString;
        }

        public override string ToString()
        {
            SinglyLinkedListNode node = first;
            if (this.First() == null)
            {
                return "{ }";
            }
            string masterString = "{ ";
            int i = 0;
            while(node.Next != null)
            {                
                masterString = masterString + "\"" + node.Value + "\"" + ", ";
                node = node.Next;
                i += 1;
            }
            return masterString + "\"" + node.Value + "\"" + " }";

        }
    }
}
