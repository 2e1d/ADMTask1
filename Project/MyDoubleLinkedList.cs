using System.Text;
using Node;

namespace MyDoubleLinkedList;

public class MyDoubleLinkedList<T> : IMyDoubleLinkedList<T>
{
    private Node<T> main; //главный элемент
    private Node<T> tail; //последующий элемент
    private int count;


    public MyDoubleLinkedList()
    {

    }


    public void Add(T item)
    {
        var newNode = new Node<T>(item);
        if (count == 0)
        {
            main = newNode;
            tail = newNode;
            count++;

            return;
        }
        newNode.previous = tail;
        tail.next = newNode;
        tail = newNode;
        count++; 
    }

    public void AddToStart(T item)
    {
        if (count == 0)
        {
            Add(item);

            return;
        }
        var newNode = new Node<T>(item);
        newNode.next = main;
        main.previous = newNode;
        main = newNode;
        count++;
    }

    public void Remove(int index)
    {
        if (index > count - 1 || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        if (index == 0)
        {
            main = main.next;
            main.previous = null;
            count--;

            return;
        }
        var itemToRemove = Get(index);
        var itemToRemoveParent = itemToRemove.previous;
        var itemToRemoveChildren = itemToRemoveParent.next;
        itemToRemoveParent.next = itemToRemoveChildren;
        if (itemToRemoveChildren != null)
        {
            itemToRemoveChildren.previous = itemToRemoveParent;
        }
        count--;
    }

    public void Update(int index, T data)
    {
        if (index > count - 1 || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        var current = main;
        for (int i = 0; i < count; i++)
        {
            if (i == index)
            {
                current.Data = data;

                return;
            }
            current = current.next;
        }
    }

    public Node<T> Get(int index)
    {
        if (index > count - 1 || index < 0)
        {
            throw new IndexOutOfRangeException();
        }

        var current = main;
        for (int i = 0; i < count; i++)
        {
            if (i == index)
            {

                return current;
            }
            current = current.next;
        }
        throw new NullReferenceException();
    }


    public bool Equals(MyDoubleLinkedList<T>? other)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        
        return HashCode.Combine(count);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var current = main;
        for (int i = 0; i < count; i++)
        {
            sb.Append($"{current.Data} ");
            current = current.next;
        }

        return sb.ToString();
    }

    public Node<T> this[int index]
    {
        get
        { 
            
            return Get(index);
        }
        set
        {
            Update(index, value.Data);
        }
    }
}

interface IMyDoubleLinkedList<T>
{
    public void Add(T item);

    public void AddToStart(T item);

    public void Remove(int index);

    public void Update(int index, T data);

    public Node<T> Get(int index);
}