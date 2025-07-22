/*
 * BST In-Order Traversal
Given a binary search tree, produce an in-order list of all keys
in the tree without using recursion. Explain and code an efficient solution,
and analyze the time and space complexities.

Follow Up Problem: Solve the problem above,
without any additional memory besides the tree.
 */

internal class Program
{
    private static void Main(string[] args)
    {
        var bst = new BinarySearchTree();
        var random = new Random();

        for (int i = 1; i <= 10; i++)
        {
            int value = random.Next(1, 100);
            bst.Insert(value);
        }

        bst.InOrderTraversal().ForEach(Console.WriteLine);
        bst.InOrderTraversalWithoutExtraMemory().ForEach(Console.WriteLine);
    }
}

internal class Node(int value)
{
    public int Value { get; set; } = value;
    public Node? Left { get; set; } = null;
    public Node? Right { get; set; } = null;
}

internal class BinarySearchTree
{
    public Node? Root { get; set; } = null;


    /*
     * Insertion using recursion
     * Time complexity is O(log n) on average, O(n) in the worst case (unbalanced tree)
     * Space complexity is O(h) where h is the height of the tree
     */
    public void Insert(int value)
    {
        var node = Insert(Root, value);
        Root ??= node;
    }

    private static Node Insert(Node? node, int value)
    {
        if (node == null)
        {
            node = new Node(value);
            return node;
        }

        if (value < node.Value)
            node.Left = Insert(node.Left, value);
        else
            node.Right = Insert(node.Right, value);

        return node;
    }

    /*
     * In-Order Traversal using a stack
     * Time complexity is O(n) where n is the number of nodes in the tree
     * Space complexity is O(h) where h is the height of the tree (due to the stack)
     */
    public List<int> InOrderTraversal()
    {
        var result = new List<int>();
        var stack = new Stack<Node>();
        Node? current = Root;

        while (current != null || stack.Count > 0)
        {
            while (current != null)
            {
                stack.Push(current);
                current = current.Left;
            }
            current = stack.Pop();
            result.Add(current.Value);
            current = current.Right;
        }
        return result;
    }

    /*
     * In-Order Traversal without extra memory
     * This implementation uses the Morris Traversal algorithm
     * Time complexity is O(n) where n is the number of nodes in the tree
     * Space complexity is O(1) (no additional memory used)
     */
    public List<int> InOrderTraversalWithoutExtraMemory()
    {
        var result = new List<int>();
        Node? current = Root;
        Node? previous = null;
        while (current != null)
        {
            if (current.Left == null)
            {
                result.Add(current.Value);
                current = current.Right;
            }
            else
            {
                previous = current.Left;
                while (previous.Right != null && previous.Right != current)
                {
                    previous = previous.Right;
                }
                if (previous.Right == null)
                {
                    previous.Right = current;
                    current = current.Left;
                }
                else
                {
                    previous.Right = null;
                    result.Add(current.Value);
                    current = current.Right;
                }
            }
        }
        return result;
    }
}