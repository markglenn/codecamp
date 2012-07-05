using System;

namespace DeadlockExample
{
    class Account
    {
        public double Balance { get; set; }

        public static void Transfer( Account from, Account to, double amount )
        {
            lock( from )
            lock( to )
            {
                from.Balance -= amount;
                to.Balance += amount;
            }
        }
    }

    class Deadlock
    {
        public static void Main (string[] args)
        {
            Account account1 = new Account{ Balance = 200.0 };
            Account account2 = new Account{ Balance = 200.0 };

            Account.Transfer( account1, account2, 100.0 ); // Thread 1
            Account.Transfer( account2, account1, 100.0 ); // Thread 2

            Console.WriteLine ( "Account 1: {0}, Account 2: {1}", account1.Balance, account2.Balance );
            Console.ReadLine( );
        }
    }
}
