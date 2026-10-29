using System;


public class Node
{
    public int Value;   
    public Node? Next;  

    public Node(int value)
    {
        Value = value;
        Next = null;    
    }
}


public class MyList
{
    private Node? head; 
    private Node? tail; 

    
    public void AddLast(int value)
    {
        var newNode = new Node(value);


        if (head is null)
        {
            head = newNode;
            tail = newNode;
            return;
        }


        tail!.Next = newNode;
        tail = newNode;
    }

    
    public Node? Find(int value)
    {
        Node? current = head;

        
        while (current is not null)
        {
            if (current.Value == value)
                return current; 
            current = current.Next;
        }

        return null; 
    }

    
    public bool Remove(int value)
    {
        
        if (head is null)
            return false;

        
        if (head.Value == value)
        {
            head = head.Next;
            if (head is null) tail = null; 
            return true;
        }

        
        Node previous = head;
        Node? current = head.Next;

        while (current is not null)
        {
            if (current.Value == value)
            {
                previous.Next = current.Next; 
                if (current == tail) tail = previous; 
                return true;
            }
            previous = current;
            current = current.Next;
        }

        return false; 
    }

    
    public void Print()
    {
        Node? current = head;
        while (current is not null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        var list = new MyList();

        
        list.AddLast(10);
        list.AddLast(20);
        list.AddLast(30);
        list.AddLast(40);
        Console.Write("Список: ");
        list.Print();

        
        Console.WriteLine("Пошук 30: " + (list.Find(30) != null ? "знайдено" : "не знайдено"));
        Console.WriteLine("Пошук 99: " + (list.Find(99) != null ? "знайдено" : "не знайдено"));

        
        list.Remove(10); 
        Console.Write("Після видалення 10: ");
        list.Print();

        list.Remove(30); 
        Console.Write("Після видалення 30: ");
        list.Print();

        Console.WriteLine("Видалення 99: " + list.Remove(99)); 

        list.AddLast(50); 
        Console.Write("Після додавання 50: ");
        list.Print();

        
        int[] arr = { 1, 2, 3, 4, 5 };
        int newValue = 99;
        int index = 2; 

        
      int[] newArr = new int[arr.Length + 1];

        
        for (int i = 0; i < index; i++)
            newArr[i] = arr[i];

        
        newArr[index] = newValue;

        
        for (int i = index; i < arr.Length; i++)
            newArr[i + 1] = arr[i];

        Console.Write("Масив після вставки: ");
        foreach (int x in newArr)
            Console.Write(x + " ");
        Console.WriteLine();

    
        
    }
}
