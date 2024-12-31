int jumpToBeat = int.Parse(Console.ReadLine());
bool isSuccessful = false;
int currentJumpToBeat = jumpToBeat - 30;
int failCounter = 0;
int jumpCount = 0;
int currentJump = 0;
while (!isSuccessful)
{

    currentJump = int.Parse(Console.ReadLine());
    jumpCount++;
    if (currentJump > currentJumpToBeat)
    {
        if (currentJumpToBeat < jumpToBeat)
        {
            currentJumpToBeat += 5;
            failCounter = 0;
        }
        else
        {
            Console.WriteLine($"Tihomir succeeded, he jumped over {currentJumpToBeat}cm after {jumpCount} jumps.");
            isSuccessful = true;
        }
    }
    else
    {
        failCounter++;
        if (failCounter >= 3)
        {
            Console.WriteLine($"Tihomir failed at {currentJumpToBeat}cm after {jumpCount} jumps.");
            break;
        }
    }



}