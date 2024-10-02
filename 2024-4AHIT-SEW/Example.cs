class MyStack<T>
{
    public string Name{ get; set; }
    public T[] Element{ get; set; }
    public int Length { get { return this.Pointer; } } // Anzahl der Elemente im Stack
    private int Pointer {  get; set; }

    public MyStack(int size, string name = "")
    {
        this.Element = new T[size];
        this.Name = name;
        this.Pointer = 0;
    }
    public void Push (T element)
    {
        if (Pointer>=this.Element.Length) 
            throw new StackOverflowException();

        this.Element[this.Pointer] = element;
        this.Pointer++;
    }

    public T Pop()
    {
        this.Pointer--;
        if(this.Pointer >= 0)
            return this.Element[this.Pointer];
        else
        {
            this.Pointer = 0;
            throw new InvalidOperationException("Der Stack ist leer");
        }
    }
}

public class Demo<T, A>
{
    public T Key { get; set; }
    public A Value { get; set; }

    public Demo(T key, A val)
    {
        this.Key = key;
        this.Value = val;
    }
}

public class Prog
{
    public static void Main (string[] args)
    {
        Demo<string, int> _demo = new Demo<string, int> ("myKey", 12);

        Console.WriteLine($"{_demo.Key} : {_demo.Value}");

    }

    public static void Print<T>(T value)
    {
        Console.WriteLine(value);
    }
}
