using System.Text;

namespace MyList;

public class MyList <T> : IMyList<T>{

    private T[] _items = [];
    private const int DefaultCapacity = 4;
    int _actualsize;
    public int Capacity {get;set;}


    public MyList()
    {
        Capacity = DefaultCapacity;
        _items = new T[Capacity];
    }

    public void Add(T item)
    {
        if (_actualsize >= _items.Length)
        {
            IncreaseListCapacity();
        }

        _items[_actualsize] = item;
        _actualsize++;
    }

    public void AddToStart(T item)
    {
        if (_items.Length > _actualsize)
        {
            for (int i = 0; i < _actualsize; i++)
            {
                _items[i + 1] = _items[i];
            }
            _actualsize++;

            return;
        }

        IncreaseListCapacity();
        AddToStart(item);
    }
    public void Remove(int index)
    {
        _actualsize--;
        if (index > _items.Length)
        {
            throw new IndexOutOfRangeException();
        }
        if (index == _actualsize)
        {
            _items[index] = default;
            return;
        }
        for (int i = index; i <= _actualsize; i++)
        {
            _items[i] = _items[i + 1];
        }
    }

    public void Update(int index, T item)
    {
        if (index > _items.Length - 1)
        {
            throw new IndexOutOfRangeException();
        }

        _items[index] = item;
    }

    public T Get(int index)
    {
        if (index > _items.Length - 1)
        {
            throw new IndexOutOfRangeException();
        }

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
        var stringBuilder = new StringBuilder();
        for (int i = 0; i < _items.Length; i++)
        {
            stringBuilder.Append($"{_items[i]} ");
        }

        return stringBuilder.ToString();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj);
    }

    public bool Equals (MyList<T> list)
    {
        if (list == null && _actualsize == list._actualsize)
        {
            return false;
        }
        for (int i = 0; i < _items.Length; i++)
        {
            if (!Equals(_items[i], list[i]))
            {
                return false;
            } 
        }
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_actualsize, Capacity);
    }
}

interface IMyList <T> : IEquatable<MyList<T>>
{
    public void Add(T item);

    public void AddToStart(T item);

    public void Remove(int index);

    public void Update(int index, T item);

    public T Get(int index);


}
