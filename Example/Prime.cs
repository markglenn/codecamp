using System;

namespace Example
{
    public static class Prime
    {
        public static bool IsPrime( int value )
        {
            if ( value < 3 )
                return value == 2;

            if ( value % 2 == 0 )
                return false;

            int max = ( int )Math.Sqrt( value ) + 1;
            for ( int i = 3; i <= max; i += 2 )
            {
                if ( value % i == 0 )
                    return false;
            }

            return true;
        }
    }
}

