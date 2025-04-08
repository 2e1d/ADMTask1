using MyList;
using MyLinkedList;
// int [] array2 = {1};
//List <int> mylistReal = new List<int>();
// mylistReal.Add(1);
// mylistReal.Add(2);
// mylistReal.Add(3);
// mylistReal.Add(4);
// mylistReal.Remove(3);
// Console.WriteLine(mylistReal[0]);
// mylistReal.Add(69);
// Console.WriteLine(mylistReal[0]);


var myLinkedList = new MyLinkedList<int> ();
myLinkedList.Add(1);
myLinkedList.Add(2);
myLinkedList.Add(3);
myLinkedList.Add(4);
myLinkedList.Add(5);
System.Console.WriteLine(myLinkedList[0].Data);

