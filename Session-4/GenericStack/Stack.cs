using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericStack
{
  internal class Stack<T>
  {
    private List<T> _data = (List<T>) null;

    public Stack() => this._data = new List<T>();

    public void PushElement(T item) => this._data.Add(item);

    public void PopElement() => this._data.RemoveAt(this._data.Count<T>() - 1);

    public void DisplayElements()
    {
      StringBuilder stringBuilder = new StringBuilder();
       _data.Reverse();
      foreach (T obj in this._data)
      {
        stringBuilder.Append(obj.ToString());
        stringBuilder.Append(',');
      }
      Console.Write(stringBuilder.ToString());
      Console.WriteLine();
    }
  }
}
