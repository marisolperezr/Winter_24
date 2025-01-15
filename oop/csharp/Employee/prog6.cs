//Polinomial
using System;

public class LinkedList // The definition of a linked list
{
    public Node head;              // head of list  
    public class Node              // the constructor
    {
        public int exp;  
        public int coef;
        public Node next;
        public Node(int p_exp, int p_coef)
        {
            exp = p_exp;
            coef = p_coef;
            next = null;
        }
    }

    public void AddLastNode(int p_exp, int p_coef) // Adding a node at the end of the list
    {
        Node new_node = new Node(p_exp, p_coef);
        if (head == null)
        {
            head = new_node;
            return;
        }
        Node lastNode = head;
        while (lastNode.next != null)
        {
            lastNode = lastNode.next;
        }
        lastNode.next = new_node;
    }

    public void ReverseLinkedList()
    {
        Node prev = null;
        Node current = head;
        Node temp = null;
        while (current != null)
        {
            temp = current.next;
            current.next = prev;
            prev = current;
            current = temp;
        }
        head = prev;
    }
    
    public double Value(double x) // calculates the value of a given x
    {
        double value = 0;
        Node n = head;
        while (n != null)
        {
            value += n.coef * Math.Pow(x, n.exp);
            n = n.next;
        }
        return value;
    }
    
    public LinkedList Derivative()
    {
        LinkedList W = new LinkedList();
        Node n = head;
        while (n != null)
        {
            if (n.exp > 0)
            {
                W.AddLastNode(n.exp - 1, n.exp * n.coef);
            }
            n = n.next;
        }
        return W;
    }
    
    public void PrintList(string name) // prints out all nodes of a list
    {
        Node n = head;
        Console.Write(name + "(x) = ");
        while (n != null)
        {
            if (n.coef == 1) 
            {
                Console.Write("x^" + n.exp);
            }
            else if (n.coef == -1) 
            {
                Console.Write("-x^" + n.exp);
            }
            else if (n.exp == 1) 
            {
                Console.Write(n.coef + "x");
            }
            else if (n.exp == 0) 
            {
                Console.Write(n.coef);
            }
            else 
            {
                Console.Write(n.coef + "x^" + n.exp);
            }
            
            if (n.next != null && n.next.coef > 0) 
            {
                Console.Write(" + ");
            }
            n = n.next;    
        }
        Console.WriteLine();
    }
} //class

public class Program
{
    // Main method 
    static public void Main()
    {
        LinkedList P = new LinkedList();

        P.AddLastNode(3, -1);            // -x^3 + 2*x^2 + 4*x - 4       
        P.AddLastNode(2, 2);
        P.AddLastNode(1, 4);
        P.AddLastNode(0, -4);

        P.PrintList("P----");

        P.ReverseLinkedList();
        P.PrintList("P");
        
        double x = 2;
        Console.WriteLine("P(" + x + ")=" + P.Value(x));
        
        x = 0;
        Console.WriteLine("P(" + x + ")=" + P.Value(x));
        
        LinkedList W = P.Derivative();
        
        Console.WriteLine("W is the derivative of P.");
        W.ReverseLinkedList();
        W.PrintList("W");
        x = 1;
        Console.WriteLine("W(" + x + ")=" + W.Value(x));

        // The second example
        LinkedList H = new LinkedList();

        H.AddLastNode(6, -1);
        H.AddLastNode(3, 2);
        H.AddLastNode(1, 4);
        H.AddLastNode(0, -3);
        
        H.ReverseLinkedList();
        H.PrintList("H");
        LinkedList G = H.Derivative();
        
        Console.WriteLine("G is the derivative of H.");
        G.ReverseLinkedList();
        G.PrintList("G");
        x = 1;
        Console.WriteLine("G(" + x + ")=" + G.Value(x));
    }
}
