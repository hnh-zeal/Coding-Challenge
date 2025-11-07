// See https://aka.ms/new-console-template for more information

using OldPhoneKeypad;

class Program
{
    static void Main(string[] args)
    {
        // Interactive mode
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("Try your own input! (or press Enter to exit)");
        Console.WriteLine(new string('=', 50));

        while (true)
        {
            Console.Write("\nEnter phone keypad sequence: ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                break;
            }

            if (!input.EndsWith("#"))
            {
                input += "#";
            }

            string output = OldPhone.OldPhonePad(input);
            Console.WriteLine($"Output: {output}");
        }
    }
}