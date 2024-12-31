int period = int.Parse(Console.ReadLine());

int patientsTreated = 0;
int patientsNotTreated = 0;
int doctors = 7;
int daysCounter = 0;
for (int i = 0; i < period; i++)
{
    int patientPerDay = int.Parse(Console.ReadLine());
    daysCounter++;
    if (daysCounter%3==0 && patientsNotTreated>patientsTreated) doctors++;

    if (patientPerDay <= doctors)
    {
        patientsTreated += patientPerDay;
    }
    else
    {
        patientsTreated += doctors;
        patientsNotTreated = patientsNotTreated + patientPerDay - doctors;
    }
}
Console.WriteLine($"Treated patients: {patientsTreated}.");
Console.WriteLine($"Untreated patients: {patientsNotTreated}.");