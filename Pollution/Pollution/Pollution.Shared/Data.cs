﻿using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace Pollution
{
    public static class Data
    {
        private static int SO2_VALUE = 32;
        private static StatusColor.Status SO2_STATUS = new StatusColor.Status();
        private static int O3_VALUE = 54;
        private static StatusColor.Status O3_STATUS = new StatusColor.Status();
        private static int NO2_VALUE = 31;
        private static StatusColor.Status NO2_STATUS = new StatusColor.Status();
        private static int CO_VALUE = 3563;
        private static StatusColor.Status CO_STATUS = new StatusColor.Status();
        private static int PM10_VALUE = 75;
        private static StatusColor.Status PM10_STATUS = new StatusColor.Status();
        private static string STATION_NAME = "Ostrava-Fifejdy";
        private static string STATION_REGION = "Moravskoslezský kraj";
        private static string STATION_COORDS = "49°50'51\"N, 19°20'21\"E (+6 km)";

        public static int SO2 { set{ SO2_VALUE = value;} get{return SO2_VALUE;} }
        public static int O3 { set { O3_VALUE = value; } get { return O3_VALUE; } }
        public static int NO2 { set { NO2_VALUE = value; } get { return NO2_VALUE; } }
        public static int CO { set { CO_VALUE = value; } get { return CO_VALUE; } }
        public static int PM10 { set { PM10_VALUE = value; } get { return PM10_VALUE; } }
        public static string StationName { set { STATION_NAME = value; } get { return STATION_NAME; } }
        public static string StationRegion { set { STATION_REGION = value; } get { return STATION_REGION; } }
        public static string StationCoordinates { set { STATION_COORDS = value; } get { return STATION_COORDS; } }

        private static Tuple<SolidColorBrush,string> getColorAndStatus(StatusColor.Status value) 
        {
            switch (value) 
            {
                case StatusColor.Status.VeryGood:
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 0, 138, 0)), "velmi dobré");
                case StatusColor.Status.Good:
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 132, 161, 47)), "dobré");
                case StatusColor.Status.Satisfying:
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 184, 177, 0)), "uspokojivé");
                case StatusColor.Status.Suitable:
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 141, 19)), "vyhovující");
                case StatusColor.Status.Bad:
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 84, 23)), "špatné");
                case StatusColor.Status.VeryBad:
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 51, 27)), "velmi špatné");
                case StatusColor.Status.NoData:
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 143, 143, 143)), "nejsou data");
                case StatusColor.Status.NoMeasurement:
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 138, 137, 156)), "neměří se");
                default:
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 200, 200, 200)), "chyba");
            }
        }

        /// <summary>
        /// Tato funkce byla zamyslena takto:
        /// Funkce prevezme hodnoty jednotlivych slozek.
        /// Porovna je viz GetColorAndStatus funkce, dle skal jednotlivych slozek.
        /// Aktualizuje status slozky.
        /// Pri dotazu na slozku se tak staci zeptat na jeji status a vytahnout si barvu a string z tabulky.
        /// Tato tabulka jeste neexistuje.
        /// </summary>
        public static void setStatuses() 
        {
            int value = SO2_VALUE;
            if (value < 120)
            {
                if (value < 50)
                {
                    if (value < 25)
                    {
                        SO2_STATUS = StatusColor.Status.VeryGood;
                    }
                    else
                    {
                        SO2_STATUS = StatusColor.Status.Good;
                    }
                }
                else
                {
                    SO2_STATUS = StatusColor.Status.Satisfying;
                }
            }
            else
            {
                if (value < 350)
                {
                    SO2_STATUS = StatusColor.Status.Suitable;
                }
                else
                {
                    if (value < 500)
                    {
                        SO2_STATUS = StatusColor.Status.Bad;
                    }
                    else
                    {
                        SO2_STATUS = StatusColor.Status.VeryBad;
                    }
                }
            }

            value = O3_VALUE;
            if (value < 120)
            {
                if (value < 65)
                {
                    if (value < 33)
                    {
                        O3_STATUS = StatusColor.Status.VeryGood;
                    }
                    else
                    {
                        O3_STATUS = StatusColor.Status.Good;
                    }
                }
                else
                {
                        O3_STATUS = StatusColor.Status.Satisfying;
                }
            }
            else
            {
                if (value < 180)
                {
                        O3_STATUS = StatusColor.Status.Suitable;
                }
                else
                {
                    if (value < 240)
                    {
                        O3_STATUS = StatusColor.Status.Bad;
                    }
                    else
                    {
                        O3_STATUS = StatusColor.Status.VeryBad;
                    }
                }
            }

            value = NO2_VALUE;
            if (value < 100)
            {
                if (value < 50)
                {
                    if (value < 25)
                    {
                        NO2_STATUS = StatusColor.Status.VeryGood;
                    }
                    else
                    {
                        NO2_STATUS = StatusColor.Status.Good;
                    }
                }
                else
                {
                        NO2_STATUS = StatusColor.Status.Satisfying;
                }
            }
            else
            {
                if (value < 200)
                {
                        NO2_STATUS = StatusColor.Status.Suitable;
                }
                else
                {
                    if (value < 400)
                    {
                        NO2_STATUS = StatusColor.Status.Bad;
                    }
                    else
                    {
                        NO2_STATUS = StatusColor.Status.VeryBad;
                    }
                }
            }

            value = CO_VALUE;
            if (value < 4000)
            {
                if (value < 2000)
                {
                    if (value < 1000)
                    {
                        CO_STATUS = StatusColor.Status.VeryGood;
                    }
                    else
                    {
                        CO_STATUS = StatusColor.Status.Good;
                    }
                }
                else
                {
                        CO_STATUS = StatusColor.Status.Satisfying;
                }
            }
            else
            {
                if (value < 10000)
                {
                        CO_STATUS = StatusColor.Status.Suitable;
                }
                else
                {
                    if (value < 30000)
                    {
                        CO_STATUS = StatusColor.Status.Bad;
                    }
                    else
                    {
                        CO_STATUS = StatusColor.Status.VeryBad;
                    }
                }
            }

            value = PM10_VALUE;
            if (value < 70)
            {
                if (value < 40)
                {
                    if (value < 20)
                    {
                        PM10_STATUS = StatusColor.Status.VeryGood;
                    }
                    else
                    {
                        PM10_STATUS = StatusColor.Status.Good;
                    }
                }
                else
                {
                        PM10_STATUS = StatusColor.Status.Satisfying;
                }
            }
            else
            {
                if (value < 90)
                {
                        PM10_STATUS = StatusColor.Status.Suitable;
                }
                else
                {
                    if (value < 180)
                    {
                        PM10_STATUS = StatusColor.Status.Bad;
                    }
                    else
                    {
                        PM10_STATUS = StatusColor.Status.VeryBad;
                    }
                }
            }

        }

        public static Tuple<SolidColorBrush, string> GetSO2ColorAndStatus()
        {
            return getColorAndStatus(SO2_STATUS);
            

        }
        /*
        public static Tuple<SolidColorBrush,string> GetSO2ColorAndStatus() 
        {
            int value = SO2_VALUE;
            if (value < 120)
            {
                if (value < 50)
                {
                    if (value < 25)
                    {
                        //zbarvi se na velmi dobre
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 0, 138, 0)),"velmi dobré");                        
                    }
                    else
                    {
                        //zbarvi se na dobre
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 132, 161, 47)), "dobré");
                    }
                }
                else
                {
                    //zbarvi se na uspokojiva
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 184, 177, 0)), "uspokojivé");
                }
            }
            else
            {
                if (value < 350)
                {
                    //zbarvi se na vyhovujici
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 141, 19)), "vyhovující");
                }
                else
                {
                    if (value < 500)
                    {
                        //zbarvi se na spatna
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 84, 23)), "špatné");
                    }
                    else
                    {
                        //zbarvi se na velmi spatna
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 51, 27)), "velmi špatné");
                    }
                }
            }
            
        }
         * */
        public static Tuple<SolidColorBrush, string> GetO3ColorAndStatus() 
        {
            int value = O3_VALUE;

            if (value < 120)
            {
                if (value < 65)
                {
                    if (value < 33)
                    {
                        //zbarvi se na velmi dobre
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 0, 138, 0)), "velmi dobré");                        
                    }
                    else
                    {
                        //zbarvi se na dobre
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 132, 161, 47)), "dobré");
                    }
                }
                else
                {
                    //zbarvi se na uspokojiva
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 184, 177, 0)), "uspokojivé");
                }
            }
            else
            {
                if (value < 180)
                {
                    //zbarvi se na vyhovujici
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 141, 19)), "vyhovující");
                }
                else
                {
                    if (value < 240)
                    {
                        //zbarvi se na spatna
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 84, 23)), "špatné");
                    }
                    else
                    {
                        //zbarvi se na velmi spatna
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 51, 27)), "velmi špatné");
                    }
                }
            }

        }
        public static Tuple<SolidColorBrush, string> GetNO2ColorAndStatus() 
        {
            int value = NO2_VALUE;
            if (value < 100)
            {
                if (value < 50)
                {
                    if (value < 25)
                    {
                        //zbarvi se na velmi dobre
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 0, 138, 0)), "velmi dobré");
                    }
                    else
                    {
                        //zbarvi se na dobre
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 132, 161, 47)), "dobré");
                    }
                }
                else
                {
                    //zbarvi se na uspokojiva
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 184, 177, 0)), "uspokojivé");
                }
            }
            else
            {
                if (value < 200)
                {
                    //zbarvi se na vyhovujici
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 141, 19)), "vyhovující");
                }
                else
                {
                    if (value < 400)
                    {
                        //zbarvi se na spatna
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 84, 23)), "špatné");
                    }
                    else
                    {
                        //zbarvi se na velmi spatna
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 51, 27)), "velmi špatné");
                    }
                }
            }
        }
        public static Tuple<SolidColorBrush, string> GetCOColorAndStatus()
        {
            int value = CO_VALUE;
            if (value < 4000)
            {
                if (value < 2000)
                {
                    if (value < 1000)
                    {
                        //zbarvi se na velmi dobre
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 0, 138, 0)), "velmi dobré");
                    }
                    else
                    {
                        //zbarvi se na dobre
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 132, 161, 47)), "dobré");
                    }
                }
                else
                {
                    //zbarvi se na uspokojiva
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 184, 177, 0)), "uspokojivé");
                }
            }
            else
            {
                if (value < 10000)
                {
                    //zbarvi se na vyhovujici
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 141, 19)), "vyhovující");
                }
                else
                {
                    if (value < 30000)
                    {
                        //zbarvi se na spatna
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 84, 23)), "špatné");
                    }
                    else
                    {
                        //zbarvi se na velmi spatna
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 51, 27)), "velmi špatné");
                    }
                }
            }
        }
        public static Tuple<SolidColorBrush, string> GetPM10ColorAndStatus() 
        {
            int value = PM10_VALUE;
            if (value < 70)
            {
                if (value < 40)
                {
                    if (value < 20)
                    {
                        //zbarvi se na velmi dobre
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 0, 138, 0)), "velmi dobré");
                    }
                    else
                    {
                        //zbarvi se na dobre
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 132, 161, 47)), "dobré");
                    }
                }
                else
                {
                    //zbarvi se na uspokojiva
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 184, 177, 0)), "uspokojivé");
                }
            }
            else
            {
                if (value < 90)
                {
                    //zbarvi se na vyhovujici
                    return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 141, 19)), "vyhovující");
                }
                else
                {
                    if (value < 180)
                    {
                        //zbarvi se na spatna
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 84, 23)), "špatné");
                    }
                    else
                    {
                        //zbarvi se na velmi spatna
                        return Tuple.Create(new SolidColorBrush(Color.FromArgb(255, 207, 51, 27)), "velmi špatné");
                    }
                }
            }

        }

    }
}
