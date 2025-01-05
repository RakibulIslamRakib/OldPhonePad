using System;
using System.Collections.Generic;
using System.Text;

namespace OldPhonePad
{
    public class OldPhonePadChallenge
    {
        private static readonly Dictionary<char, string> keypadMap = new Dictionary<char, string>
        {
            {'1', "&'("},
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"},
            {'0', " "}
        };

        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            StringBuilder result = new StringBuilder();
            char lastKey = '\0'; // Tracks the last pressed key
            int pressCount = 0;  // Tracks how many times the key has been pressed

            foreach (char key in input)
            {
                if (key == '#')
                {
                    // Send button, end input
                    break;
                }
                else if (key == '*')
                {
                    // Backspace handling
                    if (result.Length > 0)
                    {
                        result.Length--;  // Remove the last character
                    }
                    lastKey = '\0'; // Reset lastKey so new input can proceed
                    pressCount = 0;
                    continue;
                }
                else if (key == ' ')
                {
                    // A space means reset the current keypress count (pause)
                    if (lastKey != '\0')
                    {
                        result.Append(ProcessKeyPress(lastKey, pressCount));
                    }
                    lastKey = '\0';
                    pressCount = 0;
                    continue;
                }

                if (key == lastKey)
                {
                    // Same key pressed, increase press count
                    pressCount++;
                }
                else
                {
                    // New key pressed, process the last one
                    if (lastKey != '\0')
                    {
                        result.Append(ProcessKeyPress(lastKey, pressCount));
                    }
                    lastKey = key;
                    pressCount = 1; // Start counting for the new key
                }
            }

            // Append the last key if needed (before '#')
            if (lastKey != '\0')
            {
                result.Append(ProcessKeyPress(lastKey, pressCount));
            }

            return result.ToString();
        }

        private static char ProcessKeyPress(char key, int pressCount)
        {
            if (keypadMap.ContainsKey(key))
            {
                string letters = keypadMap[key];
                int index = (pressCount - 1) % letters.Length;  // Cycle through letters
                return letters[index];
            }
            return '\0';  // Return null character for invalid input
        }
    }
}

