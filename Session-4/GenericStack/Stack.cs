using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericStack
{
    public class Stack<T>
    {
        private List<T> _data = null;

        public Stack() => this._data = new List<T>();

        public void Push(T item)
        {
            this._data.Add(item);
        }

        public void Pop()
        {
            if (_data.Count.Equals(0))
            {
                StackUnderFlowException underFlowException = new StackUnderFlowException("There are no elements to Pop");
                throw underFlowException;
            }
            this._data.RemoveAt(this._data.Count<T>() - 1);
        }

        public string GetData()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = _data.Count() - 1; i >= 0; i--)
            {
                stringBuilder.Append(_data[i].ToString());
                stringBuilder.Append(',');
            }
            return stringBuilder.ToString();
        }
    }
}
