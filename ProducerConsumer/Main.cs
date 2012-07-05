using System;
using System.Linq;

using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace ProducerConsumer
{
    class MainClass
    {
        static void ThreadedExample ()
        {
            BlockingCollection<int> bc = new BlockingCollection<int>();

            // Spin up a Task to populate the BlockingCollection
            Thread producer = new Thread( ( ) => {
                bc.Add(0);
                bc.Add(1);
                bc.Add(2);
                bc.CompleteAdding();
            });

            Thread consumer = new Thread( ( ) => {
                // Spin up a Task to consume the BlockingCollection
                try
                {
                    // Consume bc
                    while (true) Console.WriteLine(bc.Take());
                }
                catch (InvalidOperationException)
                {
                    // IOE means that Take() was called on a completed collection
                    Console.WriteLine("That's All!");
                }
            });

            producer.Start( );
            consumer.Start( );
            producer.Join( );
            consumer.Join( );
        }

static void TaskExample( )
{
	var options = TaskCreationOptions.AttachedToParent;
    var producer = Task.Factory.StartNew( () => {
        Task.Factory.StartNew( () => 
			Console.WriteLine( 0 ), options );
        Task.Factory.StartNew( () => 
			Console.WriteLine( 1 ), options );
        Task.Factory.StartNew( () => 
			Console.WriteLine( 2 ), options );
    });

    producer.Wait( );
}

        public static void Main (string[] args)
        {
            TaskExample();

            Console.ReadLine( );
        }
    }
}
