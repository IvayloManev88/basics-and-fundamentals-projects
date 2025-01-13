namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string password = Console.ReadLine();
            int correctChecker = 0;
            if (!PasswordBetween6and10chars(password)) Console.WriteLine("Password must be between 6 and 10 characters"); else correctChecker++;
            if (!PasswordLettersAndDigits(password)) Console.WriteLine("Password must consist only of letters and digits"); else correctChecker++;
            if (!PasswordContainsTwoDigits(password)) Console.WriteLine("Password must have at least 2 digits"); else correctChecker++;

            if (correctChecker == 3) Console.WriteLine("Password is valid");

        }
        static bool PasswordBetween6and10chars (string password)
        {
            bool isCorrectLength = false;
            if ((password.Length >= 6) && (password.Length <= 10)) isCorrectLength = true;
            return isCorrectLength;
        }
        static bool PasswordLettersAndDigits (string password)
        {
            bool isLetersAndDigits = true;
            char[] chars = password.ToCharArray();
            foreach (char c in chars)
            {
                if (((int)c <= 47)|| ((int)c >= 58 && (int)c <= 64)|| ((int)c >= 91 && (int)c <= 96) || ((int)c >= 123))
                {
                    isLetersAndDigits = false;
                }
                
            }
            return isLetersAndDigits;
        }
        static bool PasswordContainsTwoDigits(string password)
        {
            bool isCountDigitsCorrect = false;
            int digitCounter = 0;
            char[] chars = password.ToCharArray();
            foreach (char c in chars)
            {
                if ((int)c >=48 && (int)c <= 57)
                {
                    digitCounter++;
                }
            }
            if (digitCounter>=2) isCountDigitsCorrect=true;
            return isCountDigitsCorrect;
        }
    }
}
