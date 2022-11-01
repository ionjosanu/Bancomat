using Bancomat;
Console.WriteLine("Wellcome to Qubiz ATM." +
    "\n\n - Press 1 to Insert Card." +
    "\n - Press 2 to Withdraw Card." +
    "\n - Press 3 to Block Card." +
    "\n - Press 0 to Exit.");
ATM atm = new ATM(6745,2500);
atm.Bills.Add(new Bill(1, 24));
atm.Bills.Add(new Bill(2, 30));
int input = int.Parse(Console.ReadLine());
switch (input)
{
    case 1:
       atm.InsertCard();
        break;

    case 2:
        atm.WithdrawCard();
        break;
    case 3:
        atm.BlockCard();
        break;
    case 0:
        Console.WriteLine("Thank you for utilizing Qubiz ATM. Have a nice day!");
        break;
    default:
        Console.WriteLine("You pressed a wrong button! Try again.");
        break;
}


Console.ReadKey();
