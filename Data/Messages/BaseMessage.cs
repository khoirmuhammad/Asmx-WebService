using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Messages
{
    public class BaseMessage
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
    }
}
