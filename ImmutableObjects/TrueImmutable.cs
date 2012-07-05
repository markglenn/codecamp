using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ImmutableObjects
{
    public class Vector2
    {
        public readonly float x, y;

        public Vector2( float x, float y )
        {
            this.x = x;
            this.y = y;
        }

        public Vector2 Add( Vector2 other )
        {
            return new Vector2( x + other.x, y + other.y );
        }

        public Vector2 Scale( float operand )
        {
            return new Vector2( x * operand, y * operand );
        }
    }

    public class Matrix
    {
        public readonly Vector2[] Rows;

        public Matrix( Vector2 row1, Vector2 row2 )
        {
            Rows = new Vector2[]{ row1, row2 };
        }
    }

    public class ImmutableMatrix
    {
        public readonly Vector2[] rows;

        public ICollection<Vector2> Rows
        {
            get { return Array.AsReadOnly<Vector2>( rows ); }
        }

        public ImmutableMatrix( Vector2 row1, Vector2 row2 )
        {
            rows = new Vector2[]{ row1, row2 };
        }
    }

    class MainClass
    {
        public static void Main (string[] args)
        {
            Vector2 v = new Vector2( 1, 2 );
            Vector2 result = v.Scale( 3.0f );

            Matrix matrix = new Matrix( new Vector2( 1, 2 ), new Vector2( 3, 4 ) );
            matrix.Rows[ 1 ] = new Vector2( 5, 6 ); // Oops
        }
    }


}
