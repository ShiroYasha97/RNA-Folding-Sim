using System;
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
        private String RNAString;
        //Stores the bases 
        private Base[] bases;
        //Size of the display, cannot be changed (i.e FINAL)
        private readonly int WIDTH = 500, HEIGHT = 450;
        //Radius of the circle, will be set to depend on RNA Length
        private int RADIUS = 25;

        public Main(String s, MainWindow mw)
        {
            RNAString = s;
            mainWindow = mw;
            bases = new Base[RNAString.Length];
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

        //Method to create the Bases
        public void CreateBases()
        {
            //Need to some sort of method to make circles form a circle
            int j = 0, i = 0;
            for (int s = 0; s < RNAString.Length; s++)
            {
                //Populates the display with bases going right then down
                if (i != 0 && (i * 25) % WIDTH == 0)
                    j++;
                if (j != 0 && (j * 25) % HEIGHT == 0)
                    i = 0;

                //Base(X, Y, Type)
                //bases[s] = CreateCircleBase(i, j, s, RNAString);
                bases[s] = new Base((i * RADIUS) % WIDTH, (j * RADIUS), RNAString[s]);
                i++;
            }
        }

        //Method to determine where a circle needs to go in order to create a proper circle
        //Name could probably change to make more sense
        //I'll leave this for someone else to figure out
        public Base CreateCircleBase(int i, int j, int location, String s)
        {
            //Location is where we currently are in the string
            return new Base((i * RADIUS) % WIDTH, (j * RADIUS), s[location]);
        }

        //Method to draw the bases to the screen
        public void DisplayBases()
        {
            mainWindow.DrawBases(bases);
        }
    }
}
