using System;

namespace RNA_Folding
{
    //Class for the Nitrogenous Bases
    public class Base
    {
        //X-Y Coordinates
        private int myX, myY;
        private int myID;
        private bool isHighlighted;
        //Type of Base (A U G C)
        private Char myType;
        //The Base it will attach to if there is one
        private Base myBasePair;
        //The previous and next element
        //(Previous will be null for first and Next will be null for Last)
        private Base previous, next;

        //Constructor
        public Base(int x, int y, Char t, int id)
        {
            SetX(x);
            SetY(y);
            SetBaseType(t);
            SetID(id);
            SetIsHightlighted(false);
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
        //This is public so we can change it later on
        public void SetBaseType(Char t)
        {
            myType = t;
        }

        //Sets the ID of this base, shouldn't be changed anywhere other than in itself
        private void SetID(int id)
        {
            myID = id;
        }

        public void SetIsHightlighted(bool b)
        {
            isHighlighted = b;
        }

        public void SetPreviousBase(Base p)
        {
            previous = p;
        }

        public void SetNextBase(Base n)
        {
            next = n;
        }

        //Set the Base that it will join to
        public void SetBasePair(Base b)
        {
            myBasePair = b;
        }


        public void RemoveBasePair()
        {
            myBasePair = null;
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

        //Return the ID of this base
        //This is the place in the RNA String
        public int GetID()
        {
            return myID;
        }

        public bool GetIsHighlighted()
        {
            return isHighlighted;
        }

        //Return the Base it will be paired with, if there is one
        public Base GetBasePair()
        {
            return myBasePair;
        }

        public Base GetNext()
        {
            return next;
        }

        public Base GetPrevious()
        {
            return previous;
        }
    }
}
