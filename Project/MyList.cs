namespace MyList;

public class MyList <T>{

    T[] _items;
    private const int DefaultCapacity = 4;
    int _size;
    int _version;
    private T[] s_emptyArray = new T[0];
    public MyList()
    {
        _items = s_emptyArray;
    }

    public MyList(int capacity)
    {
        if (capacity == 0)
            _items = s_emptyArray;
        else
            _items = new T[capacity];
    }

    public MyList (IEnumerable<T> collection){
            if (collection is ICollection<T> c)
            {
                int count = c.Count;
                if (count == 0)
                {
                    _items = s_emptyArray;
                }
                else
                {
                    _items = new T[count];
                    c.CopyTo(_items, 0);
                    _size = count;
                }
            }
            else
            {
                _items = s_emptyArray;
                using (IEnumerator<T> en = collection!.GetEnumerator())
                {
                    while (en.MoveNext())
                    {
                        //Add(en.Current);
                    }
                }
            }
        }

    public T this[int index]
        {
            get
            {
                // Following trick can reduce the range check by one
                if ((uint)index >= (uint)_size)
                {
                    //ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
                }
                return _items[index];
            }

            set
            {
                if ((uint)index >= (uint)_size)
                {
                    //ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
                }
                _items[index] = value;
                _version++;
            }
        }

        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < _size)
                {
                    //ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.value, ExceptionResource.ArgumentOutOfRange_SmallCapacity);
                }

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, newItems, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = s_emptyArray;
                    }
                }
            }
        }
    public void Add(T item)
    {
        _version++;
            T[] array = _items;
            int size = _size;
            if ((uint)size < (uint)array.Length)
            {
                _size = size + 1;
                array[size] = item;
            }
            else
            {
                AddWithResize(item);
            }
    }
    public void AddFirst(T item)
    {
        _version++;
            T[] array = _items;
            int size = _size;
            T[] newItems = new T[array.Length];
            if ((uint)size < (uint)array.Length)
            {
                _size = size + 1;
                for (int i = 1; i < array.Length; i++)
                    newItems[i] = _items[i - 1];
                
                Array.Copy(newItems, array, newItems.Length);
                array[0] = item;
            }
            else
            {
                AddFirstWithResize(item);
            }
    }

    public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

    public bool RemoveFromLast(T item)
        {
            int index = IndexOfLast(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

    public int IndexOf(T item)
            => Array.IndexOf(_items, item, 0, _size);

        public int IndexOfLast(T item)
            => Array.LastIndexOf(_items, item, _items.Length-1, _size);


    public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_size)
            {
                //ThrowHelper.ThrowArgumentOutOfRange_IndexMustBeLessException();
            }
            _size--;
            if (index <= _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            // if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
            // {
            //     _items[_size] = default!;
            // }
            _version++;
        }

    public void AddWithResize(T item){
            int size = _size;
            Grow(size + 1);
            _size = size + 1;
            _items[size] = item;
    }
       public void AddFirstWithResize(T item){
            int size = _size;
            Grow(size + 1);
            T[] newItems = new T[_items.Length];
            _size = size + 1;
            for (int i = 1; i < _items.Length; i++)
                newItems[i] = _items[i - 1];
                
            Array.Copy(newItems, _items, newItems.Length);
            _items[0] = item;
    }
    
    internal void Grow (int capacity)
    {
        int newCapacity = _items.Length == 0 ? DefaultCapacity : 2 * _items.Length;

        // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
        // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
        if ((uint)newCapacity > Array.MaxLength) newCapacity = Array.MaxLength;

        // If the computed capacity is still less than specified, set to the original argument.
        // Capacities exceeding Array.MaxLength will be surfaced as OutOfMemoryException by Array.Resize.
        if (newCapacity < capacity) newCapacity = capacity;

        Capacity = newCapacity;
    }

}
