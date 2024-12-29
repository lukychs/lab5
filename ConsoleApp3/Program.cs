using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private TKey[] keys;
    private TValue[] values;
  
    public MyDictionary(TKey[] keys, TValue[] values)
    {
        this.keys = keys;
        this.values = values;
    }

    public bool TryAdd(TKey key, TValue value)
    {
        foreach (var k in keys) 
        {
            if (k.Equals(key))
            {
                return false;
                break;
            }
        }

        return true;
    }

    public void Add(TKey key, TValue value)
    {
        if (TryAdd(key, value))
        {
            TKey[] keys1 = new TKey[keys.Length + 1];
            TValue[] values1 = new TValue[values.Length + 1];

            for (int i = 0; i < keys.Length; i++)
            {
                keys1[i] = keys[i];
                values1[i] = values[i];
            }

            keys1[keys1.Length - 1] = key;
            values1[keys1.Length - 1] = value;
            keys = keys1;
            values = values1;
        }

        else
            throw new ArgumentException("Ключ уже имеется в коллекции");
    }

    public TValue this[int index]
    {
        get => values[index];
        set => values[index] = value;
    }

    public int Count
    {
        get { return keys.Length; }
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void print()
    {
        for (int i = 0; i < keys.Length; i++)
            Console.WriteLine($"{keys[i]}: {values[i]}");

        Console.WriteLine();
    }

}

class Program
{
    static void Main(string[] args)
    {
        string[] keys = { "a", "b", "c" };
        int[] values = { 1, 2, 3 };
        MyDictionary<string, int> dict = new MyDictionary<string, int>(keys, values);

        Console.WriteLine("До добавления элемента и ключа:");
        dict.print();

        dict.Add("d", 4);
        Console.WriteLine("После добавления:");
        dict.print();

        Console.WriteLine($"Значение элемента по индеку 3: {dict[3]}");
    }
}