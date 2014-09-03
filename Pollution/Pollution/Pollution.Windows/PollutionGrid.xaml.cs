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
        //kolekce pro manipulaci s dlazdicemi
        public static List<Canvas> tileCollection = new List<Canvas>();

        public static Windows.UI.Xaml.Controls.Grid LayoutGrid = new Windows.UI.Xaml.Controls.Grid();
           
        /// <summary>
        /// Inicializace hlavního gridu
        /// </summary>
        private void gridInit()
        {
            LayoutGrid.Height = 768;
            LayoutGrid.Width = 1366;
            MyScrollViewer.Content = LayoutGrid;

            //disablovani rotace pro rotaci displeje
            //LayoutGrid.ManipulationMode = ManipulationModes.None;
            


            //definice pozadi
            LayoutGrid.Background = new SolidColorBrush(Colors.White);

            //definice rozmeru
            LayoutGrid.Width = (Window.Current.Bounds.Height / 6) * 11;
            LayoutGrid.Height = Window.Current.Bounds.Height;

            //deklarace a definice 6 radku
            RowDefinition rowdef1 = new RowDefinition();
            LayoutGrid.RowDefinitions.Add(rowdef1);
            RowDefinition rowdef2 = new RowDefinition();
            LayoutGrid.RowDefinitions.Add(rowdef2);
            RowDefinition rowdef3 = new RowDefinition();
            LayoutGrid.RowDefinitions.Add(rowdef3);
            RowDefinition rowdef4 = new RowDefinition();
            LayoutGrid.RowDefinitions.Add(rowdef4);
            RowDefinition rowdef5 = new RowDefinition();
            LayoutGrid.RowDefinitions.Add(rowdef5);
            RowDefinition rowdef6 = new RowDefinition();
            LayoutGrid.RowDefinitions.Add(rowdef6);

            //deklarace a definice 11 sloupců
            ColumnDefinition coldef1 = new ColumnDefinition();
            LayoutGrid.ColumnDefinitions.Add(coldef1);
            ColumnDefinition coldef2 = new ColumnDefinition();
            LayoutGrid.ColumnDefinitions.Add(coldef2);
            ColumnDefinition coldef3 = new ColumnDefinition();
            LayoutGrid.ColumnDefinitions.Add(coldef3);
            ColumnDefinition coldef4 = new ColumnDefinition();
            LayoutGrid.ColumnDefinitions.Add(coldef4);
            ColumnDefinition coldef5 = new ColumnDefinition();
            LayoutGrid.ColumnDefinitions.Add(coldef5);
            ColumnDefinition coldef6 = new ColumnDefinition();
            LayoutGrid.ColumnDefinitions.Add(coldef6);
            ColumnDefinition coldef7 = new ColumnDefinition();
            LayoutGrid.ColumnDefinitions.Add(coldef7);
            ColumnDefinition coldef8 = new ColumnDefinition();
            LayoutGrid.ColumnDefinitions.Add(coldef8);
            ColumnDefinition coldef9 = new ColumnDefinition();
            LayoutGrid.ColumnDefinitions.Add(coldef9);
            ColumnDefinition coldef10 = new ColumnDefinition();
            LayoutGrid.ColumnDefinitions.Add(coldef10);
            ColumnDefinition coldef11 = new ColumnDefinition();
            LayoutGrid.ColumnDefinitions.Add(coldef11);

            
            

        }


        private void gridFullfill()
        {

            //vyplneni gridu bunkami v podobe canvasu
            for (int i = 0; i < 66; i++)
            {
                if (i == 24)
                {
                    Canvas tile = new Canvas();
                    tile.Background = new SolidColorBrush(Colors.Red);
                    Windows.UI.Xaml.Controls.Grid.SetColumn(tile, i % 11);
                    Windows.UI.Xaml.Controls.Grid.SetColumnSpan(tile, 2);
                    Windows.UI.Xaml.Controls.Grid.SetRow(tile, i / 11);
                    Windows.UI.Xaml.Controls.Grid.SetRowSpan(tile, 2);
                    tileCollection.Add(tile);
                    tile.Tapped += mainTile_Tapped;
                    LayoutGrid.Children.Add(tile);

                }
                else
                {
                    if (i == 25 || i == 35 || i == 36)
                    {

                    }
                    else
                    {

                        Canvas tile = new Canvas();
                        tile.Background = new SolidColorBrush(Colors.White);
                        Windows.UI.Xaml.Controls.Grid.SetColumn(tile, i % 11);
                        Windows.UI.Xaml.Controls.Grid.SetRow(tile, i / 11);
                        tile.blankTile(new SolidColorBrush(Colors.Gray));
                        tileCollection.Add(tile);
                        LayoutGrid.Children.Add(tile);

                    }

                }

            }

            //prvotni zbarveni gridu
            moodizeGrid(Pollution.StatusColor.Status.Suitable, "Lothlórien");

            //nastaveni testovaciho tilu
            tileCollection.ElementAt(13).testTile();



        }



        void mainTile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            deployStatus();

        }

        public void deployStatus()
        {
            if (tileCollection.ElementAt(16).Name == "statusTile")
            { undeployStatus(); }
            else
            {
                if (tileCollection.ElementAt(9).Name == "buttonTile")
                {
                    tileCollection.ElementAt(16).statusSO2Tile();
                    tileCollection.ElementAt(27).statusO3Tile();
                    tileCollection.ElementAt(29).statusNO2Tile();
                    tileCollection.ElementAt(37).statusCOTile();
                    tileCollection.ElementAt(46).statusPM10Tile();

                }
                else
                {
                    //tileCollection.ElementAt(9).buttonRightPanelTile();
                    MainPage.LeftPanel.Margin = new Thickness(0, 0, 0, 0);
                    tileCollection.ElementAt(16).statusSO2Tile();
                    tileCollection.ElementAt(27).statusO3Tile();
                    tileCollection.ElementAt(29).statusNO2Tile();
                    tileCollection.ElementAt(37).statusCOTile();
                    tileCollection.ElementAt(46).statusPM10Tile();
                    MainPage.RightPanel.Margin = new Thickness(0, -(Window.Current.Bounds.Height / 6) * 4, 0, 0);
                    
                    //tileCollection.ElementAt(53).buttonLeftPanelTile();
                }
            }
        }
        public void undeployStatus()
        {
            Random rand = new Random();
            tileCollection.ElementAt(16).blankTile((SolidColorBrush)tileCollection.ElementAt(24).Background);
            tileCollection.ElementAt(16).Opacity = ((double)(rand.Next(50, 100))) / 100;
            tileCollection.ElementAt(27).blankTile((SolidColorBrush)tileCollection.ElementAt(24).Background);
            tileCollection.ElementAt(27).Opacity = ((double)(rand.Next(50, 100))) / 100;
            tileCollection.ElementAt(29).blankTile((SolidColorBrush)tileCollection.ElementAt(24).Background);
            tileCollection.ElementAt(29).Opacity = ((double)(rand.Next(50, 100))) / 100;
            tileCollection.ElementAt(37).blankTile((SolidColorBrush)tileCollection.ElementAt(24).Background);
            tileCollection.ElementAt(37).Opacity = ((double)(rand.Next(50, 100))) / 100;
            tileCollection.ElementAt(46).blankTile((SolidColorBrush)tileCollection.ElementAt(24).Background);
            tileCollection.ElementAt(46).Opacity = ((double)(rand.Next(50, 100))) / 100;
        }

        public static void moodizeGrid(Pollution.StatusColor.Status status, string station)
        {
            Random rand = new Random();
            StatusColor statusAtributes = new StatusColor(status);
            tileCollection.ElementAt(24).blankTile(statusAtributes.getBrush());
            tileCollection.ElementAt(24).mainStatusTile(station, statusAtributes.getBrush(), statusAtributes.getUri());

            foreach (Canvas tile in tileCollection)
            {
                if (tile.Name == "blankTile")
                {
                    tile.Background = statusAtributes.getBrush();
                    tile.Opacity = ((double)(rand.Next(50, 100))) / 100;
                }

            }
        }


    }
}
