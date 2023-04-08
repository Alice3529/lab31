using System;
using System.Collections.Generic;

class Program1
{
    const int power = 6;

    static void Main(string[] args)
    {

        AVL a = CreateSet();
        AVL b = CreateSet();


        //AVL a = GenerateSet("a");
        //AVL b = GenerateSet("b");
        //AVL c = GenerateSet("c");
        //AVL d = GenerateSet("d");
        //AVL e = GenerateSet("e");

        //Console.WriteLine("(A/B/C) XOR D U E");

        //AVL A_B=TreeOperations.EXCL(a, b);
        //AVL A_B_C = TreeOperations.EXCL(A_B, c);

        //AVL A_B_C_D_Union = TreeOperations.CONCAT(A_B_C, d);
        //AVL A_B_C_D_intersection = TreeOperations.INTER(A_B_C, d);
        //AVL A_B_C_D = TreeOperations.EXCL(A_B_C_D_Union, A_B_C_D_intersection);
        //AVL A_B_C_D_E = TreeOperations.CONCAT(A_B_C_D, e);

        ////A_B_C_D.DisplayTree();
        //A_B_C_D_E.Display();

        //Console.WriteLine("A U B");
        //AVL result = (((a / b / c) + d) / ((a / b / c) & d)) + e;
        //result.Display();

        //Console.WriteLine("MUL a");
        //a=TreeOperations.MUL(a,3);
        //a.Display();

        //  Console.WriteLine("MUL a");
        a = TreeOperations.EXCEL(a, b);
        a.Display();


        //Console.WriteLine("Concat a, b");
        //b = TreeOperations.CONCAT(a,b);
        //b.Display();
        Console.ReadKey();
    }

    public static AVL GenerateSet(string setName)
    {
        AVL tree = new AVL();
        int counter = 0;
        Console.WriteLine(setName);
        for (int i = 0; i < power; i++)
        {
            counter++;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int value = rnd.Next(1, 10);
            tree.Add(value, counter);
        }
        tree.Display();
        return tree;
        
    }

    public static AVL CreateSet()
    {
        Console.WriteLine("Введите размер множества");
        int amount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите элементы множества");
        AVL tree = new AVL();
        int i = 0;

        while (i<amount)
        {
            i++;
            int number=Convert.ToInt32(Console.ReadLine());
            tree.Add(number, i);
        }
        tree.Display();
        return tree;


    }
}
