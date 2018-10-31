using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Drawing;
using System.Globalization;

namespace RNA_Folding
{
    //MainWindow which will display everything
    public partial class MainWindow : Window
    {
        private Main m;
        private String RNAString;
        //Size of the display, cannot be changed (i.e FINAL)
        private readonly int HEIGHT = 450, WIDTH = 500;
        //Radius of the circle, will be set to depend on RNA Length
        private int RADIUS = 25;
        public MainWindow()
        {
            InitializeComponent();
        }

        //When the Select button is hit
        private void Select_Item_Button_Click(object sender, RoutedEventArgs e)
        {
            //No functionality right now
            //Takes the selected item in the list and creates the structure
            switch (List_Box.SelectedIndex)
            {
                case 0:
                    //Create a hairpin structure using a predetermined RNA sequence
                    MessageBox.Show("Hairpin");
                    break;
                case 1:
                    break;
                default:
                    MessageBox.Show("Text");
                    break;
            }
        }

        //When the Upload button is clicked
        private void Upload_Button_Click(object sender, RoutedEventArgs e)
        {
            RNAString = "";
            DialogWindow dw = new DialogWindow(this);
            dw.ShowDialog();
            dw.Close();
            //Send RNAString to Main
            if(!RNAString.Equals(null))
                m = new Main(RNAString, this);
        }

        //When the Next button is clicked
        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            //No functionality right now
            //Creates the new structure
            if (Next_Button.Content.Equals("Next"))
                Next_Button.Content = "Back";
            else
                Next_Button.Content = "Next";
        }

        //Method to display and remove lines from the view
        private void Line_Button_Click(object sender, RoutedEventArgs e)
        {
            //No funtionality right now
            if (Line_Button.Content.Equals("Disable Lines"))
                Line_Button.Content = "Enable Lines";
            else
                Line_Button.Content = "Disable Lines";
        }

        //Method to set the RNAString from the DialogWindow
        public void SetRNAString(String s)
        {
            RNAString = s;
        }

        //Method to draw the bases, won't need change other than adding more graphics (i.e printing AUGC on the base)
        public void DrawBases(Base[] bases)
        {
            //Clear everthing on the display before doing anything
            Stack_Panel.Children.Clear();
            foreach (Base b in bases)
            {
                Ellipse e = new Ellipse();
                Canvas root = new Canvas();
                SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                //e.HorizontalAlignment = HorizontalAlignment.Left;
                //e.VerticalAlignment = VerticalAlignment.Center;
                //Will be a function of the number of elements in b
                e.Width = RADIUS;
                e.Height = RADIUS;
                switch (b.GetBaseType().ToString())
                {
                    //Red
                    case "A":
                        mySolidColorBrush.Color = Color.FromArgb(255, 255, 0, 0);
                        break;
                    //Orange
                    case "U":
                        mySolidColorBrush.Color = Color.FromArgb(255, 255, 128, 0);
                        break;
                    //Green
                    case "G":
                        mySolidColorBrush.Color = Color.FromArgb(255, 0, 172, 0);
                        break;
                    //Blue
                    case "C":
                        mySolidColorBrush.Color = Color.FromArgb(255, 0, 0, 255);
                        break;
                    //Black
                    default:
                        mySolidColorBrush.Color = Color.FromArgb(255, 0, 0, 0);
                        break;
                }
                e.Fill = mySolidColorBrush;
                e.StrokeThickness = 2;
                e.Stroke = Brushes.Black;
                Canvas.SetLeft(e, b.GetX());
                Canvas.SetTop(e, b.GetY());
                root.Children.Add(e);

                //We will need to set the font size of the textblock based on RADIUS
                //This isn't perfect right now, but it displays it find right now
                TextBlock textBlock = new TextBlock();
                textBlock.Text = b.GetBaseType().ToString();
                textBlock.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                Canvas.SetLeft(textBlock, b.GetX() + 8.5);
                Canvas.SetTop(textBlock, b.GetY() + 4);
                root.Children.Add(textBlock);

                //Everything is added to the canvas, which is added to the Stack Panel
                Stack_Panel.Children.Add(root);
            }
        }
    }
}
