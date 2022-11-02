using Bancomat;

ATM atm = new ATM(6745, 2500);
atm.Bills.Add(new Bill(1, 24));
atm.Bills.Add(new Bill(2, 30));

Engine(atm);

static void Engine(ATM atm)
{
    Console.WriteLine("\nWellcome to Qubiz ATM." +
    "\n\n - Press 1 to Insert Card." +
    "\n - Press 2 to Withdraw Card." +
    "\n - Press 3 to Block Card." +
    "\n - Press 0 to Exit.");
    int input = int.Parse(Console.ReadLine());
    switch (input)
    {
        case 1:
            atm.InsertCard();
            Engine(atm);
            break;

        case 2:
            atm.WithdrawCard();
            Engine(atm);
            break;
        case 3:
            atm.BlockCard();
            Engine(atm);
            break;
        case 0:
            Console.WriteLine("Thank you for utilizing Qubiz ATM. Have a nice day!");
            break;
        default:
            Console.WriteLine("You pressed a wrong button! Try again.");
            Engine(atm);
            break;
    }
}


Console.ReadKey();
