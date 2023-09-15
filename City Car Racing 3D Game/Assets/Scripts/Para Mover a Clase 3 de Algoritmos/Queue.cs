using System;
public class Queue<T>
{
    T[] data = new T[4];
    
    public int Count { get; private set; }

    //Indexer
    public T this[int index]
    {
        get {
            CheckBounds(index);
            return data[index];
        }
        set {
            CheckBounds(index);
            data[index] = value;
        }
    }

    private void EnsureCapacity(int capacity)
    {
        if (capacity > data.Length)
        {
            var aux = new T[data.Length * 2];
            Array.Copy(data, aux, Count);
            data = aux;
        }
    }

    public void Enqueue(T item)
    {
        EnsureCapacity(Count + 1);
        data[Count] = item;
        Count++;
    }

    public T Dequeue()
    {
        CheckBounds(0);
        T dequeuedData = data[0];
        data[0] = default;

        for (int i = 0; i < Count - 1; i++)
        {
            data[i] = data[i + 1];
        }

        data[Count - 1] = default;
        Count--;
        return dequeuedData;
    }

    public T Peek()
    {
        return data[0];
    }

    private void CheckBounds(int index)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException();
    }
}