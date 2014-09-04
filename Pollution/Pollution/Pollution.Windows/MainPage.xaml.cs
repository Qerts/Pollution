using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Pollution;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media.Animation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pollution
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Testovací metoda pro animace
        /// </summary>
        public static void animateBigStatus() 
        {
            Rectangle myRectangle = new Rectangle();
            myRectangle.Width = 200;
            myRectangle.Height = 200;
            Color myColor = Color.FromArgb(255, 255, 0, 0);
            SolidColorBrush myBrush = new SolidColorBrush();
            myBrush.Color = myColor;
            myRectangle.Fill = myBrush;

            // Add the rectangle to the tree.
            RightPanel.Children.Add(myRectangle);

            // Create a duration of 2 seconds.
            Duration duration = new Duration(TimeSpan.FromSeconds(2));

            // Create two DoubleAnimations and set their properties.
            DoubleAnimation myDoubleAnimation1 = new DoubleAnimation();
            DoubleAnimation myDoubleAnimation2 = new DoubleAnimation();

            myDoubleAnimation1.Duration = duration;
            myDoubleAnimation2.Duration = duration;

            Storyboard sb = new Storyboard();
            sb.Duration = duration;

            sb.Children.Add(myDoubleAnimation1);
            sb.Children.Add(myDoubleAnimation2);

            Storyboard.SetTarget(myDoubleAnimation1, myRectangle);
            Storyboard.SetTarget(myDoubleAnimation2, myRectangle);

            // Set the attached properties of Canvas.Left and Canvas.Top
            // to be the target properties of the two respective DoubleAnimations.
            Storyboard.SetTargetProperty(myDoubleAnimation1, "(Canvas.Left)");
            Storyboard.SetTargetProperty(myDoubleAnimation2, "(Canvas.Top)");

            myDoubleAnimation1.To = 200;
            myDoubleAnimation2.To = 200;

            // Make the Storyboard a resource.
            RightPanel.Resources.Add("unique_id", sb);

            // Begin the animation.
            sb.Begin();
        }

        /// <summary>
        /// Testovací metoda
        /// </summary>
        public static void test() 
        {
            int num = new Random().Next(0, 5);
            switch(num%8)
            {
                case 0:
                    moodizeGrid(StatusColor.Status.VeryGood);
                    break;
                case 1:
                    moodizeGrid(StatusColor.Status.Good);
                    break;
                case 2:
                    moodizeGrid(StatusColor.Status.Satisfying);
                    break;
                case 3:
                    moodizeGrid(StatusColor.Status.Suitable);
                    break;
                case 4:
                    moodizeGrid(StatusColor.Status.Bad);
                    break;
                case 5:
                    moodizeGrid(StatusColor.Status.VeryBad);
                    break;
                    /*
                case 6:
                    tileCollection.ElementAt(24).mainStatusTile("hello there",new SolidColorBrush(Color.FromArgb(255, 143, 143, 143)),"Assets/Smiley1.gif");
                    break;
                case 7:
                    tileCollection.ElementAt(24).mainStatusTile("hello there", new SolidColorBrush(Color.FromArgb(255, 138, 137, 156)), "Assets/Smiley1.gif");
                    break;*/
                
            }
            
            
        }
        
        
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Data.setStatuses();
            gridInit();
            gridFullfill();
            leftPanelInit();
            rightPanelInit();
        }




    }
}
