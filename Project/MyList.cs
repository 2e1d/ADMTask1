using System.Diagnostics.Contracts;
using System.Net;

namespace MyList;

public class MyList <T> : IMyList<T>{

    private T[] _items = [];
    private const int DefaultCapacity = 4; //Дефолтный шаг для роста массива
    int _actualsize;
    int Capacity {get;set;}


    public MyList()
    {
        _items = new T[DefaultCapacity];
    }

    public void Add(T item)
    {
        if (_actualsize < _items.Length)
        {
            _items[_actualsize] = item;
            _actualsize++;
            return;
        }
        var tempArray = _items;
        Grow();
        for (int i = 0; i < tempArray.Length; i++)
        {
            _items[i] = tempArray[i];
        }
        _items[_actualsize] = item;
        _actualsize++;
    }

    public void AddToStart(T item)
    {
        throw new NotImplementedException();
    }

    public void Remove()
    {
        throw new NotImplementedException();
    }

    public void Update(int index)
    {
        throw new NotImplementedException();
    }

    public T Get(int index)
    {
        return _items[index];
    }
    // TODO: Capacity stays at 8. Obviously an error.
    public void Grow()
    {
        Capacity = DefaultCapacity * 2;
        _items = new T[Capacity];
    }

    public override string ToString()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            Console.Write(_items[i] + " ");
        }
        return String.Empty;
    }
}

interface IMyList <T>
{
    public void Add(T item);

    public void AddToStart(T item);

    public void Remove();

    public void Update(int index);

    public T Get(int index);

}
