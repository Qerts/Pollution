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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using Pollution;

namespace Pollution
{
    
    public static class CanvasToTileExtension 
    {



        public static Canvas testTile(this Canvas tile) 
        {
            tile.Tapped += testTileTapped;

            TextBlock txt = new TextBlock();
            txt.Text = "click here for random status change";
            txt.Width = Window.Current.Bounds.Height / 6;
            txt.TextWrapping = TextWrapping.WrapWholeWords;
            tile.Children.Add(txt);



            return tile;
        }

        static void testTileTapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage.test();
        }


        /// <summary>
        /// Funkce pro prazdny tile. Nastavuje se jen barva a vyclearuji se potomci.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static Canvas blankTile(this Canvas tile, SolidColorBrush brush)
        {
            tile.Background = brush;
            tile.Name = "blankTile";
            tile.Children.Clear();
            tile.Opacity = 1;
            return tile;
        }
       
        
        /// <summary>
        /// Tile obsahujici nejaky obrazek. Obrazek je nastaven na UniformToFill.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static Canvas imageTile(this Canvas tile, String uri)
        {
            tile.Children.Clear();
            tile.Opacity = 1;
            
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:" + uri));
            imageBrush.Stretch = Stretch.UniformToFill;
            tile.Background = imageBrush;

            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:Assets/Shadow0.png"));
            img.Height = tile.ActualHeight;
            img.Width = tile.ActualWidth;
            img.Stretch = Stretch.Fill;
            tile.Children.Add(img);
            tile.Name = "imageTile";

            return tile;
        }


        /// <summary>
        /// Funkce pro zobrazeni textu, kde je nejaky titulek + text.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Canvas titledStringTile(this Canvas tile, string title, string text)
        {
            tile.Children.Clear();
            tile.Opacity = 1;


            TextBlock titleBlock = new TextBlock();
            titleBlock.Height = Window.Current.Bounds.Height / 12;
            titleBlock.Width = Window.Current.Bounds.Height / 6;
            titleBlock.FontSize = Window.Current.Bounds.Height/40;
            titleBlock.Text = title;
            titleBlock.Margin = new Thickness(Window.Current.Bounds.Height / 200, Window.Current.Bounds.Height / 200, Window.Current.Bounds.Height / 200, 0);
            titleBlock.TextWrapping = TextWrapping.Wrap;
            tile.Children.Add(titleBlock);

            TextBlock textBlock = new TextBlock();
            
            textBlock.LineHeight = Window.Current.Bounds.Height / 50;
            textBlock.CompositeMode = ElementCompositeMode.SourceOver;
            textBlock.LineStackingStrategy = LineStackingStrategy.BlockLineHeight;
            textBlock.Height = Window.Current.Bounds.Height / 12;
            textBlock.Width = Window.Current.Bounds.Height / 6;
            textBlock.FontSize = Window.Current.Bounds.Height / 50;
            textBlock.Text = text;
            textBlock.Margin = new Thickness(Window.Current.Bounds.Height / 200, (Window.Current.Bounds.Height / 200) + (Window.Current.Bounds.Height / 12), Window.Current.Bounds.Height / 200, 0);
            textBlock.TextWrapping = TextWrapping.Wrap;
            tile.Children.Add(textBlock);
            tile.Name = "stringTile";

            return tile;

        }


        /// <summary>
        /// Funkce pro zobrazeni hodnoty SO2. Rating je hodnota stavu, station je nazev stanice a name je sloucenina.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="status"></param>
        /// <param name="name"></param>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static Canvas statusSO2Tile(this Canvas tile)
        {
            tile.Children.Clear();
            tile.Opacity = 1;

            string status = "error";

            int rating = Data.SO2;

            tile.Background = Data.GetSO2ColorAndStatus().Item1;
            status = Data.GetSO2ColorAndStatus().Item2;
           

            TextBlock ratingString = new TextBlock();
            ratingString.Text = rating.ToString();
            Run myRun = new Run();

            ratingString.FontSize = Window.Current.Bounds.Height / 18;
            ratingString.Height = Window.Current.Bounds.Height / 18;
            ratingString.Width = Window.Current.Bounds.Height / 6;
            ratingString.TextWrapping = TextWrapping.Wrap;
            ratingString.TextAlignment = TextAlignment.Center;
            ratingString.Margin = new Thickness(0, Window.Current.Bounds.Height / 30, 0, 0);
            tile.Children.Add(ratingString);

            TextBlock stationString = new TextBlock();
            stationString.Text = status;
            stationString.FontSize = Window.Current.Bounds.Height / 60;
            stationString.Height = Window.Current.Bounds.Height / 24;
            stationString.Width = Window.Current.Bounds.Height / 6;
            stationString.TextWrapping = TextWrapping.Wrap;
            stationString.TextAlignment = TextAlignment.Center;
            stationString.Margin = new Thickness(0, (Window.Current.Bounds.Height / 96) * 9, 0, 0);
            tile.Children.Add(stationString);

            TextBlock nameString = new TextBlock();
            nameString.Text = "SO\x2082";
            nameString.FontSize = Window.Current.Bounds.Height / 50;
            nameString.Height = Window.Current.Bounds.Height / 24;
            nameString.Width = Window.Current.Bounds.Height / 6;
            nameString.TextAlignment = TextAlignment.Left;

            nameString.Margin = new Thickness(Window.Current.Bounds.Height / 126, (Window.Current.Bounds.Height / 72) * 10, 0, 0);
            tile.Children.Add(nameString);

            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:Assets/Shadow0.png"));
            img.Height = tile.ActualHeight;
            img.Width = tile.ActualWidth;
            img.Stretch = Stretch.Fill;
            tile.Children.Add(img);
            tile.Name = "statusTile";

            return tile;

        }

