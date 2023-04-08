using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class TreeOperations
    {
 
    public static AVL MUL(AVL tree1, int amount=0) //умножение 
    {
        if (tree1.root == null) { return tree1; }
        int counter = tree1.maxAmount+1;
        int counter1 = tree1.maxAmount;
        int i = 0;
        while (counter<(counter1*amount+1))
        {
            i++;
            if (i % 7 == 0) { continue; }
            int m = i % (counter1 + 1);
            tree1.Add(tree1.FindByNumber(m).data, counter++);
        }
        return tree1;
    }

    public static AVL CONCAT(AVL tree1, AVL tree2) // объединение
    {
        if (tree1.root != null)
        {
            int counter = tree1.maxAmount + 1;
            int counter1 = tree2.maxAmount + 1;

            for (int i=1; i<counter1; i++)
            {
                tree1.Add(tree2.FindByNumber(i).data, counter++);

            }
        }
        return tree1;
    }

    public static AVL EXCEL(AVL tree1, AVL tree2) // объединение
    {
        if (tree1.root != null)
        {
            int counter = tree1.maxAmount + 1;
            int counter1 = tree2.maxAmount + 1;

            if (counter1 > counter)
            {
                Console.WriteLine("Невозможно исключить вторую последовательность из первой");
                return tree1;
            }

            AVL.Node startNode=tree2.FindByNumber(1);
            if (tree1.Find(startNode.data))
            {
                AVL.Node sameNode = tree1.GetNodeByData(startNode.data);
                Console.WriteLine("Same node was found" + startNode.data);
                CheckAllNodeNumbers(sameNode, counter1, tree1, tree2);
            }
            else
            {
                Console.WriteLine("Same node was not found" + startNode.data);
            }

        }
        return tree1;
    }

    private static void CheckAllNodeNumbers(AVL.Node sameNode, int counter1, AVL tree1, AVL tree2)
    {
        int x = 0;

        while (sameNode.numbers.Count != x)
        {
            if (!CompareSequence(sameNode.numbers[x], counter1, tree1, tree2))
            {
                x++;
            }
        }

    }

    private static bool CompareSequence(int firstTreeNumber, int counter1, AVL tree1, AVL tree2)
    {
        List<AVL.Node> objectsToDelete = new List<AVL.Node>();

        bool same = true;
        int m = firstTreeNumber;
        int firsNumber = 0;

        Console.WriteLine(tree2.maxAmount);

        if ((m + tree2.maxAmount - 1) > tree1.maxAmount)
        {
            Console.WriteLine("NO1");
            same = false;
            return same;
        }

        for (int i=1; i<counter1; i++)
        {
            if (tree1.FindByNumber(m).data != tree2.FindByNumber(i).data)
            {
                Console.WriteLine("NO");
                same = false;
                break;
            }
            else
            {
                AVL.Node node = tree1.FindByNumber(m);

                if (objectsToDelete.Count == 0)
                {
                    firsNumber = m;
                }
                objectsToDelete.Add(node);
                node.deleteNumbers.Add(m);
            }
            m++;
        }

        if (same == true)
        {
            Console.WriteLine("SAME");
            Delete(objectsToDelete, tree1, firsNumber);
        }
        return same;
    }

    public static void Delete(List<AVL.Node> objectsToDelete, AVL tree1, int firstNumber)
    {
        int length = objectsToDelete.Count;

        for (int i=0; i<objectsToDelete.Count; i++)
        {
            if (objectsToDelete[i].duplicates < 2)
            {
                objectsToDelete[i].duplicates -= 1;
                objectsToDelete[i].numbers.Remove(objectsToDelete[i].deleteNumbers[0]);
                objectsToDelete[i].deleteNumbers.Remove(objectsToDelete[i].deleteNumbers[0]);
                tree1.Delete(objectsToDelete[i].data);

            }
            else
            {
                objectsToDelete[i].duplicates -= 1;
                objectsToDelete[i].numbers.Remove(objectsToDelete[i].deleteNumbers[0]);
                objectsToDelete[i].deleteNumbers.Remove(objectsToDelete[i].deleteNumbers[0]);
            }
        }
        tree1.maxAmount -= length;
        tree1.Reorder(firstNumber, length);
    }
}

