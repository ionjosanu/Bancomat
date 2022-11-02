using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bancomat
{
    internal class ATM
    {
        int pin;
        int balance;
        bool insertedCard = false;
        public List<Bill> Bills = new List<Bill>();
        List<string> Transactions = new List<string>();
        public ATM(int pin, int balance)
        {
            this.pin = pin;
            this.balance = balance;
        }
        public void InsertCard()
        {
            Console.Write("Enter your PIN : ");
            int insertedPIN = int.Parse(Console.ReadLine());
            if (insertedPIN == pin)
            {
                Console.WriteLine("Card inserted successfully!");
                OptionsAfterInsertion();
            }
            else
            {
                while (insertedPIN != pin)
                {
                    Console.WriteLine(" Incorrect PIN! Try again:");
                    insertedPIN = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Card inserted successfully!");
                insertedCard = true;
                OptionsAfterInsertion();
            }

        }
        public void OptionsAfterInsertion()
        {


            Console.WriteLine("Choose one of the options: \n " +
            "\n - Press 1 to Withdraw money." +
            "\n - Press 2 to Deposit money." +
            "\n - Press 3 to Pay bills." +
            "\n - Press 4 to Show Balance." +
            "\n - Press 0 to Exit.");
            int input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    WithdrawMoney();
                    AnotherTransaction();
                    break;
                case 2:
                    DepositMoney();
                    AnotherTransaction();
                    break;
                case 3:
                    PayBill();
                    AnotherTransaction();
                    break;
                case 4:
                    ShowBalance();
                    AnotherTransaction();
                    break;
                case 0:
                    Console.WriteLine("Thank you for utilizing Qubiz ATM! Have a nice day!");
                    break;
            }


        }


        private void ShowBalance()
        {
            Console.WriteLine($" Your balance is : {balance}$");
            Console.WriteLine("Transactions :");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        private void PayBill()
        {
            Console.Write("Insert the number of the bill to pay :");
            int input = int.Parse(Console.ReadLine());
            bool paid = false;
            foreach (var bill in Bills)
            {
                if (bill.Number == input && bill.Amount < balance)
                {
                    balance -= bill.Amount;
                    Transactions.Add($"Paye Bill {bill.Number} of {bill.Amount}$.");
                    Bills.Remove(bill);
                    paid = true;
                    break;
                }
            }
            if (!paid)
            {
                Console.WriteLine("The bill was paid or it does not exist!");
            }
            if (Bills.Count == 0)
            {
                Console.WriteLine("There are no more bills to pay!");
            }

        }

        private void DepositMoney()
        {
            Console.Write("Insert the amount of money you want to deposit : ");
            int input = int.Parse(Console.ReadLine());
            balance += input;
            Transactions.Add($"Deposited Money :{input}$");
        }

        private void AnotherTransaction()
        {
            Console.WriteLine("Would you like to do another transaction?(type yes or no).");
            string input = Console.ReadLine();
            if (input == "yes")
            {
                OptionsAfterInsertion();
            }
            else
            {
                Console.WriteLine("Bye!");
            }
        }

        private void WithdrawMoney()
        {
            Console.Write("Insert the amount of money you want to Withdraw : ");
            int input = int.Parse(Console.ReadLine());
            if (input > balance)
            {
                Console.WriteLine("Your balance does not have enough resources!");
            }
            else
            {
                balance -= input;
                Transactions.Add($"Withdrawed Money : -{input}$.");
            }
        }
        public void WithdrawCard()
        {
            if (insertedCard)
            {
                insertedCard = false;
                Console.WriteLine("Card has been withdrawed!");
            }
            else
            {
                Console.WriteLine("There is no inserted card to be withdrawn!");
            }
        }
        public void BlockCard()
        {
            if (insertedCard)
            {
                pin = 0;
                insertedCard = false;
                Console.WriteLine("Card has been blocked!");
            }
            else
            {
                Console.WriteLine("There is no inserted card to be blocked!");
            }
        }
    }
}
