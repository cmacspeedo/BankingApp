public class cardHolder
{
    private double balance;
    private string cardNum;
    private string firstName;
    private string lastName;
    private int pin;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    //GETTERS

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }


    //SETTERS

    public void setNum(string newCardnum)
    {
        cardNum = newCardnum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        cardHolder currentUser;

        //Console.WriteLine(currentUser.getFirstName());

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            var depositNum = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + depositNum);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            var withdrawal = double.Parse(Console.ReadLine());
            //Check if the user has enough $$
            if (currentUser.getBalance() > withdrawal)
            {
                Console.WriteLine("Insufficient funds available");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Wonderful! You're good to go! ");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        var cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1234", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("2345", 2345, "Cody", "Mac", 234.55));
        cardHolders.Add(new cardHolder("3456", 3456, "Homey", "Jones", 456.78));
        cardHolders.Add(new cardHolder("4567", 4567, "Fue", "Bar", 567.90));
        cardHolders.Add(new cardHolder("5678", 5678, "Jane", "Doe", 67.80));
        //Console.WriteLine(cardHolders[0]);

        //User Promt

        Console.WriteLine("Welcome to SupeSimple ATM!");
        Console.WriteLine("Please input your debit card number:");
        var debitCardNum = "";


        while (true)
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                    break;
                Console.WriteLine("Card not recognized. Please try again");
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }

        Console.WriteLine(" Please enter your pin: ");
        var userPin = 0;
        while (true)
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //Check against db
                if (currentUser.getPin() == userPin)
                    break;
                Console.WriteLine("Incorrect Pin. Please try again");
            }
            catch
            {
                Console.WriteLine("Incorrect Pin. Please try again");
            }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " ;)");
        var option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
            }

            if (option == 1)
                deposit(currentUser);
            else if (option == 2)
                withdraw(currentUser);
            else if (option == 3)
                balance(currentUser);
            else if (option == 4)
                break;
            else
                option = 0;
        } while (option != 4);

        Console.WriteLine("Thank you! Have a nice day!");
    }
}
