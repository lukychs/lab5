using System.Collections;
using System.Runtime.InteropServices;

class MyList<T>: IEnumerable<T>
{
    private T[] mas;
    private int capacity;

    public MyList()
    {
        mas = new T[4];
        capacity = 0;
    }

    public void Add(T item)
    {
        int newCapacity;

        if (capacity == 0)
        {
            newCapacity = mas.Length;
        }
        else if (capacity > 0 && capacity % 4 == 0)
        {
            newCapacity = mas.Length * 2;
        }
        else
        {
            newCapacity = mas.Length;
        }

        T[] mas1 = new T[newCapacity];

        for (int i = 0; i < mas.Length; i++)
            mas1[i] = mas[i];
        mas1[capacity] = item;
        capacity++;

        mas = mas1;
    }

    public T this[int index]
    {
        get => mas[index];
        set => mas[index] = value;
    }

    public int Count => capacity;

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in mas)
        {
            yield return item;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void print()
    {
        for(int i = 0; i < capacity; i++)
        {
            Console.Write($"{mas[i]}" + " ");
        }

        Console.WriteLine();
    }

}

class Program
{
    static void Main(string[] args)
    {
        MyList<int> myList = new MyList<int>() { 1, 2, 3 };

        Console.Write("До добавления элемента: ");
        myList.print();

        myList.Add(4);
        Console.Write("После добавления: ");
        myList.print();

        Console.WriteLine($"Получение значения элемента по индексу 1: {myList[1]}");
        Console.WriteLine($"Общее количество элементов: {myList.Count}");
    }
}
