using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using MyList;
// int [] array2 = {1};
// List <int> mylistReal = new List<int>(4);
// for (int i = 0; i < array2.Length; i++)
//     mylistReal[i] = array2[i];
// Console.WriteLine(mylistReal[0]);
// mylistReal.Add(69);
// Console.WriteLine(mylistReal[0]);



int [] array = {1};
MyList <int> myList = new MyList <int> (4);
for (int i = 0; i < array.Length; i++)
    myList.Add(array[i]);
Console.WriteLine(myList[0]);
myList.AddFirst(1);
myList.AddFirst(70);
myList.AddFirst(71);
myList.AddFirst(71);
myList.AddFirst(71);
myList.RemoveFromLast(1);
Console.WriteLine(myList[0]);

