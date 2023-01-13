using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStack
{
    internal class StackUnderFlowException:Exception
    {
        public StackUnderFlowException() { }
        public StackUnderFlowException(string meassage) : base(meassage) { }
    }
}
