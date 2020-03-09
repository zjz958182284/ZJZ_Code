using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
    class Note<T>
    {
        public Note<T> next;
        public T data;
        public Note(T data)
        {
            this.data = data;
            next = null;
        }
    }
}
