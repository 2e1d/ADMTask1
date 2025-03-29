using System.Diagnostics.Contracts;
using System.Net;
using System.Runtime.CompilerServices;

namespace MyList;

public class MyList <T> : IMyList<T>{

    private T[] _items = [];
    private const int DefaultCapacity = 4; //Дефолтный шаг для роста массива
    int _actualsize;
    public int Capacity {get;set;}


    public MyList()
    {
        Capacity = DefaultCapacity;
        _items = new T[Capacity];
    }

    public void Add(T item)
    {
        if (_actualsize < _items.Length)
        {
            _items[_actualsize] = item;
            _actualsize++;
            return;
        }
        IncreaseListCapacity();
        _items[_actualsize] = item;
        _actualsize++;
    }

    public void AddToStart(T item)
    {
        var tempArray = new T[_items.Length];
        if (_actualsize < _items.Length)
        {
            _actualsize++;
            for (int i = 1; i < _items.Length; i++)
            {
                tempArray[i] = _items[i - 1];
            }
            tempArray[0] = item;
            _items = tempArray;
            return;
        }
        IncreaseListCapacity();
        var newItem = item;
        AddToStart(item);
    }
//TODO: Sadly, Doesn't work :(
    public void Remove(T item)
    {
        _actualsize--;
        var tempArray = _items;
        int index = Array.IndexOf(_items, item);
        _items = new T[Capacity - 1];
        for (int i = 0; i < tempArray.Length - 1; i++)
        {
            if (i == index && index <= _actualsize)
            {
                _items[i] = tempArray[index + 1];
                continue;
            }
            _items[i] = tempArray[i];
        }

    }

    public void Update(int index, T item)
    {
        _items[index] = item;
    }

    public T Get(int index)
    {
        if (index > _items.Length - 1)
            throw new IndexOutOfRangeException();
        return _items[index];
    }
    
    public void IncreaseListCapacity()
    {
        Capacity = Capacity * 2;
        var tempArray = _items;
        _items = new T[Capacity];
        for (int i = 0; i < tempArray.Length; i++)
        {
            _items[i] = tempArray[i];
        }
    }

    public T this[int index]
    {
        get
        { 
            return Get(index);
        }
        set
        {
            Update(index, value);
        }
    }

    public override string ToString()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            Console.Write(_items[i] + " ");
        }
        return String.Empty;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as MyList<T>);
    }

    public bool Equals (MyList<T> list)
    {
        return list != null && _items == list._items && _actualsize == list._actualsize;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_actualsize, Capacity);
    }
}

interface IMyList <T>
{
    public void Add(T item);

    public void AddToStart(T item);

    public void Remove(T item);

    public void Update(int index, T item);

    public T Get(int index);


}
