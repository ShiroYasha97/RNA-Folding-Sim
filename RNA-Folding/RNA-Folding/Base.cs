using System;

namespace RNA_Folding
{
    //Class for the Nitrogenous Bases
    public class Base
    {
        //X-Y Coordinates
        private int myX, myY;
        //Type of Base (A U G C)
        private Char myType;
        //The Base it will attach to if there is one
        private Base myPair;

        //Constructor
        public Base(int x, int y, Char t)
        {
            SetX(x);
            SetY(y);
            SetBaseType(t);
        }

        // ***Setters*** //

        //Sets the X-Coordinate of the Base
        public void SetX(int x)
        {
            myX = x;
        }

        //Sets the Y-Coordinate of the Base
        public void SetY(int y)
        {
            myY = y;
        }

        //Set the Base's type
        public void SetBaseType(Char t)
        {
            myType = t;
        }

        //Set the Base that it will join to
        public void SetBasePair(Base b)
        {
            myPair = b;
        }

        // ***Getters*** //

        //Gets the X-Coordinate of the Base
        public int GetX()
        {
            return myX;
        }

        //Gets the Y-Coordinate of the Base
        public int GetY()
        {
            return myY;
        }

        //Get the Base's type (A U G C)
        public Char GetBaseType()
        {
            return myType;
        }

        //Return the Base it will be paired with, if there is one
        public Base GetBasePair()
        {
            return myPair;
        }
    }
}
