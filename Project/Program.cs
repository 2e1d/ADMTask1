using MyList;


var list = new MyList<int>();

var newList = new List<int>();

int test = 5;
list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Remove(x => x == test);
// list.Remove(0);

// myList.Add(6);
//myList.Remove(3);
Console.WriteLine(list.ToString());