        /// <summary>
        /// Funkce pro zobrazeni hodnoty NO2. Rating je hodnota stavu, station je nazev stanice a name je sloucenina.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="status"></param>
        /// <param name="name"></param>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static Canvas statusNO2Tile(this Canvas tile)
        {
            tile.Children.Clear();
            tile.Opacity = 1;

            string status = "error";
            int rating = Data.NO2;
            tile.Background = Data.GetNO2ColorAndStatus().Item1;
            status = Data.GetNO2ColorAndStatus().Item2;

            TextBlock ratingString = new TextBlock();
            ratingString.Text = rating.ToString();
            ratingString.FontSize = Window.Current.Bounds.Height / 18;
            ratingString.Height = Window.Current.Bounds.Height / 18;
            ratingString.Width = Window.Current.Bounds.Height / 6;
            ratingString.TextWrapping = TextWrapping.Wrap;
            ratingString.TextAlignment = TextAlignment.Center;
            ratingString.Margin = new Thickness(0, Window.Current.Bounds.Height / 30, 0, 0);
            tile.Children.Add(ratingString);

            TextBlock stationString = new TextBlock();
            stationString.Text = status;
            stationString.FontSize = Window.Current.Bounds.Height / 60;
            stationString.Height = Window.Current.Bounds.Height / 24;
            stationString.Width = Window.Current.Bounds.Height / 6;
            stationString.TextWrapping = TextWrapping.Wrap;
            stationString.TextAlignment = TextAlignment.Center;
            stationString.Margin = new Thickness(0, (Window.Current.Bounds.Height / 96) * 9, 0, 0);
            tile.Children.Add(stationString);

            TextBlock nameString = new TextBlock();
            nameString.Text = "NO\x2082";
            nameString.FontSize = Window.Current.Bounds.Height / 50;
            nameString.Height = Window.Current.Bounds.Height / 24;
            nameString.Width = Window.Current.Bounds.Height / 6;
            nameString.TextAlignment = TextAlignment.Left;

            nameString.Margin = new Thickness(Window.Current.Bounds.Height / 126, (Window.Current.Bounds.Height / 72) * 10, 0, 0);
            tile.Children.Add(nameString);

            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:Assets/Shadow0.png"));
            img.Height = tile.ActualHeight;
            img.Width = tile.ActualWidth;
            img.Stretch = Stretch.Fill;
            tile.Children.Add(img);
            tile.Name = "statusTile";

            return tile;

        }

