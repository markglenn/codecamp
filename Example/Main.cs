using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Example
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            // Prime up the threads
            LockedParallelFor( );

            Console.WriteLine( "Non parallel for: {0}", TimeMethod( ( ) => NonParallelFor( ) ) );
            Console.WriteLine( "Locked Parallel.For: {0}", TimeMethod( ( ) => LockedParallelFor( ) ) );
            Console.WriteLine( "Parallel.For: {0}", TimeMethod( ( ) => ParallelFor( ) ) );
        }

        static double TimeMethod( Action action )
        {
            Stopwatch stopwatch = Stopwatch.StartNew( );
            action( );
            return stopwatch.ElapsedMilliseconds / 1000.0;
        }

        static IEnumerable<int> ParallelFor( )
        {
            var primes = new ConcurrentQueue<int>( );

            Parallel.For( 0, 5000000, ( i ) => {
                if ( Prime.IsPrime( i ) )
                    primes.Enqueue( i );
            });

            return primes;
        }

        static IEnumerable<int> NonParallelFor( )
        {
            var primes = new Queue<int>( );

            for( int i = 0; i < 5000000; ++i )
            {
                if ( Prime.IsPrime( i ) )
                    primes.Enqueue( i );
            }

            return primes;
        }

        static IEnumerable<int> LockedParallelFor( )
        {
            var primes = new Queue<int>( );

            Parallel.For( 0, 5000000, ( i ) => {
                if ( Prime.IsPrime( i ) )
                {
                    lock( primes )
                    {
                        primes.Enqueue( i );
                    }
                }
            });

            return primes;
        }
    }
}
