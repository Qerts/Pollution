using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pollution
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public static Windows.UI.Xaml.Controls.Grid LeftPanel = new Windows.UI.Xaml.Controls.Grid();
        static List<Canvas> leftPanelCollection = new List<Canvas>();

        private void leftPanelInit()
        {
            //definice pozadi
            LeftPanel.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));


            //definice rozmeru
            LeftPanel.Width = (Window.Current.Bounds.Height / 6) * 11;
            LeftPanel.Height = (Window.Current.Bounds.Height / 6) * 5;


            LeftPanel.VerticalAlignment = VerticalAlignment.Top;
            LeftPanel.HorizontalAlignment = HorizontalAlignment.Center;
            

            //deklarace a definice 5 radku
            RowDefinition rowdef1 = new RowDefinition();
            LeftPanel.RowDefinitions.Add(rowdef1);
            RowDefinition rowdef2 = new RowDefinition();
            LeftPanel.RowDefinitions.Add(rowdef2);
            RowDefinition rowdef3 = new RowDefinition();
            LeftPanel.RowDefinitions.Add(rowdef3);
            RowDefinition rowdef4 = new RowDefinition();
            LeftPanel.RowDefinitions.Add(rowdef4);
            RowDefinition rowdef5 = new RowDefinition();
            LeftPanel.RowDefinitions.Add(rowdef5);


            //deklarace a definice 11 sloupců
            ColumnDefinition coldef1 = new ColumnDefinition();
            LeftPanel.ColumnDefinitions.Add(coldef1);
            ColumnDefinition coldef2 = new ColumnDefinition();
            LeftPanel.ColumnDefinitions.Add(coldef2);
            ColumnDefinition coldef3 = new ColumnDefinition();
            LeftPanel.ColumnDefinitions.Add(coldef3);
            ColumnDefinition coldef4 = new ColumnDefinition();
            LeftPanel.ColumnDefinitions.Add(coldef4);
            ColumnDefinition coldef5 = new ColumnDefinition();
            LeftPanel.ColumnDefinitions.Add(coldef5);
            ColumnDefinition coldef6 = new ColumnDefinition();
            LeftPanel.ColumnDefinitions.Add(coldef6);
            ColumnDefinition coldef7 = new ColumnDefinition();
            LeftPanel.ColumnDefinitions.Add(coldef7);
            ColumnDefinition coldef8 = new ColumnDefinition();
            LeftPanel.ColumnDefinitions.Add(coldef8);
            ColumnDefinition coldef9 = new ColumnDefinition();
            LeftPanel.ColumnDefinitions.Add(coldef9);
            ColumnDefinition coldef10 = new ColumnDefinition();
            LeftPanel.ColumnDefinitions.Add(coldef10);
            ColumnDefinition coldef11 = new ColumnDefinition();
            LeftPanel.ColumnDefinitions.Add(coldef11);

            
            //nastavení pozice            
            Windows.UI.Xaml.Controls.Grid.SetColumn(LeftPanel, 0);
            Windows.UI.Xaml.Controls.Grid.SetColumnSpan(LeftPanel, 11);
            Windows.UI.Xaml.Controls.Grid.SetRow(LeftPanel, 5);
            Windows.UI.Xaml.Controls.Grid.SetRowSpan(LeftPanel, 6);

            LeftPanel.Margin = new Thickness(0, (Window.Current.Bounds.Height / 6), 0, 0);

            LayoutGrid.Children.Add(LeftPanel);          
            leftPanelFullfill();


            ////////////////////////////////
            ////grid pro obsah leveho panelu
            ////////////////////////////////
            Windows.UI.Xaml.Controls.Grid outerInnerLeftPanelGrid = new Windows.UI.Xaml.Controls.Grid();
            Windows.UI.Xaml.Controls.Grid.SetColumn(outerInnerLeftPanelGrid, 0);
            Windows.UI.Xaml.Controls.Grid.SetColumnSpan(outerInnerLeftPanelGrid, 10);
            Windows.UI.Xaml.Controls.Grid.SetRow(outerInnerLeftPanelGrid, 1);
            Windows.UI.Xaml.Controls.Grid.SetRowSpan(outerInnerLeftPanelGrid, 10);
            LeftPanel.Children.Add(outerInnerLeftPanelGrid);

            ColumnDefinition coludef1 = new ColumnDefinition();
            coludef1.Width = new GridLength(35, GridUnitType.Star); 
            outerInnerLeftPanelGrid.ColumnDefinitions.Add(coludef1);
            ColumnDefinition coludef2 = new ColumnDefinition();
            coludef2.Width = new GridLength(35, GridUnitType.Star); 
            outerInnerLeftPanelGrid.ColumnDefinitions.Add(coludef2);
            ColumnDefinition coludef3 = new ColumnDefinition();
            coludef3.Width = new GridLength(30, GridUnitType.Star); 
            outerInnerLeftPanelGrid.ColumnDefinitions.Add(coludef3);

            ////+Grid pro nazev a male stavy
            Windows.UI.Xaml.Controls.Grid nameInnerInnerLeftPanelGrid = new Windows.UI.Xaml.Controls.Grid();
            Windows.UI.Xaml.Controls.Grid.SetColumn(nameInnerInnerLeftPanelGrid, 0);
            nameInnerInnerLeftPanelGrid.Height = (Window.Current.Bounds.Height / 6) * 3;
            nameInnerInnerLeftPanelGrid.Width = (Window.Current.Bounds.Height / 6) * 3;

            RowDefinition nameRowDef1 = new RowDefinition();
            nameRowDef1.Height = new GridLength(1, GridUnitType.Star);
            nameInnerInnerLeftPanelGrid.RowDefinitions.Add(nameRowDef1);
            RowDefinition nameRowDef2 = new RowDefinition();
            nameRowDef2.Height = new GridLength(1, GridUnitType.Star);
            nameInnerInnerLeftPanelGrid.RowDefinitions.Add(nameRowDef2);
            RowDefinition nameRowDef3 = new RowDefinition();
            nameRowDef3.Height = new GridLength(2, GridUnitType.Star);
            nameInnerInnerLeftPanelGrid.RowDefinitions.Add(nameRowDef3);
            
            outerInnerLeftPanelGrid.Children.Add(nameInnerInnerLeftPanelGrid);

            ////++Stackpanel s nazvem a krajem
            StackPanel stationNameStck = new StackPanel();
            stationNameStck.VerticalAlignment = VerticalAlignment.Center;
            Windows.UI.Xaml.Controls.Grid.SetRow(stationNameStck, 0);
            nameInnerInnerLeftPanelGrid.Children.Add(stationNameStck);

            TextBlock stationTitleTxt = new TextBlock();
            stationTitleTxt.Text = Data.StationName;
            stationTitleTxt.FontSize = (Window.Current.Bounds.Height / 30);
            //stationTitle.FontWeight = FontWeights.Bold;
            stationTitleTxt.Foreground = new SolidColorBrush(Colors.White);
            stationTitleTxt.HorizontalAlignment = HorizontalAlignment.Center;
            stationNameStck.Children.Add(stationTitleTxt);

            TextBlock stationTerritoryTxt = new TextBlock();
            stationTerritoryTxt.Text = Data.StationRegion;
            stationTerritoryTxt.FontSize = (Window.Current.Bounds.Height / 40);
            stationTerritoryTxt.Foreground = new SolidColorBrush(Colors.White);
            stationTerritoryTxt.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
            stationNameStck.Children.Add(stationTerritoryTxt);

            ////++Stack panel pro koordinaty
            TextBlock stationCoords = new TextBlock();
            Windows.UI.Xaml.Controls.Grid.SetRow(stationCoords, 1);
            nameInnerInnerLeftPanelGrid.Children.Add(stationCoords);
            stationCoords.Text = Data.StationCoordinates;
            stationCoords.FontSize = (Window.Current.Bounds.Height / 40);
            stationCoords.Foreground = new SolidColorBrush(Colors.White);
            stationCoords.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;

            ////++Stack panel pro jednotlive stavy
            StackPanel stationStatusesStck = new StackPanel();
            stationStatusesStck.Orientation = Orientation.Horizontal;
            Windows.UI.Xaml.Controls.Grid.SetRow(stationStatusesStck, 2);
            nameInnerInnerLeftPanelGrid.Children.Add(stationStatusesStck);

            ////+++Stack panel prvniho statusu
            StackPanel status1Stck = new StackPanel();
            status1Stck.Margin = new Thickness((Window.Current.Bounds.Height / 120), 0, (Window.Current.Bounds.Height / 120), 0);
            stationStatusesStck.Children.Add(status1Stck);

            TextBlock status1TitleTxt = new TextBlock();
            status1TitleTxt.Text = "SO\x2082";
            status1TitleTxt.Foreground = new SolidColorBrush(Colors.White);
            status1TitleTxt.HorizontalAlignment = HorizontalAlignment.Center;
            status1TitleTxt.FontSize = (Window.Current.Bounds.Height / 40);
            status1Stck.Children.Add(status1TitleTxt);

            Windows.UI.Xaml.Controls.Grid status1ValueImg = new Windows.UI.Xaml.Controls.Grid();
            status1ValueImg.Background = Data.GetSO2ColorAndStatus().Item1;
            status1ValueImg.Height = (Window.Current.Bounds.Height / 12);
            status1ValueImg.Width = (Window.Current.Bounds.Height / 12);
            status1Stck.Children.Add(status1ValueImg);

            TextBlock status1ValueTxt = new TextBlock();
            status1ValueTxt.FontSize = (Window.Current.Bounds.Height / 40);
            status1ValueTxt.Text = Data.SO2.ToString();
            status1ValueTxt.HorizontalAlignment = HorizontalAlignment.Center;
            status1ValueTxt.VerticalAlignment = VerticalAlignment.Center;
            status1ValueTxt.Foreground = new SolidColorBrush(Colors.White);
            status1ValueImg.Children.Add(status1ValueTxt);

            ////+++Stack panel druheho statusu
            StackPanel status2Stck = new StackPanel();
            status2Stck.Margin = new Thickness((Window.Current.Bounds.Height / 120), 0, (Window.Current.Bounds.Height / 120), 0);
            stationStatusesStck.Children.Add(status2Stck);

            TextBlock status2TitleTxt = new TextBlock();
            status2TitleTxt.Text = "NO\x2082";//prepsat na funkci
            status2TitleTxt.Foreground = new SolidColorBrush(Colors.White);
            status2TitleTxt.HorizontalAlignment = HorizontalAlignment.Center;
            status2TitleTxt.FontSize = (Window.Current.Bounds.Height / 40);
            status2Stck.Children.Add(status2TitleTxt);

            Windows.UI.Xaml.Controls.Grid status2ValueImg = new Windows.UI.Xaml.Controls.Grid();
            status2ValueImg.Background = Data.GetNO2ColorAndStatus().Item1;
            status2ValueImg.Height = (Window.Current.Bounds.Height / 12);
            status2ValueImg.Width = (Window.Current.Bounds.Height / 12);
            status2Stck.Children.Add(status2ValueImg);

            TextBlock status2ValueTxt = new TextBlock();
            status2ValueTxt.FontSize = (Window.Current.Bounds.Height / 40);
            status2ValueTxt.Text = Data.NO2.ToString();
            status2ValueTxt.HorizontalAlignment = HorizontalAlignment.Center;
            status2ValueTxt.VerticalAlignment = VerticalAlignment.Center;
            status2ValueTxt.Foreground = new SolidColorBrush(Colors.White);
            status2ValueImg.Children.Add(status2ValueTxt);


            ////+++Stack panel tretiho statusu
            StackPanel status3Stck = new StackPanel();
            status3Stck.Margin = new Thickness((Window.Current.Bounds.Height / 120), 0, (Window.Current.Bounds.Height / 120), 0);
            stationStatusesStck.Children.Add(status3Stck);

            TextBlock status3TitleTxt = new TextBlock();
            status3TitleTxt.Text = "CO";//prepsat na funkci
            status3TitleTxt.Foreground = new SolidColorBrush(Colors.White);
            status3TitleTxt.HorizontalAlignment = HorizontalAlignment.Center;
            status3TitleTxt.FontSize = (Window.Current.Bounds.Height / 40);
            status3Stck.Children.Add(status3TitleTxt);

            Windows.UI.Xaml.Controls.Grid status3ValueImg = new Windows.UI.Xaml.Controls.Grid();
            status3ValueImg.Background = Data.GetCOColorAndStatus().Item1;
            status3ValueImg.Height = (Window.Current.Bounds.Height / 12);
            status3ValueImg.Width = (Window.Current.Bounds.Height / 12);
            status3Stck.Children.Add(status3ValueImg);

            TextBlock status3ValueTxt = new TextBlock();
            status3ValueTxt.FontSize = (Window.Current.Bounds.Height / 40);
            status3ValueTxt.Text = Data.CO.ToString();
            status3ValueTxt.HorizontalAlignment = HorizontalAlignment.Center;
            status3ValueTxt.VerticalAlignment = VerticalAlignment.Center;
            status3ValueTxt.Foreground = new SolidColorBrush(Colors.White);
            status3ValueImg.Children.Add(status3ValueTxt);


            ////+++Stack panel ctvrteho statusu
            StackPanel status4Stck = new StackPanel();
            status4Stck.Margin = new Thickness((Window.Current.Bounds.Height / 120), 0, (Window.Current.Bounds.Height / 120), 0);
            stationStatusesStck.Children.Add(status4Stck);

            TextBlock status4TitleTxt = new TextBlock();
            status4TitleTxt.Text = "O\x2083";//prepsat na funkci
            status4TitleTxt.Foreground = new SolidColorBrush(Colors.White);
            status4TitleTxt.HorizontalAlignment = HorizontalAlignment.Center;
            status4TitleTxt.FontSize = (Window.Current.Bounds.Height / 40);
            status4Stck.Children.Add(status4TitleTxt);

            Windows.UI.Xaml.Controls.Grid status4ValueImg = new Windows.UI.Xaml.Controls.Grid();
            status4ValueImg.Background = Data.GetO3ColorAndStatus().Item1;
            status4ValueImg.Height = (Window.Current.Bounds.Height / 12);
            status4ValueImg.Width = (Window.Current.Bounds.Height / 12);
            status4Stck.Children.Add(status4ValueImg);

            TextBlock status4ValueTxt = new TextBlock();
            status4ValueTxt.FontSize = (Window.Current.Bounds.Height / 40);
            status4ValueTxt.Text = Data.O3.ToString();
            status4ValueTxt.HorizontalAlignment = HorizontalAlignment.Center;
            status4ValueTxt.VerticalAlignment = VerticalAlignment.Center;
            status4ValueTxt.Foreground = new SolidColorBrush(Colors.White);
            status4ValueImg.Children.Add(status4ValueTxt);


            ////+++Stack panel pateho statusu
            StackPanel status5Stck = new StackPanel();
            status5Stck.Margin = new Thickness((Window.Current.Bounds.Height / 120), 0, (Window.Current.Bounds.Height / 120), 0);
            stationStatusesStck.Children.Add(status5Stck);

            TextBlock status5TitleTxt = new TextBlock();
            status5TitleTxt.Text = "PM\x2081\x2080";//prepsat na funkci
            status5TitleTxt.Foreground = new SolidColorBrush(Colors.White);
            status5TitleTxt.HorizontalAlignment = HorizontalAlignment.Center;
            status5TitleTxt.FontSize = (Window.Current.Bounds.Height / 40);
            status5Stck.Children.Add(status5TitleTxt);

            Windows.UI.Xaml.Controls.Grid status5ValueImg = new Windows.UI.Xaml.Controls.Grid();
            status5ValueImg.Background = Data.GetPM10ColorAndStatus().Item1;
            status5ValueImg.Height = (Window.Current.Bounds.Height / 12);
            status5ValueImg.Width = (Window.Current.Bounds.Height / 12);
            status5Stck.Children.Add(status5ValueImg);

            TextBlock status5ValueTxt = new TextBlock();
            status5ValueTxt.FontSize = (Window.Current.Bounds.Height / 40);
            status5ValueTxt.Text = Data.PM10.ToString();
            status5ValueTxt.HorizontalAlignment = HorizontalAlignment.Center;
            status5ValueTxt.VerticalAlignment = VerticalAlignment.Center;
            status5ValueTxt.Foreground = new SolidColorBrush(Colors.White);
            status5ValueImg.Children.Add(status5ValueTxt);



            



            ////+Grid pro teplomery
            Windows.UI.Xaml.Controls.Grid barsInnerInnerLeftPanelGrid = new Windows.UI.Xaml.Controls.Grid();
            Windows.UI.Xaml.Controls.Grid.SetColumn(barsInnerInnerLeftPanelGrid, 1);
            barsInnerInnerLeftPanelGrid.Height = (Window.Current.Bounds.Height / 6) * 3;
            barsInnerInnerLeftPanelGrid.Width = (Window.Current.Bounds.Height / 6) * 3;
            outerInnerLeftPanelGrid.Children.Add(barsInnerInnerLeftPanelGrid);

            ////++Stack panel pro teplomery
            StackPanel stationProgBarsStck = new StackPanel();
            stationProgBarsStck.VerticalAlignment = VerticalAlignment.Center;
            stationProgBarsStck.HorizontalAlignment = HorizontalAlignment.Center;
            stationProgBarsStck.Orientation = Orientation.Horizontal;
            barsInnerInnerLeftPanelGrid.Children.Add(stationProgBarsStck);

            ////+++Bar prvni slozky
            Windows.UI.Xaml.Controls.Grid firstBarGrid = new Windows.UI.Xaml.Controls.Grid();
            stationProgBarsStck.Children.Add(firstBarGrid);
            firstBarGrid.Margin = new Thickness(Window.Current.Bounds.Height / 60, 0, Window.Current.Bounds.Height / 60, 0);

            StackPanel predelatNaImg1 = new StackPanel();
            predelatNaImg1.Background = new SolidColorBrush(Colors.GreenYellow);
            predelatNaImg1.Width = Window.Current.Bounds.Height / 20;
            predelatNaImg1.Height = Window.Current.Bounds.Height / 3;
            firstBarGrid.Children.Add(predelatNaImg1);

            ////+++Bar druhe slozky
            Windows.UI.Xaml.Controls.Grid secondBarGrid = new Windows.UI.Xaml.Controls.Grid();
            stationProgBarsStck.Children.Add(secondBarGrid);
            secondBarGrid.Margin = new Thickness(Window.Current.Bounds.Height / 60, 0, Window.Current.Bounds.Height / 60, 0);

            StackPanel predelatNaImg2 = new StackPanel();
            predelatNaImg2.Background = new SolidColorBrush(Colors.GreenYellow);
            predelatNaImg2.Width = Window.Current.Bounds.Height / 20;
            predelatNaImg2.Height = Window.Current.Bounds.Height / 3;
            secondBarGrid.Children.Add(predelatNaImg2);

            ////+++Bar treti slozky
            Windows.UI.Xaml.Controls.Grid thirdBarGrid = new Windows.UI.Xaml.Controls.Grid();
            stationProgBarsStck.Children.Add(thirdBarGrid);
            thirdBarGrid.Margin = new Thickness(Window.Current.Bounds.Height / 60, 0, Window.Current.Bounds.Height / 60, 0);

            StackPanel predelatNaImg3 = new StackPanel();
            predelatNaImg3.Background = new SolidColorBrush(Colors.GreenYellow);
            predelatNaImg3.Width = Window.Current.Bounds.Height / 20;
            predelatNaImg3.Height = Window.Current.Bounds.Height / 3;
            thirdBarGrid.Children.Add(predelatNaImg3);

            ////+++Bar ctvrte slozky
            Windows.UI.Xaml.Controls.Grid fourthBarGrid = new Windows.UI.Xaml.Controls.Grid();
            stationProgBarsStck.Children.Add(fourthBarGrid);
            fourthBarGrid.Margin = new Thickness(Window.Current.Bounds.Height / 60, 0, Window.Current.Bounds.Height / 60, 0);

            StackPanel predelatNaImg4 = new StackPanel();
            predelatNaImg4.Background = new SolidColorBrush(Colors.GreenYellow);
            predelatNaImg4.Width = Window.Current.Bounds.Height / 20;
            predelatNaImg4.Height = Window.Current.Bounds.Height / 3;
            fourthBarGrid.Children.Add(predelatNaImg4);

            ////+++Bar prvni slozky
            Windows.UI.Xaml.Controls.Grid fifthBarGrid = new Windows.UI.Xaml.Controls.Grid();
            stationProgBarsStck.Children.Add(fifthBarGrid);
            fifthBarGrid.Margin = new Thickness(Window.Current.Bounds.Height / 60, 0, Window.Current.Bounds.Height / 60, 0);

            StackPanel predelatNaImg5 = new StackPanel();
            predelatNaImg5.Background = new SolidColorBrush(Colors.GreenYellow);
            predelatNaImg5.Width = Window.Current.Bounds.Height / 20;
            predelatNaImg5.Height = Window.Current.Bounds.Height / 3;
            fifthBarGrid.Children.Add(predelatNaImg5);
            


            ////+Grid pro legendu a hlavni stav
            Windows.UI.Xaml.Controls.Grid legendInnerInnerLeftPanelGrid = new Windows.UI.Xaml.Controls.Grid();
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendInnerInnerLeftPanelGrid, 2);
            legendInnerInnerLeftPanelGrid.Height = (Window.Current.Bounds.Height / 6) * 3;
            legendInnerInnerLeftPanelGrid.Width = (Window.Current.Bounds.Height / 6) * 3;
            outerInnerLeftPanelGrid.Children.Add(legendInnerInnerLeftPanelGrid);


            ColumnDefinition legendColDef1 = new ColumnDefinition();
            legendColDef1.Width = new GridLength(1, GridUnitType.Star);
            legendInnerInnerLeftPanelGrid.ColumnDefinitions.Add(legendColDef1);
            ColumnDefinition legendColDef2 = new ColumnDefinition();
            legendColDef2.Width = new GridLength(1, GridUnitType.Star);
            legendInnerInnerLeftPanelGrid.ColumnDefinitions.Add(legendColDef2);

            ////++Stackpanel pro hlavní status

            Windows.UI.Xaml.Controls.Grid legendStatusStck = new Windows.UI.Xaml.Controls.Grid();
            legendStatusStck.Background = new SolidColorBrush(Colors.YellowGreen); //prepsat a funkci
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendStatusStck, 0);
            legendStatusStck.Height = Window.Current.Bounds.Height / 6;
            legendStatusStck.Width = Window.Current.Bounds.Height / 6;
            legendStatusStck.HorizontalAlignment = HorizontalAlignment.Center;
            legendStatusStck.VerticalAlignment = VerticalAlignment.Top;
            legendStatusStck.Margin = new Thickness(0, Window.Current.Bounds.Height / 12, 0, 0);
            legendInnerInnerLeftPanelGrid.Children.Add(legendStatusStck);

            TextBlock legendStatusTxt = new TextBlock();
            legendStatusTxt.Foreground = new SolidColorBrush(Colors.White);
            legendStatusTxt.Text = "2"; //prepsat na funkci
            legendStatusTxt.FontSize = Window.Current.Bounds.Height / 12;
            legendStatusTxt.HorizontalAlignment = HorizontalAlignment.Center;
            legendStatusTxt.VerticalAlignment = VerticalAlignment.Center;
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendStatusTxt, 1);
            legendStatusStck.Children.Add(legendStatusTxt);

            ////++Grid pro legendu
            Windows.UI.Xaml.Controls.Grid legendLegendGrid = new Windows.UI.Xaml.Controls.Grid();
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendLegendGrid, 1);
            legendLegendGrid.HorizontalAlignment = HorizontalAlignment.Center;
            legendLegendGrid.VerticalAlignment = VerticalAlignment.Top;
            legendLegendGrid.Margin = new Thickness(0, Window.Current.Bounds.Height / 12, 0, 0);
            legendInnerInnerLeftPanelGrid.Children.Add(legendLegendGrid);

            ColumnDefinition legendLegendColDef1 = new ColumnDefinition();
            legendLegendColDef1.Width = new GridLength(Window.Current.Bounds.Height / 25, GridUnitType.Pixel);
            legendLegendGrid.ColumnDefinitions.Add(legendLegendColDef1);
            ColumnDefinition legendLegendColDef2 = new ColumnDefinition();
            legendLegendColDef2.Width = new GridLength(Window.Current.Bounds.Height / 100, GridUnitType.Pixel);
            legendLegendGrid.ColumnDefinitions.Add(legendLegendColDef2);
            ColumnDefinition legendLegendColDef3 = new ColumnDefinition();
            legendLegendColDef3.Width = new GridLength(10, GridUnitType.Star);
            legendLegendGrid.ColumnDefinitions.Add(legendLegendColDef3);

            RowDefinition legendLegendRowDef1 = new RowDefinition();
            legendLegendRowDef1.Height = new GridLength(Window.Current.Bounds.Height / 25, GridUnitType.Pixel);
            legendLegendGrid.RowDefinitions.Add(legendLegendRowDef1);
            RowDefinition legendLegendRowDef2 = new RowDefinition();
            legendLegendRowDef2.Height = new GridLength(Window.Current.Bounds.Height / 25, GridUnitType.Pixel);
            legendLegendGrid.RowDefinitions.Add(legendLegendRowDef2);
            RowDefinition legendLegendRowDef3 = new RowDefinition();
            legendLegendRowDef3.Height = new GridLength(Window.Current.Bounds.Height / 25, GridUnitType.Pixel);
            legendLegendGrid.RowDefinitions.Add(legendLegendRowDef3);
            RowDefinition legendLegendRowDef4 = new RowDefinition();
            legendLegendRowDef4.Height = new GridLength(Window.Current.Bounds.Height / 25, GridUnitType.Pixel);
            legendLegendGrid.RowDefinitions.Add(legendLegendRowDef4);
            RowDefinition legendLegendRowDef5 = new RowDefinition();
            legendLegendRowDef5.Height = new GridLength(Window.Current.Bounds.Height / 25, GridUnitType.Pixel);
            legendLegendGrid.RowDefinitions.Add(legendLegendRowDef5);
            RowDefinition legendLegendRowDef6 = new RowDefinition();
            legendLegendRowDef6.Height = new GridLength(Window.Current.Bounds.Height / 25, GridUnitType.Pixel);
            legendLegendGrid.RowDefinitions.Add(legendLegendRowDef6);
            RowDefinition legendLegendRowDef7 = new RowDefinition();
            legendLegendRowDef7.Height = new GridLength(Window.Current.Bounds.Height / 25, GridUnitType.Pixel);
            legendLegendGrid.RowDefinitions.Add(legendLegendRowDef7);
            RowDefinition legendLegendRowDef8 = new RowDefinition();
            legendLegendRowDef8.Height = new GridLength(Window.Current.Bounds.Height / 25, GridUnitType.Pixel);
            legendLegendGrid.RowDefinitions.Add(legendLegendRowDef8);

            ////+++Jednotlive legendy
            //1
            StackPanel legendUnitImg1 = new StackPanel();
            legendUnitImg1.Background = new SolidColorBrush(Color.FromArgb(255, 207, 51, 27));
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendUnitImg1, 0);
            Windows.UI.Xaml.Controls.Grid.SetRow(legendUnitImg1, 0);
            legendLegendGrid.Children.Add(legendUnitImg1);

            TextBlock legentUnitTxt1 = new TextBlock();
            legentUnitTxt1.Foreground = new SolidColorBrush(Colors.White);
            legentUnitTxt1.Text = "velmi špatné";
            legentUnitTxt1.FontSize = Window.Current.Bounds.Height / 40;
            Windows.UI.Xaml.Controls.Grid.SetColumn(legentUnitTxt1, 2);
            Windows.UI.Xaml.Controls.Grid.SetRow(legentUnitTxt1, 0);
            legendLegendGrid.Children.Add(legentUnitTxt1);
            //2
            StackPanel legendUnitImg2 = new StackPanel();
            legendUnitImg2.Background = new SolidColorBrush(Color.FromArgb(255, 207, 84, 23));
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendUnitImg2, 0);
            Windows.UI.Xaml.Controls.Grid.SetRow(legendUnitImg2, 1);
            legendLegendGrid.Children.Add(legendUnitImg2);

            TextBlock legentUnitTxt2 = new TextBlock();
            legentUnitTxt2.Foreground = new SolidColorBrush(Colors.White);
            legentUnitTxt2.Text = "špatné";
            legentUnitTxt2.FontSize = Window.Current.Bounds.Height / 40;
            Windows.UI.Xaml.Controls.Grid.SetColumn(legentUnitTxt2, 2);
            Windows.UI.Xaml.Controls.Grid.SetRow(legentUnitTxt2, 1);
            legendLegendGrid.Children.Add(legentUnitTxt2);
            //3
            StackPanel legendUnitImg3 = new StackPanel();
            legendUnitImg3.Background = new SolidColorBrush(Color.FromArgb(255, 207, 141, 19));
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendUnitImg3, 0);
            Windows.UI.Xaml.Controls.Grid.SetRow(legendUnitImg3, 2);
            legendLegendGrid.Children.Add(legendUnitImg3);

            TextBlock legentUnitTxt3 = new TextBlock();
            legentUnitTxt3.Foreground = new SolidColorBrush(Colors.White);
            legentUnitTxt3.Text = "vyhovující";
            legentUnitTxt3.FontSize = Window.Current.Bounds.Height / 40;
            Windows.UI.Xaml.Controls.Grid.SetColumn(legentUnitTxt3, 2);
            Windows.UI.Xaml.Controls.Grid.SetRow(legentUnitTxt3, 2);
            legendLegendGrid.Children.Add(legentUnitTxt3);
            //4
            StackPanel legendUnitImg4 = new StackPanel();
            legendUnitImg4.Background = new SolidColorBrush(Color.FromArgb(255, 184, 177, 0));
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendUnitImg4, 0);
            Windows.UI.Xaml.Controls.Grid.SetRow(legendUnitImg4, 3);
            legendLegendGrid.Children.Add(legendUnitImg4);

            TextBlock legentUnitTxt4 = new TextBlock();
            legentUnitTxt4.Foreground = new SolidColorBrush(Colors.White);
            legentUnitTxt4.Text = "uspokojivé";
            legentUnitTxt4.FontSize = Window.Current.Bounds.Height / 40;
            Windows.UI.Xaml.Controls.Grid.SetColumn(legentUnitTxt4, 2);
            Windows.UI.Xaml.Controls.Grid.SetRow(legentUnitTxt4, 3);
            legendLegendGrid.Children.Add(legentUnitTxt4);
            //5
            StackPanel legendUnitImg5 = new StackPanel();
            legendUnitImg5.Background = new SolidColorBrush(Color.FromArgb(255, 132, 161, 47));
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendUnitImg5, 0);
            Windows.UI.Xaml.Controls.Grid.SetRow(legendUnitImg5, 4);
            legendLegendGrid.Children.Add(legendUnitImg5);

            TextBlock legentUnitTxt5 = new TextBlock();
            legentUnitTxt5.Foreground = new SolidColorBrush(Colors.White);
            legentUnitTxt5.Text = "dobré";
            legentUnitTxt5.FontSize = Window.Current.Bounds.Height / 40;
            Windows.UI.Xaml.Controls.Grid.SetColumn(legentUnitTxt5, 2);
            Windows.UI.Xaml.Controls.Grid.SetRow(legentUnitTxt5, 4);
            legendLegendGrid.Children.Add(legentUnitTxt5);
            //6
            StackPanel legendUnitImg6 = new StackPanel();
            legendUnitImg6.Background = new SolidColorBrush(Color.FromArgb(255, 0, 138, 0));
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendUnitImg6, 0);
            Windows.UI.Xaml.Controls.Grid.SetRow(legendUnitImg6, 5);
            legendLegendGrid.Children.Add(legendUnitImg6);

            TextBlock legentUnitTxt6 = new TextBlock();
            legentUnitTxt6.Foreground = new SolidColorBrush(Colors.White);
            legentUnitTxt6.Text = "velmi dobré";
            legentUnitTxt6.FontSize = Window.Current.Bounds.Height / 40;
            Windows.UI.Xaml.Controls.Grid.SetColumn(legentUnitTxt6, 2);
            Windows.UI.Xaml.Controls.Grid.SetRow(legentUnitTxt6, 5);
            legendLegendGrid.Children.Add(legentUnitTxt6);
            //7
            StackPanel legendUnitImg7 = new StackPanel();
            legendUnitImg7.Background = new SolidColorBrush(Color.FromArgb(255, 143, 143, 143));
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendUnitImg7, 0);
            Windows.UI.Xaml.Controls.Grid.SetRow(legendUnitImg7, 6);
            legendLegendGrid.Children.Add(legendUnitImg7);

            TextBlock legentUnitTxt7 = new TextBlock();
            legentUnitTxt7.Foreground = new SolidColorBrush(Colors.White);
            legentUnitTxt7.Text = "neměří se";
            legentUnitTxt7.FontSize = Window.Current.Bounds.Height / 40;
            Windows.UI.Xaml.Controls.Grid.SetColumn(legentUnitTxt7, 2);
            Windows.UI.Xaml.Controls.Grid.SetRow(legentUnitTxt7, 6);
            legendLegendGrid.Children.Add(legentUnitTxt7);
            //8
            StackPanel legendUnitImg8 = new StackPanel();
            legendUnitImg8.Background = new SolidColorBrush(Color.FromArgb(255, 138, 137, 156));
            Windows.UI.Xaml.Controls.Grid.SetColumn(legendUnitImg8, 0);
            Windows.UI.Xaml.Controls.Grid.SetRow(legendUnitImg8, 7);
            legendLegendGrid.Children.Add(legendUnitImg8);

            TextBlock legentUnitTxt8 = new TextBlock();
            legentUnitTxt8.Foreground = new SolidColorBrush(Colors.White);
            legentUnitTxt8.Text = "nejsou data";
            legentUnitTxt8.FontSize = Window.Current.Bounds.Height / 40;
            Windows.UI.Xaml.Controls.Grid.SetColumn(legentUnitTxt8, 2);
            Windows.UI.Xaml.Controls.Grid.SetRow(legentUnitTxt8, 7);
            legendLegendGrid.Children.Add(legentUnitTxt8);



            /*
            //grid pro stanici a stavy
            Windows.UI.Xaml.Controls.Grid station = new Windows.UI.Xaml.Controls.Grid();
            Windows.UI.Xaml.Controls.Grid.SetColumn(station, 0);
            Windows.UI.Xaml.Controls.Grid.SetColumnSpan(station, 4);
            Windows.UI.Xaml.Controls.Grid.SetRow(station, 1);
            Windows.UI.Xaml.Controls.Grid.SetRowSpan(station, 4);
            LeftPanel.Children.Add(station);
            
                StackPanel stationName = new StackPanel();
                stationName.Margin = new Thickness(0,(Window.Current.Bounds.Height / 30),0,0);
                    TextBlock stationTitle = new TextBlock();
                    stationTitle.Text = "Ostrava-Fifejdy";//prepsat na funkci
                    stationTitle.FontSize = (Window.Current.Bounds.Height / 30);
                    //stationTitle.FontWeight = FontWeights.Bold;
                    stationTitle.Foreground = new SolidColorBrush(Colors.White);
                    stationTitle.HorizontalAlignment = HorizontalAlignment.Center;
                    stationName.Children.Add(stationTitle);

                    TextBlock stationTerritory = new TextBlock();
                    stationTerritory.Text = "Moravskoslezský kraj";//prepsat na funkci
                    stationTerritory.FontSize = (Window.Current.Bounds.Height / 40);
                    stationTerritory.Foreground = new SolidColorBrush(Colors.White);
                    stationTerritory.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
                    stationName.Children.Add(stationTerritory);
                station.Children.Add(stationName);

                StackPanel stationCoords = new StackPanel();
                    TextBlock stationCoordsTxt = new TextBlock();
                    stationCoordsTxt.Margin = new Thickness(0, (Window.Current.Bounds.Height / 30), 0, 0);
                    stationCoordsTxt.Text = "49°50'51\"N, 19°20'21\"E (+6 km)";//prepsat na funkci
                    stationCoordsTxt.FontSize = (Window.Current.Bounds.Height / 40);
                    stationCoordsTxt.Foreground = new SolidColorBrush(Colors.White);
                    stationCoordsTxt.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
                    stationCoords.Children.Add(stationCoordsTxt);
                station.Children.Add(stationCoords);

                Windows.UI.Xaml.Controls.Grid stationStatuses = new Windows.UI.Xaml.Controls.Grid();
                ColumnDefinition coludef1 = new ColumnDefinition();
                stationStatuses.ColumnDefinitions.Add(coludef1);
                ColumnDefinition coludef2 = new ColumnDefinition();
                stationStatuses.ColumnDefinitions.Add(coludef2);
                ColumnDefinition coludef3 = new ColumnDefinition();
                stationStatuses.ColumnDefinitions.Add(coludef3);
                ColumnDefinition coludef4 = new ColumnDefinition();
                stationStatuses.ColumnDefinitions.Add(coludef4);
                ColumnDefinition coludef5 = new ColumnDefinition();
                stationStatuses.ColumnDefinitions.Add(coludef5);
                stationStatuses.Height = (Window.Current.Bounds.Height / 20);
                stationStatuses.Background = new SolidColorBrush(Colors.Red);
            /*
                    //jednotlive stavy, nutné poté hodit do funkce
                    TextBlock status1txt = new TextBlock();
                    status1txt.FontSize = (Window.Current.Bounds.Height / 60);
                    status1txt.Foreground = new SolidColorBrush(Colors.White);
                    status1txt.HorizontalAlignment = HorizontalAlignment.Center;
                    Windows.UI.Xaml.Controls.Grid.SetColumn(status1txt, 0);
                    stationStatuses.Children.Add(status1txt);
            
                    Windows.UI.Xaml.Controls.Grid status1img = new Windows.UI.Xaml.Controls.Grid();
                    status1img.Background = new SolidColorBrush(Colors.Tomato);
                    stationStatuses.Children.Add(status1img);

                    TextBlock status1imgtxt = new TextBlock();
                    status1imgtxt.FontSize = (Window.Current.Bounds.Height / 50);
                    status1imgtxt.Foreground = new SolidColorBrush(Colors.White);
                    status1imgtxt.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
                    Windows.UI.Xaml.Controls.Grid.SetColumn(status1imgtxt, 0);
                    status1img.Children.Add(status1imgtxt);
            
                station.Children.Add(stationStatuses);
            
            //stack panel pro teplomery, celkovy stav a legendu
            Windows.UI.Xaml.Controls.Grid legend = new Windows.UI.Xaml.Controls.Grid();
            Windows.UI.Xaml.Controls.Grid.SetColumn(legend, 0);
            Windows.UI.Xaml.Controls.Grid.SetColumnSpan(legend, 4);
            Windows.UI.Xaml.Controls.Grid.SetRow(legend, 0);
            Windows.UI.Xaml.Controls.Grid.SetRowSpan(legend, 4);
            LeftPanel.Children.Add(legend);

                StackPanel stationBars = new StackPanel();
                legend.Children.Add(stationBars);
                StackPanel stationStatus = new StackPanel();
                legend.Children.Add(stationStatus);
                StackPanel stationLegend = new StackPanel();
                legend.Children.Add(stationLegend);*/
        }

        private void leftPanelFullfill() 
        {
            for (int i = 0; i < 55; i++) 
            {
                if (i == 0 || ((1 < i) && (i < 11)))
                {
                    /*
                    Rectangle rect = new Rectangle();
                    Windows.UI.Xaml.Controls.Grid.SetColumn(rect, i % 11);
                    Windows.UI.Xaml.Controls.Grid.SetColumnSpan(rect, 1);
                    Windows.UI.Xaml.Controls.Grid.SetRow(rect, i / 11);
                    Windows.UI.Xaml.Controls.Grid.SetRowSpan(rect, 1);
                     * */
                }
                else 
                {
                    Canvas tile = new Canvas();
                    tile.Background = new SolidColorBrush(Color.FromArgb(255, 50, 50, 50));
                    Windows.UI.Xaml.Controls.Grid.SetColumn(tile, i % 11);
                    Windows.UI.Xaml.Controls.Grid.SetColumnSpan(tile, 1);
                    Windows.UI.Xaml.Controls.Grid.SetRow(tile, i / 11);
                    Windows.UI.Xaml.Controls.Grid.SetRowSpan(tile, 1);
                    leftPanelCollection.Add(tile);
                    LeftPanel.Children.Add(tile);
                }
            }

            leftPanelCollection.ElementAt(0).buttonLeftPanelTile();
        
        }
        
        public static void hideLeftPanel() 
        {
            LeftPanel.Margin = new Thickness(0, 0, 0, 0);
            leftPanelCollection.ElementAt(0).buttonLeftPanelTile();
        }
        public static void showLeftPanel() 
        {
            hideRightPanel();
            LeftPanel.Margin = new Thickness(0, -(Window.Current.Bounds.Height / 6) * 4, 0, 0);
            leftPanelCollection.ElementAt(0).buttonLeftPanelButton();
            
        }
    }
}
