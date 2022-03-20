using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Messages
{
    public class Message<T> : BaseMessage
    {
        public T Data { get; set; }
    }
}
