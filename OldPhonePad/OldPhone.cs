public class OldPhone
{
   public static  Dictionary<char, List<char>> charObj;

    public OldPhone()
    {
        charObj = new Dictionary<char, List<char>>()
        {
            { '1', new List<char>{ '&', ',', '(' } },
            { '2', new List<char>{ 'A', 'B', 'C' } },
            { '3', new List<char>{ 'D', 'E', 'F' } },
            { '4', new List<char>{ 'G', 'H', 'I' } },
            { '5', new List<char>{ 'J', 'K', 'L' } },
            { '6', new List<char>{ 'M', 'N', 'O' } },
            { '7', new List<char>{ 'P', 'Q', 'R', 'S' } },
            { '8', new List<char>{ 'T', 'U', 'V' } },
            { '9', new List<char>{ 'W', 'X', 'Y', 'Z' } },
            { '0', new List<char>{ ' ' } }
        };
    }
    public static char getCorrectChar(int charConsequtiveQuantity, char prevChar)
    {
         return OldPhone.charObj[prevChar][charConsequtiveQuantity - 1];      
 
    }
    public static string OldPhonePad(string input)
    {
        if(string.IsNullOrEmpty(input)) return string.Empty;
        //input = input.Replace(" ", "");
        int charConsequtiveQuantity = 1; char prevChar = input[0];int index = 1;
        string output = string.Empty;

        while(index < input.Length)
        {
            if (input[index] == '*' || input[index] == '#')
            {
                if (input[index] == '*')
                {
                    charConsequtiveQuantity = 1;
                    prevChar = input[index+1];
                    index++;
                }
                else
                { 
                    if(prevChar != '#')
                    output += getCorrectChar(charConsequtiveQuantity, prevChar);

                    return output;

                }
            }else if(input[index] == ' ')
            {
                if(prevChar != ' ')
                    output += getCorrectChar(charConsequtiveQuantity, prevChar);
                charConsequtiveQuantity = 1;
                prevChar = input[index + 1];
                index++;
            }
            else if (input[index] == prevChar)
            {
                charConsequtiveQuantity++;
                //updating prev char
                prevChar = input[index];
            }
            else
            {
                output += getCorrectChar(charConsequtiveQuantity, prevChar);
                charConsequtiveQuantity = 1;
                //updating prev char
                prevChar = input[index];
            }

         
            index++;
        }

        return output;
    }

    public static void Main(string[] args)
    {
        var OldPhoneObj = new OldPhone();

        Console.WriteLine("Output 1: " + OldPhonePad("33#"));  // Expected Output: E
        Console.WriteLine("Output 2: " + OldPhonePad("227*#")); // Expected Output: B
        Console.WriteLine("Output 3: " + OldPhonePad("4433555 555666#")); // Expected Output: HELLO
        Console.WriteLine("Output 4: " + OldPhonePad("8 88777444666*664#"));  // Expected Output: 
    }
}
 

