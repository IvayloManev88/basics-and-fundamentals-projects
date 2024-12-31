using System.ComponentModel.Design;

string word = "";
string secretWord = "";
int oCounter = 0;
int cCounter = 0;
int nCounter  = 0;
string finalWord = "";
string helpWord = "";
while ((word = Console.ReadLine()) != "End")
{
    if (word != "a" && word != "b" && word != "c" && word != "d" && word != "e" && word != "f" && word != "g" && word != "h" && word != "i" && word != "j" && word != "k" && word != "l" && word != "m" && word != "n" && word != "o" && word != "p" && word != "q" && word != "r" && word != "s" && word != "t" && word != "u" && word != "v" && word != "w" && word != "x" && word != "y" && word != "z" && word != "A" && word != "B" && word != "C" && word != "D" && word != "E" && word != "F" && word != "G" && word != "H" && word != "I" && word != "J" && word != "K" && word != "L" && word != "M" && word != "N" && word != "O" && word != "P" && word != "Q" && word != "R" && word != "S" && word != "T" && word != "U" && word != "V" && word != "W" && word != "X" && word != "Y" && word != "Z")
        word = "";
    else if (word == "c" && cCounter < 1)
    {
        word = "";
        cCounter++;
        secretWord += "c";
    }
    else if (word == "o" && oCounter < 1)
    {
        word = "";
        oCounter++;
        secretWord += "o";
    }
    else if (word == "n" && nCounter < 1)
    {
        word = "";
        nCounter++;
        secretWord += "n";
    }
    helpWord += word;
        if (secretWord == "con" || secretWord == "noc" || secretWord == "ocn" || secretWord == "cno" || secretWord == "onc" || secretWord == "nco")
        {
            secretWord = "";
            cCounter = 0;
            nCounter = 0;
            oCounter = 0;
            finalWord += helpWord + " ";
            helpWord = "";
        }
}
Console.WriteLine(finalWord);