        /// <summary>
        /// Funkce pro zobrazeni hodnoty CO. Rating je hodnota stavu, station je nazev stanice a name je sloucenina.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="status"></param>
        /// <param name="name"></param>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static Canvas statusCOTile(this Canvas tile)
        {
            tile.Children.Clear();
            tile.Opacity = 1;

            string status = "error";
            int rating = Data.CO;
            tile.Background = Data.GetCOColorAndStatus().Item1;
            status = Data.GetCOColorAndStatus().Item2;

            

            TextBlock ratingString = new TextBlock();
            ratingString.Text = rating.ToString();
            ratingString.FontSize = Window.Current.Bounds.Height / 18;
            ratingString.Height = Window.Current.Bounds.Height / 18;
            ratingString.Width = Window.Current.Bounds.Height / 6;
            ratingString.TextWrapping = TextWrapping.Wrap;
            ratingString.TextAlignment = TextAlignment.Center;
            ratingString.Margin = new Thickness(0, Window.Current.Bounds.Height / 30, 0, 0);
            tile.Children.Add(ratingString);

            TextBlock stationString = new TextBlock();
            stationString.Text = status;
            stationString.FontSize = Window.Current.Bounds.Height / 60;
            stationString.Height = Window.Current.Bounds.Height / 24;
            stationString.Width = Window.Current.Bounds.Height / 6;
            stationString.TextWrapping = TextWrapping.Wrap;
            stationString.TextAlignment = TextAlignment.Center;
            stationString.Margin = new Thickness(0, (Window.Current.Bounds.Height / 96) * 9, 0, 0);
            tile.Children.Add(stationString);

            TextBlock nameString = new TextBlock();
            nameString.Text = "CO";
            nameString.FontSize = Window.Current.Bounds.Height / 50;
            nameString.Height = Window.Current.Bounds.Height / 24;
            nameString.Width = Window.Current.Bounds.Height / 6;
            nameString.TextAlignment = TextAlignment.Left;

            nameString.Margin = new Thickness(Window.Current.Bounds.Height / 126, (Window.Current.Bounds.Height / 72) * 10, 0, 0);
            tile.Children.Add(nameString);

            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:Assets/Shadow0.png"));
            img.Height = tile.ActualHeight;
            img.Width = tile.ActualWidth;
            img.Stretch = Stretch.Fill;
            tile.Children.Add(img);
            tile.Name = "statusTile";

            return tile;

        }

        /// <summary>
        /// Funkce pro zobrazeni hodnoty O3. Rating je hodnota stavu, station je nazev stanice a name je sloucenina.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="status"></param>
        /// <param name="name"></param>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static Canvas statusO3Tile(this Canvas tile)
        {
            tile.Children.Clear();
            tile.Opacity = 1;

            string status = "error";
            int rating = Data.O3;
            tile.Background = Data.GetO3ColorAndStatus().Item1;
            status = Data.GetO3ColorAndStatus().Item2;

            TextBlock ratingString = new TextBlock();
            ratingString.Text = rating.ToString();
            Run myRun = new Run();

            ratingString.FontSize = Window.Current.Bounds.Height / 18;
            ratingString.Height = Window.Current.Bounds.Height / 18;
            ratingString.Width = Window.Current.Bounds.Height / 6;
            ratingString.TextWrapping = TextWrapping.Wrap;
            ratingString.TextAlignment = TextAlignment.Center;
            ratingString.Margin = new Thickness(0, Window.Current.Bounds.Height / 30, 0, 0);
            tile.Children.Add(ratingString);

            TextBlock stationString = new TextBlock();
            stationString.Text = status;
            stationString.FontSize = Window.Current.Bounds.Height / 60;
            stationString.Height = Window.Current.Bounds.Height / 24;
            stationString.Width = Window.Current.Bounds.Height / 6;
            stationString.TextWrapping = TextWrapping.Wrap;
            stationString.TextAlignment = TextAlignment.Center;
            stationString.Margin = new Thickness(0, (Window.Current.Bounds.Height / 96) * 9, 0, 0);
            tile.Children.Add(stationString);

            TextBlock nameString = new TextBlock();
            nameString.Text = "O\x2083";
            nameString.FontSize = Window.Current.Bounds.Height / 50;
            nameString.Height = Window.Current.Bounds.Height / 24;
            nameString.Width = Window.Current.Bounds.Height / 6;
            nameString.TextAlignment = TextAlignment.Left;

            nameString.Margin = new Thickness(Window.Current.Bounds.Height / 126, (Window.Current.Bounds.Height / 72) * 10, 0, 0);
            tile.Children.Add(nameString);

            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:Assets/Shadow0.png"));
            img.Height = tile.ActualHeight;
            img.Width = tile.ActualWidth;
            img.Stretch = Stretch.Fill;
            tile.Children.Add(img);
            tile.Name = "statusTile";

            return tile;

        }

