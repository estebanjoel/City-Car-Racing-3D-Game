using System;
public class Stack<T>
{
    /*Node List
    //Stack<T>.Node
    private class Node
    {
        public T node;
        public Node next;
    }*/

    T[] data = new T[4];
    
    public int Count { get; private set; }

    private void EnsureCapacity(int capacity)
    {
        if (capacity > data.Length)
        {
            var aux = new T[data.Length * 2];
            Array.Copy(data, aux, Count);
            data = aux;
        }
    }

    public void Push(T item)
    {
        EnsureCapacity(Count + 1);
        data[Count] = item;
        Count++;
    }

    public T Pop()
    {
        CheckBounds(Count - 1);
        T pushedData = data[Count - 1];
        data[Count - 1] = default;
        Count--;
        return pushedData;
    }

    public T Peek()
    {
        return data[Count - 1];
    }

    private void CheckBounds(int index)
    {
        if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException();
    }
}