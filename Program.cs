using ATM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{

    public class BankAcc
    {

        public int AccNo;
        public int PinNo;
        public double CurrentBalance;

        public void getAccNo()
        {
            Console.WriteLine("Account Number:");
            AccNo = Convert.ToInt32(Console.ReadLine());
          
        }
    }

    public class Pin : BankAcc
    {
        public int PinNo;
        public void getPinNo()
        {
            Console.WriteLine(" Pin Number:");
            PinNo = Convert.ToInt32(Console.ReadLine());
            if(PinNo <= 9999 && PinNo >=1000) 
            { 
            
            }
            if (PinNo <= 99999 && PinNo >= 10000)

            {
                Console.WriteLine(" Your Pin Number Must Be Four Digit");
                return;
            }
        }
        


    }
    public class Balance : Pin {

        public double CurrentBalance;

        public void getBalance()
        {
             
            Console.WriteLine("Available Balance:" + CurrentBalance);

        }

    }
    public class Deposit : Balance
    {
        public double DepositAmt;
        public void getDeposit()
        {
            Console.WriteLine("Deposit Amount:");
            DepositAmt = Convert.ToDouble(Console.ReadLine());

            CurrentBalance = CurrentBalance + DepositAmt;
            Console.WriteLine("Deposited Amount:" + DepositAmt);
        }


    }

    public class Withdraw : Deposit
    {
        public double WithdrawAmt;

        public void getWithdrawAmt()
        {
            Console.WriteLine("Withdraw Amount:");
            WithdrawAmt = Convert.ToDouble(Console.ReadLine());

            if (WithdrawAmt < CurrentBalance)
            {
                CurrentBalance = CurrentBalance - WithdrawAmt;
                Console.WriteLine("Debited Amount:" + WithdrawAmt);
            } 
            
            else
            {
                Console.WriteLine("Insufficient Balance");
                return;
            }
        }
    }




    internal class Program
    {
        static void Main(string[] args)
        {

            Withdraw acc = new Withdraw();
            acc.getAccNo();
            acc.getPinNo();
            acc.getBalance();
            acc.getDeposit();
            acc.getWithdrawAmt();

            Console.WriteLine(" 1.Deposit Cash");
            Console.WriteLine(" 2.Withdraw");
            Console.WriteLine(" 3.Balance");
            Console.WriteLine(" 4. Quit");

            bool continueCalculating = true;

            do
            {

                Console.WriteLine("ENTER YOUR CHOICE");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        acc.getDeposit();
                        break;
                    case 2:
                        acc.getWithdrawAmt();

                        break;
                    case 3:
                        acc.getBalance();
                        break;
                    case 4:
                        if (choice == 4)
                        {
                            return;
                        }
                        break;

                }
            } while (continueCalculating);

        
            }

      
        }
    }
