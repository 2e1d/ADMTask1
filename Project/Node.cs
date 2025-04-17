namespace Node;

public class Node<T>
{
    public Node<T> next;

    public T Data {get;set;}

    public Node(T data)
    {
        Data = data;
    }


}