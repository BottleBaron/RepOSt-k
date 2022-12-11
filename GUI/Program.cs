internal class Program
{
    private static void Main(string[] args)
    {
        Controller inputController = new();

        Console.Clear();
        Console.Write("Welcome to RepOStök. Press any key to continue:");
        Console.ReadKey();


        while (true)
        {
            Console.Clear();
            Console.Write("1.) Log in as landlord \n2.) Log in as tenant \nQ.) Quit \n:");
            var keyPress = Console.ReadKey(true);

            switch (keyPress.Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.Clear();
                        Console.Write("Please enter your username:");
                        string? loginNameInput = Console.ReadLine();
                        Console.Write("Please enter your password:");
                        string? passwordInput = Console.ReadLine();

                        Landlord activeLandlord = inputController.TryLogin(loginNameInput, passwordInput);

                        if (activeLandlord != null)
                        {
                            LandlordGUI landlordGUI = new();
                            landlordGUI.MainMenu(activeLandlord);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input. Heading back to main menu:");
                            Console.ReadKey();
                        }

                        break;
                    }

                case ConsoleKey.D2:
                    {
                        Console.Clear();
                        Console.Write("Please enter your tenant id:");
                        string? tenantIdInput = Console.ReadLine();

                        int parsedInput = inputController.TryIntConversion(tenantIdInput);
                        Tenant activeTenant = inputController.TryLogin(parsedInput);

                        if (activeTenant != null)
                        {
                            TenantGUI tenantGUI = new();
                            tenantGUI.MainMenu(activeTenant);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input. Heading back to main menu:");
                            Console.ReadKey();
                        }

                        break;
                    }

                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
        }
    }


}