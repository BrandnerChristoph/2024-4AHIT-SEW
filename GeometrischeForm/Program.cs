using GeometrischeForm.Model;

List<Form> myForms = new List<Form>();

myForms.Add(new Kugel("erste Kugel", 6));
myForms.Add(new Kugel("zweite Kugel", 4.7));
myForms.Add(new Wuerfel("my Würfel", 4.5));
myForms.Add(new Quader("Quader", 4,5,6));


string strInput = "";
while (strInput != "0")
{
    Console.Clear();
    printMenu();
    strInput = Console.ReadLine().Trim();
    Console.Clear();

    switch (strInput)
    {
        case "1":
            Console.WriteLine("Alle Formen");
            printShapes();
            break;
        case "2":
            Console.WriteLine("Alle Kugeln");
            printShapes(typeof(Kugel));
            break;
        case "3":
            Console.WriteLine("Alle Würfel");
            printShapes(typeof(Wuerfel));
            break;
        case "4":
            Console.WriteLine("Alle Quader");
            printShapes(typeof(Quader));
            break;

        case "8":
            try
            {
                Console.Write("Welche Form soll erstellt werden (w ... Würfel; q ... Quader; k ... Kugel)? ");
                string formType = Console.ReadLine();
                if (formType.ToLower() == "w")
                {
                    Console.WriteLine($"neuer Würfel");
                    Console.Write(" - Bezeichnung: ");
                    string newBez = Console.ReadLine();
                    Console.Write(" - Länge: ");
                    double newLaenge = double.Parse(Console.ReadLine());

                    myForms.Add(new Wuerfel(newBez, newLaenge));
                    Console.WriteLine("neuer Würfel wurde gespeichert.");
                }
                else if (formType.ToLower() == "q")
                {
                    Console.WriteLine($"neuer Quader");
                    Console.Write(" - Bezeichnung: ");
                    string newBez = Console.ReadLine();
                    Console.Write(" - Breite: ");
                    double newBreite = double.Parse(Console.ReadLine());
                    Console.Write(" - Tiefe: ");
                    double newTiefe = double.Parse(Console.ReadLine());
                    Console.Write(" - Höhe: ");
                    double newHoehe = double.Parse(Console.ReadLine());

                    myForms.Add(new Quader(newBez, newHoehe, newBreite, newTiefe));
                    Console.WriteLine("neuer Quader wurde gespeichert.");
                }
                else if (formType.ToLower() == "k")
                {
                    Console.WriteLine($"neuer Kugel");
                    Console.Write(" - Bezeichnung: ");
                    string newBez = Console.ReadLine();
                    Console.Write(" - Radius: ");
                    double newRadius = double.Parse(Console.ReadLine());

                    myForms.Add(new Kugel(newBez, newRadius));
                    Console.WriteLine("neue Kugel wurde gespeichert.");
                }
                else
                    throw new Exception("unbekannte Form");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            break;

        case "9":
            try
            {
                Console.WriteLine("welches Element soll gelöscht werden?");

                for (int i = 0; i < myForms.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {myForms[i].ToString()}");
                }

                Console.Write("Welcher Index soll gelöscht werden? ");
                int idx = int.Parse(Console.ReadLine());

                if (idx < 0 || idx >= myForms.Count)
                    throw new Exception("Index ist nicht bekannt!");

                myForms.RemoveAt(idx - 1);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            break;
        
    
        
    }
    Console.ReadLine();
}


void printMenu(){
    Console.WriteLine("\n=========================================================");
    Console.WriteLine("Navigation");
    Console.WriteLine("\t1 ... Ausgabe alle Formen");
    Console.WriteLine("\t2 ... Ausgabe alle Kugeln");
    Console.WriteLine("\t3 ... Ausgabe alle Würfel ");
    Console.WriteLine("\t4 ... Ausgabe alle Quader");
    Console.WriteLine("\t8 ... Form hinzufügen");
    Console.WriteLine("\t9 ... Form entfernen");
    Console.WriteLine("\t0 ... Programm beenden");

    Console.Write("Menüauswahl: ");
}

void printShapes(Type t = null)
{
    foreach (Form form in myForms) {
        if (t == null)
            Console.WriteLine("\t" + form.ToString());
        else
        {
            if (form.GetType() == t)
                Console.WriteLine($"\tform.ToString()");
        }
    }
}