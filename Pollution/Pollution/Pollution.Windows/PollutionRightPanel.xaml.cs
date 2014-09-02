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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pollution
{
    public sealed partial class MainPage : Page
    {

        public static Windows.UI.Xaml.Controls.Grid RightPanel = new Windows.UI.Xaml.Controls.Grid();
        static List<Canvas> rightPanelCollection = new List<Canvas>();

        private void rightPanelInit()
        {
            //definice pozadi
            RightPanel.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));


            //definice rozmeru
            RightPanel.Width = (Window.Current.Bounds.Height / 6) * 11;
            RightPanel.Height = (Window.Current.Bounds.Height / 6) * 5;


            RightPanel.VerticalAlignment = VerticalAlignment.Top;
            RightPanel.HorizontalAlignment = HorizontalAlignment.Center;


            //deklarace a definice 5 radku
            RowDefinition rowdef1 = new RowDefinition();
            RightPanel.RowDefinitions.Add(rowdef1);
            RowDefinition rowdef2 = new RowDefinition();
            RightPanel.RowDefinitions.Add(rowdef2);
            RowDefinition rowdef3 = new RowDefinition();
            RightPanel.RowDefinitions.Add(rowdef3);
            RowDefinition rowdef4 = new RowDefinition();
            RightPanel.RowDefinitions.Add(rowdef4);
            RowDefinition rowdef5 = new RowDefinition();
            RightPanel.RowDefinitions.Add(rowdef5);


            //deklarace a definice 11 sloupců
            ColumnDefinition coldef1 = new ColumnDefinition();
            RightPanel.ColumnDefinitions.Add(coldef1);
            ColumnDefinition coldef2 = new ColumnDefinition();
            RightPanel.ColumnDefinitions.Add(coldef2);
            ColumnDefinition coldef3 = new ColumnDefinition();
            RightPanel.ColumnDefinitions.Add(coldef3);
            ColumnDefinition coldef4 = new ColumnDefinition();
            RightPanel.ColumnDefinitions.Add(coldef4);
            ColumnDefinition coldef5 = new ColumnDefinition();
            RightPanel.ColumnDefinitions.Add(coldef5);
            ColumnDefinition coldef6 = new ColumnDefinition();
            RightPanel.ColumnDefinitions.Add(coldef6);
            ColumnDefinition coldef7 = new ColumnDefinition();
            RightPanel.ColumnDefinitions.Add(coldef7);
            ColumnDefinition coldef8 = new ColumnDefinition();
            RightPanel.ColumnDefinitions.Add(coldef8);
            ColumnDefinition coldef9 = new ColumnDefinition();
            RightPanel.ColumnDefinitions.Add(coldef9);
            ColumnDefinition coldef10 = new ColumnDefinition();
            RightPanel.ColumnDefinitions.Add(coldef10);
            ColumnDefinition coldef11 = new ColumnDefinition();
            RightPanel.ColumnDefinitions.Add(coldef11);


            //nastavení pozice            
            Windows.UI.Xaml.Controls.Grid.SetColumn(RightPanel, 0);
            Windows.UI.Xaml.Controls.Grid.SetColumnSpan(RightPanel, 11);
            Windows.UI.Xaml.Controls.Grid.SetRow(RightPanel, 0);
            Windows.UI.Xaml.Controls.Grid.SetRowSpan(RightPanel, 6);
            
            RightPanel.Margin = new Thickness(0, -(Window.Current.Bounds.Height / 6) * 5, 0, 0);

            LayoutGrid.Children.Add(RightPanel);
            rightPanelFullfill();


            //stack panel pro menu
            StackPanel menu = new StackPanel();
            
            Windows.UI.Xaml.Controls.Grid.SetColumn(menu, 0);
            Windows.UI.Xaml.Controls.Grid.SetColumnSpan(menu, 4);
            Windows.UI.Xaml.Controls.Grid.SetRow(menu, 0);
            Windows.UI.Xaml.Controls.Grid.SetRowSpan(menu, 4);

            

            HyperlinkButton button1 = new HyperlinkButton();
            button1.NavigateUri = new Uri(@"http://www.silverlight.net");
            button1.FontSize = (Window.Current.Bounds.Height / 40);
            button1.Foreground = new SolidColorBrush(Colors.White);
            button1.Content = "Mapa";
            button1.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            button1.Margin = new Thickness((Window.Current.Bounds.Height / 20), (Window.Current.Bounds.Height / 20), 0, 0);
            menu.Children.Add(button1);

            HyperlinkButton button2 = new HyperlinkButton();
            button2.NavigateUri = new Uri(@"http://www.silverlight.net");
            button2.FontSize = (Window.Current.Bounds.Height / 40);
            button2.Foreground = new SolidColorBrush(Colors.White);
            button2.Content = "Seznam stanic";
            button2.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            button2.Margin = new Thickness((Window.Current.Bounds.Height / 20), -(Window.Current.Bounds.Height / 40), 0, 0);
            menu.Children.Add(button2);

            HyperlinkButton button3 = new HyperlinkButton();
            button3.NavigateUri = new Uri(@"http://www.silverlight.net");
            button3.FontSize = (Window.Current.Bounds.Height / 40);
            button3.Foreground = new SolidColorBrush(Colors.White);
            button3.Content = "Fotky";
            button3.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            button3.Margin = new Thickness((Window.Current.Bounds.Height / 20), -(Window.Current.Bounds.Height / 40), 0, 0);
            menu.Children.Add(button3);

            HyperlinkButton button4 = new HyperlinkButton();
            button4.NavigateUri = new Uri(@"http://www.silverlight.net");
            button4.FontSize = (Window.Current.Bounds.Height / 40);
            button4.Foreground = new SolidColorBrush(Colors.White);
            button4.Content = "Hodnocení ovzduší";
            button4.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            button4.Margin = new Thickness((Window.Current.Bounds.Height / 20), -(Window.Current.Bounds.Height / 40), 0, 0);
            menu.Children.Add(button4);

            HyperlinkButton button5 = new HyperlinkButton();
            button5.NavigateUri = new Uri(@"http://www.silverlight.net");
            button5.FontSize = (Window.Current.Bounds.Height / 40);
            button5.Foreground = new SolidColorBrush(Colors.White);
            button5.Content = "Nastavení";
            button5.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            button5.Margin = new Thickness((Window.Current.Bounds.Height / 20), (Window.Current.Bounds.Height / 20), 0, 0);
            menu.Children.Add(button5);

            RightPanel.Children.Add(menu);

            //stackpanel pro zobrazeni uzivatelu
            Windows.UI.Xaml.Controls.Grid usersFrame = new Windows.UI.Xaml.Controls.Grid();
            

            Windows.UI.Xaml.Controls.Grid.SetColumn(usersFrame, 6);
            Windows.UI.Xaml.Controls.Grid.SetColumnSpan(usersFrame, 4);
            Windows.UI.Xaml.Controls.Grid.SetRow(usersFrame, 0);
            Windows.UI.Xaml.Controls.Grid.SetRowSpan(usersFrame, 4);

            StackPanel users = new StackPanel();
            users.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Right;
            users.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Bottom;
            usersFrame.Children.Add(users);
            users.Margin = new Thickness(0, 0, (Window.Current.Bounds.Height / 100), (Window.Current.Bounds.Height / 40));

            TextBlock title = new TextBlock();
            title.Text = "V okolí je právě:";
            title.FontWeight = FontWeights.Bold;
            title.FontSize = (Window.Current.Bounds.Height / 40);
            title.Foreground = new SolidColorBrush(Colors.White);
            users.Children.Add(title);

            TextBlock value = new TextBlock();
            value.Text = "26" + " uživatelů";   //prepsat na funkci
            value.FontWeight = FontWeights.Bold;
            value.FontSize = (Window.Current.Bounds.Height / 40);
            value.Foreground = new SolidColorBrush(Colors.White);
            users.Children.Add(value);

            


            RightPanel.Children.Add(usersFrame);
        }

        private void rightPanelFullfill()
        {
            for (int i = 0; i < 55; i++)
            {
                if (((43 < i) && (i < 52)) || ((52 < i) && (i < 55)))
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
                    rightPanelCollection.Add(tile);
                    RightPanel.Children.Add(tile);
                }
            }

            rightPanelCollection.ElementAt(44).buttonRightPanelTile();

        }

        public static void hideRightPanel()
        {
            RightPanel.Margin = new Thickness(0, -(Window.Current.Bounds.Height / 6) * 4, 0, 0);
            rightPanelCollection.ElementAt(44).buttonRightPanelTile();
        }
        public static void showRightPanel()
        {
            RightPanel.Margin = new Thickness(0, 0, 0, 0);
            rightPanelCollection.ElementAt(44).buttonRightPanelButton();
        }
    }
}
