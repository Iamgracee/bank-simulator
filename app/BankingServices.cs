namespace ATMApp.Services
{
   public class BankingService
{
    private static double lastTransaction = 0.00;

    public static double CheckBalance(double balance)
    {
        return balance; 
    }

    public static void Deposit(ref double balance, double amount)
    {
        balance += amount;
        lastTransaction = amount; 
    }

    public static void Withdraw(ref double balance, double amount, out bool success)
    {
        if (amount <= balance)
        {
            balance -= amount;
            lastTransaction = -amount;
            success = true;
        }
        else
        {
            success = false;
        }
    }

    public static double GetLastTransaction()
    {
        return lastTransaction;
    }

    public static void PrintMiniStatement(double balance)
    {
        Console.WriteLine("\n--- Mini Statement ---");
        Console.WriteLine("Current Balance: ₱" + balance.ToString("F2"));
        Console.WriteLine("Last Transaction Amount: ₱" + lastTransaction.ToString("F2"));
    }
}
}
