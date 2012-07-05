using System;
using System.Threading;
using System.IO;

namespace CodeCamp
{
    public class Counter
    {
        private static int count = 0;
        private static object lockObject = new object( );

        private static void ThreadMain( )
        {
            for ( int i = 0; i < 1000000; ++i ) {
                lock( lockObject )
                    count++;
            }
        }

        public static void Main (string[] args)
        {
            Thread thread1 = new Thread( ThreadMain );
            Thread thread2 = new Thread( ThreadMain );

            File.ReadAllLines( "example.txt" );

            thread1.Start( );
            thread2.Start( );

            thread1.Join( );
            thread2.Join( );

            Console.WriteLine( "Resulting Counter: {0}", count );
            Console.ReadLine( );
        }
    }
}
