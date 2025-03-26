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
var myList = new MyList <int> ();
myList.Add(1);
myList.Add(2);
myList.Add(3);
myList.Add(4);
myList.Add(5);
myList.Add(6);
myList.Add(7);
myList.Add(8);
myList.Add(9);
myList.Add(10);
myList.ToString();

