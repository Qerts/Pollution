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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pollution
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Testovací metoda
        /// </summary>
        public static void test() 
        {
            int num = new Random().Next(0, 5);
            switch(num%8)
            {
                case 0:
                    moodizeGrid(StatusColor.Status.VeryGood, "Lothlórien");
                    break;
                case 1:
                    moodizeGrid(StatusColor.Status.Good, "Lothlórien");
                    break;
                case 2:
                    moodizeGrid(StatusColor.Status.Satisfying, "Lothlórien");
                    break;
                case 3:
                    moodizeGrid(StatusColor.Status.Suitable, "Lothlórien");
                    break;
                case 4:
                    moodizeGrid(StatusColor.Status.Bad, "Lothlórien");
                    break;
                case 5:
                    moodizeGrid(StatusColor.Status.VeryBad, "Lothlórien");
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
            gridInit();
            gridFullfill();
            leftPanelInit();
            rightPanelInit();
        }



    }
}
