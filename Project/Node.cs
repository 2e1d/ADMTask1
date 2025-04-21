namespace Node;

public class Node<T>
{
    public Node<T> next;

    public Node<T> previous;

    public T Data {get;set;}

    public Node(T data)
    {
        Data = data;
    }


}