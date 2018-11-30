using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RNA_Folding
{
    //The Main class that does most of everthing, such as the Base production, and the Pairing of Bases
    public class Main 
    {
        //MainWindow so we can deal with graphics and change what's on the screen
        private MainWindow mainWindow;
        //String storage
        private String RNAString, searchString;
        //Stores the bases 
        private Base[] bases;
        //Size of the display, cannot be changed (i.e FINAL)
        private readonly int WIDTH, HEIGHT;
        //Radius of the circle, will be set to depend on RNA Length
        private readonly int RADIUS;

        public Main(String s, MainWindow mw, int r)
        {
            RNAString = s;
            mainWindow = mw;
            HEIGHT = (int) mw.Stack_Panel.Height;
            WIDTH = (int) mw.Stack_Panel.Width;
            bases = new Base[RNAString.Length];
            RADIUS = r;
            Process();
        }

        //Process the RNAString and draws the structure, will also generate the Base pairs
        public void Process()
        {
            //Create bases
            CreateBases();

            //Display bases
            DisplayBases();
        }

        public Base[] GetBases()
        {
            return bases;
        }

        public void SearchForString(String s)
        {
            //Remove all currently highlighted bases
            searchString = s;
            foreach (Base b in bases)
            {
                b.SetIsHightlighted(false);
            }
            List<int> basesToHighlight = new List<int>();
            char[] chars = s.ToCharArray();
            //Search for the subsequence
            for (int i = 0; i <= bases.Length - chars.Length; i++)
            {
                Base b = bases[i];
                for (int j = 0; j < chars.Length; j++)
                {
                    if (b.GetBaseType() == chars[j])
                    {
                        basesToHighlight.Add(b.GetID() - 1);
                    }
                    if(b.GetID() != bases.Length)
                    {
                        b = bases[b.GetID()];
                    }
                }
                if (basesToHighlight.Count == chars.Length)
                {
                    foreach(int t in basesToHighlight)
                    {
                        bases[t].SetIsHightlighted(true);
                    }
                }
                basesToHighlight.Clear();
            }
            //Redraw the bases
            DisplayBases();
        }

        //Returns a base if there is any
        public Base SearchForBase(int x, int y)
        {
            Base baseToReturn = null;
            foreach(Base b in bases)
            {
                //If X and Y are similar to b.X and b.Y 
                if ((b.GetX() / RADIUS) == (x / RADIUS) && (b.GetY() / RADIUS) == (y / RADIUS))
                {
                    baseToReturn = b;
                    break;
                }
            }
            return baseToReturn;
        }

        public void ChangeBaseType(int i, Char c)
        {
            bases[i].SetBaseType(c);
            if (searchString != null)
            {
                SearchForString(searchString);
            }
            else
            {
                DisplayBases();
            }
        }

        //Method to create the Bases
        public void CreateBases()
        {
            //Need to some sort of method to make circles form a circle
            int j = 0, i = 0;
            for (int s = 0; s < RNAString.Length; s++)
            {
                //Populates the display with bases going right then down
                if (i != 0 && (i * RADIUS) > WIDTH)
                {
                    j++;
                    i = 0;
                }

                //Base(X, Y, Type, ID)
                bases[s] = new Base((i * RADIUS) % WIDTH, (j * RADIUS), RNAString[s], s + 1);
                i++;
            }
        }

        //Method to draw the bases to the screen
        public void DisplayBases()
        {
            mainWindow.DrawBases(bases);
        }
    }
}
