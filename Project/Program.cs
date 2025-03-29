using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using MyList;
// int [] array2 = {1};
// List <int> mylistReal = new List<int>();
// mylistReal.Add(1);
// mylistReal.Add(2);
// mylistReal.Add(3);
// mylistReal.Add(4);
// mylistReal.Remove(3);
// Console.WriteLine(mylistReal[0]);
// mylistReal.Add(69);
// Console.WriteLine(mylistReal[0]);


int [] array = {1};
var myList = new MyList <int> ();
myList.Add(1);
myList.Add(2);
myList.Add(3);
myList.Add(4);
myList.AddToStart(5);
myList.Add(6);
//myList.Remove(3);
myList.ToString();

