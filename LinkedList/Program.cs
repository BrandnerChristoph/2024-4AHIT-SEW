// Hauptprogramm
using GeometrischeForm.Model;
using LinkedList;

SingleLinkedList linkedList = new SingleLinkedList();
linkedList.Add("Hermann");
linkedList.Add("Josef");
linkedList.Add("Ludwig");
linkedList.Add("Ludwig");

linkedList.printListRec();


Console.WriteLine("\n");
linkedList.Remove("Ludwig");
linkedList.PrintList();

Console.WriteLine("\n\n\n\n");

////////////////////////////////
///// Objekte Form
///
SingleFormLinkedList myFormsList = new SingleFormLinkedList();
myFormsList.Add(new Kugel("first kugel", 8));
myFormsList.Add(new Quader("der Quader folgt", 34, 5, 6));
myFormsList.PrintList();


////////////////////////////////
///// Generische
///
SingleGenericLinkedList<Form> myFormList =  new SingleGenericLinkedList<Form>();
myFormList.Add(new Kugel("hy", 3));

myFormList.PrintList();