        /// <summary>
        /// Funkce pro zobrazeni hodnoty PM10. Rating je hodnota stavu, station je nazev stanice a name je sloucenina.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="status"></param>
        /// <param name="name"></param>
        /// <param name="brush"></param>
        /// <returns></returns>
        public static Canvas statusPM10Tile(this Canvas tile)
        {
            tile.Children.Clear();
            tile.Opacity = 1;

            string status = "error";
            int rating = Data.PM10;
            tile.Background = Data.GetPM10ColorAndStatus().Item1;
            status = Data.GetPM10ColorAndStatus().Item2;


                

                TextBlock ratingString = new TextBlock();
                ratingString.Name = "ratingString";
                ratingString.Text = rating.ToString();


                ratingString.FontSize = Window.Current.Bounds.Height / 18;
                ratingString.Height = Window.Current.Bounds.Height / 18;
                ratingString.Width = Window.Current.Bounds.Height / 6;
                ratingString.TextWrapping = TextWrapping.Wrap;
                ratingString.TextAlignment = TextAlignment.Center;
                ratingString.Margin = new Thickness(0, Window.Current.Bounds.Height / 30, 0, 0);
                tile.Children.Add(ratingString);

                TextBlock stationString = new TextBlock();
                stationString.Name = "stationString";
                stationString.Text = status;
                stationString.FontSize = Window.Current.Bounds.Height / 60;
                stationString.Height = Window.Current.Bounds.Height / 24;
                stationString.Width = Window.Current.Bounds.Height / 6;
                stationString.TextWrapping = TextWrapping.Wrap;
                stationString.TextAlignment = TextAlignment.Center;
                stationString.Margin = new Thickness(0, (Window.Current.Bounds.Height / 96) * 9, 0, 0);
                tile.Children.Add(stationString);

                TextBlock nameString = new TextBlock();
                nameString.Name = "nameString";
                nameString.Text = "PM\x2081\x2080";
                nameString.FontSize = Window.Current.Bounds.Height / 50;
                nameString.Height = Window.Current.Bounds.Height / 24;
                nameString.Width = Window.Current.Bounds.Height / 6;
                nameString.TextAlignment = TextAlignment.Left;

                nameString.Margin = new Thickness(Window.Current.Bounds.Height / 126, (Window.Current.Bounds.Height / 72) * 10, 0, 0);
                tile.Children.Add(nameString);

                Image img = new Image();
                img.Name = "img";
                img.Source = new BitmapImage(new Uri("ms-appx:Assets/Shadow0.png"));
                img.Height = tile.ActualHeight;
                img.Width = tile.ActualWidth;
                img.Stretch = Stretch.Fill;
                tile.Children.Add(img);
                tile.Name = "statusTile";

                return tile;

        }


        /// <summary>
        /// Hlavni stavova velka dlazdice.
        /// </summary>
        /// <param name="tile"></param>
        /// <param name="name">Nazev stanice</param>
        /// <param name="brush">Barva tilu</param>
        /// <param name="uri">Ciste uri, bez ms-appx</param>
        /// <returns></returns>
        public static Canvas mainStatusTile(this Canvas tile, string name, SolidColorBrush brush, string uri)
        {
            tile.Opacity = 1;
            tile.Background = brush;

            TextBlock statusTitle = new TextBlock();
            statusTitle.Text = "Stav:";
            statusTitle.FontSize = Window.Current.Bounds.Height/24;
            statusTitle.Margin = new Thickness(Window.Current.Bounds.Height/100, Window.Current.Bounds.Height/100, 0, 0);
            tile.Children.Add(statusTitle);

            Canvas imgCanvas = new Canvas();
            imgCanvas.Height = Window.Current.Bounds.Height/6;
            imgCanvas.Width = Window.Current.Bounds.Height / 6;
            imgCanvas.Margin = new Thickness(Window.Current.Bounds.Height/12, Window.Current.Bounds.Height/12,0,0);
            tile.Children.Add(imgCanvas);

            ImageBrush statusImg = new ImageBrush();
            statusImg.ImageSource = new BitmapImage(new Uri(@"ms-appx:" + uri));
            statusImg.Stretch = Stretch.UniformToFill;
            imgCanvas.Background = statusImg;

            TextBlock stationName = new TextBlock();
            stationName.Width = (Window.Current.Bounds.Height / 6) * 2;
            stationName.Text = name;
            stationName.FontSize = Window.Current.Bounds.Height/40;
            stationName.Margin = new Thickness(0, (Window.Current.Bounds.Height/48)*14, 0, 0);
            stationName.TextAlignment = TextAlignment.Center;
            tile.Children.Add(stationName);

            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:Assets/Shadow1.png"));
            //img.Height = tile.ActualHeight;
            //img.Width = tile.ActualWidth;
            img.Height = (Window.Current.Bounds.Height / 6)*2;
            img.Width = (Window.Current.Bounds.Height / 6) * 2;
            img.Stretch = Stretch.Fill;
            tile.Children.Add(img);
            tile.Name = "mainStatusTile";

            return tile;
        }





