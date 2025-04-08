using System.Diagnostics;
using System.Text;
using MyList;
using Node;

namespace MyLinkedList;

public class MyLinkedList<T> : IMyLinkedList<T>
{
    private Node<T>[] _items;
    private const int DefaultCapacity = 4;
    private int _actualsize;
    public int Capacity;


    public MyLinkedList()
    {
        Capacity = DefaultCapacity;
        _items = new Node<T> [DefaultCapacity];
    }

    public void Add(T item)
    {
        if (_actualsize >= _items.Length)
        {
            IncreaseListCapacity();
        }
        _items[_actualsize] = new Node<T> (item);
        if (_actualsize > 0)
        {
            _items[_actualsize - 1].next = _items[_actualsize];
        }
        _actualsize++; 
    }

    public void IncreaseListCapacity()
    {
        Capacity = Capacity * 2;
        var tempArray = _items;
        _items = new Node<T>[Capacity];
        for (int i = 0; i < tempArray.Length; i++)
        {
            _items[i] = tempArray[i];
        }
    }

    public void AddToStart(T item)
    {
        throw new NotImplementedException();
    }

    public void Remove(int index)
    {
        throw new NotImplementedException();
    }

    public void Update(int index, Node<T> item)
    {
        if (index > _items.Length - 1 || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        _items[index] = item;
    }

    public Node<T> Get(int index)
    {
        if (index > _items.Length - 1 || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        return _items[index];
    }

    public Node<T> this[int index]
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

    public bool Equals(MyList<T>? other)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        
        return HashCode.Combine(_actualsize, Capacity);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < _items.Length; i++)
        {
            sb.Append($"{_items[i]} ");
        }

        return sb.ToString();
    }
}

interface IMyLinkedList<T>
{
    public void Add(T item);

    public void AddToStart(T item);

    public void Remove(int index);

    public void Update(int index, Node<T> item);

    public Node<T> Get(int index);
}