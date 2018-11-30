using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace RNA_Folding
{
    //MainWindow which will display everything
    public partial class MainWindow : Window
    {
        private Main m;
        private String rnaString, searchString;
        private char newBaseType;
        //Size of the display, cannot be changed (i.e FINAL)
        private readonly int HEIGHT, WIDTH;
        //Radius of the circle, will be set to depend on RNA Length
        private int RADIUS;

        public MainWindow()
        {
            InitializeComponent();
            HEIGHT = (int)Stack_Panel.Height;
            WIDTH = (int)Stack_Panel.Width;
            rnaString = "";
        }

        //When the Upload button is clicked
        private void Upload_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogWindow dw = new DialogWindow(this);
            dw.ShowDialog();
            dw.Close();
            //Send RNAString to Main
            //The larger the string, the smaller the radius
            RADIUS = 20;
            if (rnaString != "")
            {
                m = new Main(rnaString, this, RADIUS);
            }
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            //Will bring up another window just like Upload_Button
            searchString = "";
            SearchWindow sw = new SearchWindow(this);
            sw.ShowDialog();
            sw.Close();
            //Error handling
            if (m != null && searchString.Length <= rnaString.Length)
            {
                //Send the string to main to search for it and highlight them
                m.SearchForString(searchString);
            }
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
            rnaString = s;
        }

        public void ChangeBaseType(Char c)
        {
            newBaseType = c;
        }

        //This is how to get a Base on the Stack Panel
        private void Stack_Panel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Get the information of where the click happened
            Point p = e.GetPosition(this.Stack_Panel);
            int x = (int) p.X;
            int y = (int) p.Y;
            //MessageBox.Show("X: "+x+" Y:"+y);
            Base b;
            newBaseType = '\0';
            if (m != null)
            {
                b = m.SearchForBase(x, y);
                //MessageBox.Show("ID: " + b.GetID() + " Type: " + b.GetBaseType());
                BaseWindow bw = new BaseWindow(this, b);
                bw.ShowDialog();
                bw.Close();
                if (!newBaseType.Equals('\0'))
                {
                    StringBuilder str = new StringBuilder(rnaString);
                    str[b.GetID() - 1] = newBaseType;
                    rnaString = str.ToString();
                    m.ChangeBaseType(b.GetID() - 1, newBaseType);
                }
                //Create a new window BaseWindow(this, b) to display the following information
                //ID and type of base
                //Allow the user to change the type of base
            }
        }

        public void SetSearchString(String s)
        {
            searchString = s;
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
                        mySolidColorBrush.Color = Color.FromArgb(255, 0, 174, 255);
                        break;
                    //Black
                    default:
                        mySolidColorBrush.Color = Color.FromArgb(255, 0, 0, 0);
                        break;
                }
                e.Fill = mySolidColorBrush;
                //e.StrokeThickness = 3;
                double thickness = 0;
                if (b.GetIsHighlighted())
                {
                    thickness = 2;
                }
                e.StrokeThickness = thickness;
                e.Stroke = Brushes.Black;
                Canvas.SetLeft(e, b.GetX());
                Canvas.SetTop(e, b.GetY());
                root.Children.Add(e);

                //We will need to set the font size of the textblock based on RADIUS
                //This isn't perfect right now, but it displays it find right now
                TextBlock textBlock = new TextBlock();
                textBlock.Text = b.GetBaseType().ToString();
                textBlock.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
                Canvas.SetLeft(textBlock, b.GetX() + 5.7);
                Canvas.SetTop(textBlock, b.GetY() + 2.2);
                root.Children.Add(textBlock);

                //Everything is added to the canvas, which is added to the Stack Panel
                Stack_Panel.Children.Add(root);
            }
        }
    }
}
