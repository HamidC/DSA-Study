
/*
 * Anonymous Love Letter
You have written an anonymous love letter and you don’t want your handwriting
to be recognized. Since you don’t have a printer within reach,
you are trying to write this letter by copying and pasting characters from a newspaper.

Given a string L representing the letter and a string N representing the newspaper,
return true if the L can be written entirely from N and false otherwise.
The letter includes only ascii characters.
*/
internal class Program
{
    private static void Main(string[] args)
    {
        string letter = "Love you!";
        string newspaper = "newspaper example very nice Luke! o_o";

        bool result = CanWriteLetter(letter, newspaper);
        Console.WriteLine($"result = {result}");
    }


    /*
     * Solved using a hash table indexing every ascii character
     * Time complexity is O(m+n)
     * Space complexity is O(1) (Constant space)
     */
    private static bool CanWriteLetter(string letter, string newspaper)
    {
        var hashTable = new int[128];

        foreach (char c in newspaper)
        {
            if (char.IsWhiteSpace(c))
                continue;
            
            hashTable[c]++;
        }

        foreach (char c in letter)
        {
            if (char.IsWhiteSpace(c))
                continue;

            hashTable[c]--;

            if (hashTable[c] < 0)
                return false;
        }

        return true;
    }
}