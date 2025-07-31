using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListyIterator;

public class ListyIterator<T> :IEnumerable<T>
{
    public ListyIterator(IEnumerable<T> inputs)
    {
        _list = new List<T>(inputs);
        _index = 0;
    }
    private readonly List<T> _list;
    private int _index;
    public T Current => GetCurrentElement();
    public bool Move()
    {
        if (this.HasNext())
        {
            this._index++;
            return true;
        }
        return false;
    }
    public bool HasNext()
    {
        return  _index+1 < _list.Count;
    }
    private T GetCurrentElement()
    {
        if (_index >= this._list.Count)
            throw new InvalidOperationException("Invalid Operation!");

        return this._list[this._index];
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i =0; i< this._list.Count;i++)
            yield return this._list[i];
        // return this._list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
