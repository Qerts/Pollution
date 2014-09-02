using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Pollution
{
    public class StatusColor
    {

        public enum Status
        {
            NoData,
            NoMeasurement,
            VeryBad,
            Bad,
            Suitable,
            Satisfying,
            Good,
            VeryGood


        }
        private SolidColorBrush myBrush;
        private string uri;

        public SolidColorBrush getBrush() 
        {
            return this.myBrush;
        }

        public string getUri()
        {
            return this.uri;
        }

        


        public StatusColor(Status status) 
        {
            switch (status) 
            {
                case Status.NoData:
                    uri = @"Assets/Smiley0.gif";
                    break;
                case Status.NoMeasurement:
                    uri = @"Assets/Smiley1.gif";
                    break;
                case Status.VeryBad:
                    myBrush = new SolidColorBrush(Color.FromArgb(255, 207, 51, 27));
                    uri = @"Assets/Smiley2.gif";
                    break;
                case Status.Bad:
                    myBrush = new SolidColorBrush(Color.FromArgb(255, 207, 84, 23));
                    uri = @"Assets/Smiley3.gif";
                    break;
                case Status.Suitable:
                    myBrush = new SolidColorBrush(Color.FromArgb(255, 207, 141, 19));
                    uri = @"Assets/Smiley4.gif";
                    break;
                case Status.Satisfying:
                    myBrush = new SolidColorBrush(Color.FromArgb(255, 184, 177, 0));
                    uri = @"Assets/Smiley5.gif";
                    break;
                case Status.Good:
                    myBrush = new SolidColorBrush(Color.FromArgb(255, 132, 161, 47));
                    uri = @"Assets/Smiley6.gif";
                    break;
                case Status.VeryGood:
                    myBrush = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
                    uri = @"Assets/Smiley7.gif";
                    break;
                default:
                    break;

            }
        }
    }
}
