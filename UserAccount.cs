using System;

public class UserAccount
{
    private string _password;
    private decimal _balance;


    public string AccountId { get; init; }

 
    public string Username { get; set; }


    public string Password
    {
        set
        {
            _password = "[ENCRYPTED]_" + value;
        }
    }


    public decimal Balance
    {
        get
        {
            return _balance;
        }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error: Balance cannot be negative!");
            }
            else
            {
                _balance = value;
            }
        }
    }


    public bool IsVIP => Balance >= 10000;

    public DateTime CreatedDate { get; }

    public UserAccount()
    {
        CreatedDate = DateTime.Now;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // --- TEST HARNESS ---

            // 1. Test Object Initialization & Init-Only Property
            UserAccount user = new UserAccount
            {
                AccountId = "ACC-99201",
                Username = "Alice_Code",
                Password = "SuperSecretPassword123"
            };

            // Attempting to modify AccountId after creation should fail compilation!
            // user.AccountId = "ACC-00000"; // UNCOMMENT TO VERIFY COMPILER ERROR

            Console.WriteLine($"Account ID: {user.AccountId}");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Account Created: {user.CreatedDate}");

            // 2. Test Write-Only Property
            // Attempting to read Password should fail compilation!
            // Console.WriteLine(user.Password); // UNCOMMENT TO VERIFY COMPILER ERROR

            // 3. Test Full Property Validation
            Console.WriteLine("\n--- Testing Balance Updates ---");
            user.Balance = 5000m;
            Console.WriteLine($"Current Balance: {user.Balance:C}");

            user.Balance = -200m; // Should display warning and ignore update
            Console.WriteLine($"Current Balance after invalid attempt: {user.Balance:C}");

            // 4. Test Computed Read-Only Property (IsVIP)
            Console.WriteLine($"\nIs VIP? {user.IsVIP}"); // Should be false ($5000 < $10000)

            user.Balance = 15000m;
            Console.WriteLine($"Updated Balance: {user.Balance:C}");
            Console.WriteLine($"Is VIP now? {user.IsVIP}"); // Should be true ($15000 >= $10000)
        }
    }
}