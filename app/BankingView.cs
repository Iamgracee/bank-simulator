using ATMApp.Services;

namespace ATMApp.View
{
    public class BankingView
{
    private static double balance = 1000.00;

    public static void Run()
    {
        Console.WriteLine("Grace C. Galua");
        Console.WriteLine("=== Simple ATM System ===\n");
        Console.WriteLine("Initial Balance: ₱" + balance.ToString("F2"));

        while (true)
        {
            DisplayMenu();
            int choice = GetMenuChoice();

            switch (choice)
            {
                case 1:
                    double currentBalance = BankingService.CheckBalance(balance);
                    ShowBalance(currentBalance);
                    break;

                case 2:
                    double depositAmount = GetDepositAmount();
                    if (depositAmount <= 0)
                    {
                        ShowInvalidDeposit();
                        continue;
                    }
                    BankingService.Deposit(ref balance, depositAmount);
                    ShowDepositSuccess(balance);
                    break;

                case 3:
                    double withdrawAmount = GetWithdrawAmount();
                    if (withdrawAmount <= 0)
                    {
                        ShowInvalidWithdrawal();
                        continue;
                    }
                    bool success;
                    BankingService.Withdraw(ref balance, withdrawAmount, out success);
                    if (success)
                        ShowWithdrawalSuccess(balance);
                    else
                        ShowInsufficientBalance();
                    break;

                case 4:
                    BankingService.PrintMiniStatement(balance);
                    break;

                case 5:
                    ShowExitMessage();
                    return;

                default:
                    ShowInvalidOption();
                    break;
            }
        }
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("\nATM Menu:");
        Console.WriteLine("1: Check Balance");
        Console.WriteLine("2: Deposit Money");
        Console.WriteLine("3: Withdraw Money");
        Console.WriteLine("4: Print Mini Statement");
        Console.WriteLine("5: Exit");
        Console.Write("Select an option: ");
    }

    public static int GetMenuChoice()
    {
        int choice;
        int.TryParse(Console.ReadLine(), out choice);
        return choice;
    }

    public static void ShowBalance(double balance)
    {
        Console.WriteLine("Current Balance: ₱" + balance.ToString("F2"));
    }

    public static double GetDepositAmount()
    {
        Console.Write("Enter amount to deposit: ");
        double amount;
        double.TryParse(Console.ReadLine(), out amount);
        return amount;
    }

    public static void ShowDepositSuccess(double balance)
    {
        Console.WriteLine("Deposit successful.");
        Console.WriteLine("Updated Balance: ₱" + balance.ToString("F2"));
    }

    public static void ShowInvalidDeposit()
    {
        Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
    }

    public static double GetWithdrawAmount()
    {
        Console.Write("Enter amount to withdraw: ");
        double amount;
        double.TryParse(Console.ReadLine(), out amount);
        return amount;
    }

    public static void ShowWithdrawalSuccess(double balance)
    {
        Console.WriteLine("Withdrawal successful.");
        Console.WriteLine("Updated Balance: ₱" + balance.ToString("F2"));
    }

    public static void ShowInvalidWithdrawal()
    {
        Console.WriteLine("Invalid withdrawal amount. Please enter a positive value.");
    }

    public static void ShowInsufficientBalance()
    {
        Console.WriteLine("Withdrawal failed. Insufficient balance.");
    }

    public static void ShowInvalidOption()
    {
        Console.WriteLine("Invalid option selected. Please try again.");
    }

    public static void ShowExitMessage()
    {
        Console.WriteLine("Thank you for using the ATM. Goodbye!");
    }
}
}
