using System;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FutureExample
{
    class MainClass
    {
        static void ThreadExample( )
        {
            string result = "";
            Object lockObject = new Object( );

            var thread = new Thread ( ( ) => {
                lock (lockObject)
                    result = "Hello World!";
            });

            thread.Start ();
            thread.Join ();

            Console.WriteLine( result );
        }

        public static void Main (string[] args)
        {
            var task = Task.Factory.StartNew<string>( ( ) => {
                return "Hello World!";
            });

            Console.WriteLine( task.Result );

            Console.ReadLine( );
        }
    }
}
