using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
        class GenericList<T>
        {
            private Note<T> head;
            private Note<T> tail;
            public GenericList()
            {
                head = tail = null;
            }
            public void ForEach(Action<T> action)
            {
                Note<T> note = head;
                while (note.next != null)
                {
                    action(note.data);
                    note = note.next;
                }

            }

        
                public void Add(T data)
            {
                if (tail == null)
                    head = tail = new Note<T>(data);
                else
                {
                    tail.next = new Note<T>(data);
                    tail = tail.next;
                }
            }
        }
    }

