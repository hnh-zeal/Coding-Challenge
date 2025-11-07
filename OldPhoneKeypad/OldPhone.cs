using System.Text;

namespace OldPhoneKeypad
{
    public class OldPhone
    {
        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            // Map each key to specific letters
            var keypad = new Dictionary<char, string>
            {
                { '0', " " }, // Space
                { '1', "&'(" }, // Symbols
                { '2', "ABC" },
                { '3', "DEF" },
                { '4', "GHI" },
                { '5', "JKL" },
                { '6', "MNO" },
                { '7', "PQRS" },
                { '8', "TUV" },
                { '9', "WXYZ" }
            };

            var result = new StringBuilder();
            char? lastKey = null;
            int pressCount = 0;

            foreach (char c in input)
            {
                if (c.Equals('#'))
                {
                    // Process any remaining sequence before breaking
                    if (lastKey.HasValue && pressCount > 0)
                    {
                        string letters = keypad[lastKey.Value];
                        int index = (pressCount - 1) % letters.Length;
                        result.Append(letters[index]);
                    }

                    break;
                }

                if (keypad.ContainsKey(c))
                {
                    // Current character equals the last character
                    if (c == lastKey)
                    {
                        pressCount++;
                    }
                    else
                    {
                        // Append the previous sequence if exists
                        if (lastKey.HasValue)
                        {
                            string letters = keypad[lastKey.Value];
                            int index = (pressCount - 1) % letters.Length;
                            result.Append(letters[index]);
                        }

                        lastKey = c;
                        pressCount = 1;
                    }
                }
                else if (c.Equals('*'))
                {
                    // asterisk => delete the previous character
                    // Process current sequence BEFORE backspacing
                    if (lastKey.HasValue && pressCount > 0)
                    {
                        string letters = keypad[lastKey.Value];
                        int index = (pressCount - 1) % letters.Length;
                        result.Append(letters[index]);
                    }

                    // Then delete the previous character
                    if (result.Length > 0)
                        result.Remove(result.Length - 1, 1);

                    lastKey = null;
                    pressCount = 0;
                }
                else if (c.Equals(' '))
                {
                    // space => add the character to the result
                    if (lastKey.HasValue && pressCount > 0)
                    {
                        string letters = keypad[lastKey.Value];
                        int index = (pressCount - 1) % letters.Length;
                        result.Append(letters[index]);
                    }

                    lastKey = null;
                    pressCount = 0;
                }
            }

            return result.ToString();
        }
    }
}