        /// <summary>
        /// Tato funkce bude vysunovat levy bocni panel
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public static Canvas buttonLeftPanelTile(this Canvas tile) 
        {
            if (tile.Name == "buttonTile")
            {
                tile.Tapped += buttonLeftPanelTile_Tapped;
            }
            else
            {
                tile.Children.Clear();
                tile.Opacity = 1;

                tile.Background = new SolidColorBrush(Color.FromArgb(255, 50, 50, 50));


                TextBlock title = new TextBlock();
                title.Text = "Detail\nstanice";
                title.FontSize = Window.Current.Bounds.Height / 36;
                title.Foreground = new SolidColorBrush(Colors.White);
                title.Margin = new Thickness(Window.Current.Bounds.Height / 24, Window.Current.Bounds.Height / 18, 0, 0);
                title.TextAlignment = TextAlignment.Center;

                tile.Children.Add(title);

                Image img = new Image();
                img.Source = new BitmapImage(new Uri("ms-appx:Assets/Shadow0.png"));
                img.Height = tile.ActualHeight;
                img.Width = tile.ActualWidth;
                img.Stretch = Stretch.Fill;
                tile.Children.Add(img);
                tile.Name = "buttonTile";

                tile.Tapped += buttonLeftPanelTile_Tapped;
            }
            return tile;
        }

        public static Canvas buttonLeftPanelButton(this Canvas tile)
        {
            if (tile.Name == "buttonTile")
            {
                tile.Tapped += buttonLeftPanelButton_Tapped;
            }
            else
            {
                tile.Children.Clear();
                tile.Opacity = 1;

                tile.Background = new SolidColorBrush(Color.FromArgb(255, 50, 50, 50));


                TextBlock title = new TextBlock();
                title.Text = "Detail\nstanice";
                title.FontSize = Window.Current.Bounds.Height / 36;
                title.Foreground = new SolidColorBrush(Colors.White);
                title.Margin = new Thickness(Window.Current.Bounds.Height / 24, Window.Current.Bounds.Height / 18, 0, 0);
                title.TextAlignment = TextAlignment.Center;

                tile.Children.Add(title);

                tile.Tapped += buttonLeftPanelButton_Tapped;
            }
            return tile;
        }
        private static void buttonLeftPanelTile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage.showLeftPanel();
        }

        private static void buttonLeftPanelButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage.hideLeftPanel();
        }
        
        /// <summary>
        /// Tato funkce bude vysunovat pravy bocni panel
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public static Canvas buttonRightPanelTile(this Canvas tile)
        {
            tile.Children.Clear();
            tile.Opacity = 1;

            tile.Background = new SolidColorBrush(Color.FromArgb(255, 50, 50, 50));


            TextBlock title = new TextBlock();
            title.Text = "Další\nfunkce";
            title.FontSize = Window.Current.Bounds.Height / 36;
            title.Foreground = new SolidColorBrush(Colors.White);
            title.Margin = new Thickness(Window.Current.Bounds.Height / 24, Window.Current.Bounds.Height / 18, 0, 0);
            title.TextAlignment = TextAlignment.Center;

            tile.Children.Add(title);
            /*
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:Assets/Shadow0.png"));
            img.Height = tile.ActualHeight;
            img.Width = tile.ActualWidth;
            img.Stretch = Stretch.Fill;
            tile.Children.Add(img);
            tile.Name = "buttonTile";*/

            tile.Tapped += buttonRightPanelTile_Tapped;

            return tile;
        }

        public static Canvas buttonRightPanelButton(this Canvas tile)
        {
            tile.Children.Clear();
            tile.Opacity = 1;

            tile.Background = new SolidColorBrush(Color.FromArgb(255, 50, 50, 50));


            TextBlock title = new TextBlock();
            title.Text = "Další\nfunkce";
            title.FontSize = Window.Current.Bounds.Height / 36;
            title.Foreground = new SolidColorBrush(Colors.White);
            title.Margin = new Thickness(Window.Current.Bounds.Height / 24, Window.Current.Bounds.Height / 18, 0, 0);
            title.TextAlignment = TextAlignment.Center;

            tile.Children.Add(title);
            /*
            Image img = new Image();
            img.Source = new BitmapImage(new Uri("ms-appx:Assets/Shadow0.png"));
            img.Height = tile.ActualHeight;
            img.Width = tile.ActualWidth;
            img.Stretch = Stretch.Fill;
            tile.Children.Add(img);
            tile.Name = "buttonTile";*/

            tile.Tapped += buttonRightPanelButton_Tapped;

            return tile;
        }

        private static void buttonRightPanelButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage.hideRightPanel();
        }

        private static void buttonRightPanelTile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            MainPage.showRightPanel();
            
            
        }


        
        
    }
}
