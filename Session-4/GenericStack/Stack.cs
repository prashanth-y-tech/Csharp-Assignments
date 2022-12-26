// Decompiled with JetBrains decompiler
// Type: GenericStack.Stack`1
// Assembly: GenericStack, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A690CBD-D02B-4FA1-971F-BFDFF830492D
// Assembly location: C:\Users\prashanth yarram\OneDrive\Desktop\Technovert\C#-Training\C#-Assignments\Session-4\GenericStack\bin\Debug\GenericStack.exe

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
